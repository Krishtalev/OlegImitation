﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationOleg
{
    class PoissonDistribution : IDistribution
    {
        public float generateValue(float param)
        {
            Random rnd = new Random();
            float a = (float)rnd.NextDouble();
            float value = Math.Abs(-(float)Math.Log(a) / param);
            return value;
        }
    }
}
