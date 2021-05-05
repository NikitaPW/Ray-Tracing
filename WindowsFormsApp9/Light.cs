using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Light
    {
        public Color intensity;
        public Point position;

        public Light(Scene scene)
        {
            scene.AddLight(this);
            intensity = new Color(1,1,1);
            position = new Point(0, 0, 0);
        }

        public Light(Scene scene, Point position, Color intensity)
        {
            scene.AddLight(this);
            this.intensity = intensity;
            this.position = position;
        }
    }
}
