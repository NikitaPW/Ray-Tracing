using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    class Help
    {
        public const float pi = 3.1415926535f;

        public static bool FloatEquality(float a, float b)
        {
            float temp = a - b;
            if (temp < 0.0f)
            {
                temp *= -1.0f;
            }

            if (temp < 0.001f)
            {
                return true;
            }

            return false;
        }
    }
}
