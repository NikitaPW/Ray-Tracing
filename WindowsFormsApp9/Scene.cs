using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Scene
    {
        Light light;
        List<Sphere> rayObjects;

        public Scene()
        {
            
            rayObjects = new List<Sphere>();
        }
        public void ClearRayObjects()
        {
            rayObjects = new List<Sphere>();
        }
        public void AddLight(Light light)
        {
            this.light = light;
        }
        public void AddRayObject(Sphere rayObject)
        {
            rayObjects.Add(rayObject);
        }
        public List<Intersection> Intersections(Ray ray)
        {
            List<Intersection> intersections = new List<Intersection>();
            foreach(Sphere r in rayObjects)
            {
                List<float> tempList = r.Intersect(ray);
                for (int i =0; i < tempList.Count; i++)
                {
                    intersections.Add(new Intersection(r, tempList[i]));
                }
            }
            return SortIntersections(intersections);
        }

        protected List<Intersection> SortIntersections(List<Intersection> intersections)
        {
            if (intersections.Count == 0)
            {
                return intersections;
            }

            List<Intersection> sortedIntersections = new List<Intersection>();
            int currentIntersection = 1;
            sortedIntersections.Add(intersections[0]);
            bool valueInserted;
            while (currentIntersection < intersections.Count)
            {
                valueInserted = false;
                for (int i = 0; i < sortedIntersections.Count; i++)
                {
                    if (intersections[currentIntersection].t < sortedIntersections[i].t)
                    {
                        sortedIntersections.Insert(i, intersections[currentIntersection]);
                        currentIntersection++;
                        valueInserted = true;
                        break;
                    }
                }
                if (!valueInserted)
                {
                    sortedIntersections.Add(intersections[currentIntersection]);
                    currentIntersection++;
                }
            }
            return sortedIntersections;
        }

        public Intersection Hit(List<Intersection> intersections)
        {
            if (intersections.Count == 0)
            {
                return null;
            }


            Intersection first = null;
            for (int i = 0; i < intersections.Count; i++)
            {
                if (intersections[i].t < 0.0f)
                {
                    continue;
                }
                else
                {
                    first = intersections[i];
                    break;
                }
            }
            return first ;
        }

        public Color ShadeHit(Computations c)
        {
            if (c == null) return Color.Black;
            Color finalColor = new Color(0, 0, 0);
            
            finalColor += c.sphere.Lighting(c.point, light, c.eye, c.normal);
            
            return finalColor;
        }

        public Color ColorAt(Ray ray)
        {
            List<Intersection> hits = this.Intersections(ray);
            if (hits.Count == 0)
            {
                return Color.Black;
            }
            Intersection hit = this.Hit(hits);
            Computations c = Computations.PrepareComputations(hit, ray);
            Color finalColor = ShadeHit(c);
            return finalColor;
        }

        public Ray RayForPixel(Camera camera, int x, int y)
        {
            float xOffset = (x + 0.5f) * camera.pixelSize;
            float yOffset = (y + 0.5f) * camera.pixelSize;

            float worldX = camera.halfWidth - xOffset;
            float worldY = camera.halfHeight - yOffset;

            Point pixel = camera.transform.Inverse() * new Point(worldX, worldY, -1.0f);
            Point origin = camera.transform.Inverse() * new Point(0, 0, 0);
            Vector direction = (new Vector(pixel - origin)).Normalize();
            return new Ray(origin, direction);
        }

        public Bitmap Render(Camera camera)
        {
            BitmapUtility bmp = new BitmapUtility(500, 250);
            for(int i = 0; i < 500; i++)
            {
                for(int j=0; j < 250; j++)
                {
                    bmp.SetPixel(i, j, Color.Black);
                }
            }

            for (int y = 0; y < 250; y++)
            {
                for (int x = 0; x < 500; x++)
                {
                    Ray temp = this.RayForPixel(camera, x, y);
                    Color pixelColor = this.ColorAt(temp);
                    bmp.SetPixel(x, y, pixelColor);
                }
            }

            return bmp.Bitmap;
        }
    }
}
