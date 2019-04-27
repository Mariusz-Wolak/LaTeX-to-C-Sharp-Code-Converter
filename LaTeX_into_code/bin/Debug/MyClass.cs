using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Math;

namespace LaTeX_into_code
{
    class MyClass
    {
        double myMethod(double x, double n, double y)
        {
			return (1)/(  x/n)+Math.Log(x+1)-Math.PI-Pow(3*y,2/n)*1/Math.Tan(30);
        }
    }
}
