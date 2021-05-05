using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Color
    {
        public static Color Red = new Color(1.0f, 0.0f, 0.0f);
        public static Color Green = new Color(0.0f, 1.0f, 0.0f);
        public static Color Blue = new Color(0.0f, 0.0f, 1.0f);
        public static Color Yellow = new Color(1.0f, 1.0f, 0.0f);
        public static Color Black = new Color(0.0f, 0.0f, 0.0f);
        public static Color White = new Color(1.0f, 1.0f, 1.0f);

        public float R;
        public float G;
        public float B;

        public Color(Color color)
        {
            this.R = color.R;
            this.G = color.G;
            this.B = color.B;

        }
        public Color(float r = 0.0f, float g = 0.0f, float b = 0.0f)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public static Color operator + (Color a, Color b)
        {
            Color temp = new Color();
            if (a.R + b.R < 1.0f)
                temp.R = a.R + b.R;
            else temp.R = 1.0f;
            if (a.G + b.G < 1.0f)
                temp.G = a.G + b.G;
            else temp.G = 1.0f;
            if (a.B + b.B < 1.0f)
                temp.B = a.B + b.B;
            else temp.B = 1.0f;
            return temp;
            
        }

        public static Color operator* (Color a, float b)
        {
            Color temp = new Color();
            temp.R = a.R * b;
            temp.G = a.G * b;
            temp.B = a.B * b;
            return temp;
        }

        public static Color operator *(float b, Color a)
        {
            Color temp = new Color();
            temp.R = a.R * b;
            temp.G = a.G * b;
            temp.B = a.B * b;
            return temp;
        }

        public static Color operator *(Color a, Color b)
        {
            Color temp = new Color();
            temp.R = a.R * b.R;
            temp.G = a.G * b.G;
            temp.B = a.B * b.B;
            return temp;
        }
    }
}
