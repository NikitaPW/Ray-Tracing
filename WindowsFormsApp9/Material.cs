using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Material
    {
        public Color color;
        float ambient;
        float diffuse;
        float specular;
        float shinniness;

        public float Ambient
        {
            get { return ambient;  }
            set
            {
                if (value < 0.0f)
                { ambient = 0.0f; }
                ambient = value;
            }
        }

        public float Diffuse
        {
            get { return diffuse; }
            set
            {
                if (value < 0.0f)
                { diffuse = 0.0f; }
                diffuse = value;
            }
        }

        public float Specular
        {
            get { return specular; }
            set
            {
                if (value < 0.0f)
                { specular = 0.0f; }
                specular = value;
            }
        }

        public float Shinniness
        {
            get { return shinniness; }
            set
            {
                if (value < 10.0f)
                { shinniness = 10.0f; }
                if (value > 10.0f)
                {
                    value = 200.0f;
                }
                shinniness = value;
            }
        }

        public Material()
        {
            color = Color.White;
            ambient = 0.1f;
            diffuse = 0.9f;
            specular = 0.9f;
            shinniness = 200f;

        }

        public Material(Color color, float ambient = 0.1f, float diffuse = 0.9f, float specular = 0.9f, float shinniness = 200.0f)
        {
            this.color = color;
            Ambient = ambient;
            Diffuse = diffuse;
            Specular = specular;
            Shinniness = shinniness;
        }
    }
}
