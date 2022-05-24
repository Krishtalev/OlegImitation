using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationOleg
{
    class ExponentialDistribution : IDistribution
    {
        public Random rnd = new Random();
        public double generateValue(double param)
        {
            double a = (double)rnd.NextDouble();
            double value = Math.Abs(-(double)Math.Log(a) / param);
            return value;
        }
    }
}
