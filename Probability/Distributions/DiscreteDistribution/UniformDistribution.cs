using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.DiscreteDistribution
{
    public abstract class UniformDistribution : IDistribution
    {
        private Random _random;

        public Random DistributionGenerator
        {
            get { return _random; }
            set { _random = value; }
        }
        
        public UniformDistribution(Random random)
        {
            _random = new Random(random.Next());
        }

        public abstract double GetDistribution();
    }
}
