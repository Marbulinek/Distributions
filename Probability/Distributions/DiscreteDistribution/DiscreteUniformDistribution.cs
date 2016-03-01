using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.DiscreteDistribution
{
    public class DiscreteUniformDistribution : UniformDistribution
    {
        private int _min;
        private int _max;

        public DiscreteUniformDistribution(Random random, int min, int max) : base(random)
        {
            _min = min;
            _max = max;
        }

        public override double GetDistribution()
        {
            return base.DistributionGenerator.Next( _max - (_min - 1)) + _min;
        }

        internal void SetParameters(int min, int max)
        {
            _min = min;
            _max = max;
        }
    }
}
