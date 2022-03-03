using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationOleg
{
    interface IDistribution
    {
        float generateValue(float param);
    }
}
