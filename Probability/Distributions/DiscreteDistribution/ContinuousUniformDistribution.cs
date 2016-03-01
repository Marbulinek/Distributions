using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.DiscreteDistribution
{
    /// <summary>
    /// Continuous Uniform Distribution
    /// </summary>
    public class ContinuousUniformDistribution : UniformDistribution
    {
        private double _min;
        private double _max;

        /// <summary>
        /// Initiate Continuous uniform distribution
        /// </summary>
        /// <param name="random">Seed from universal generator</param>
        /// <param name="min">minimum</param>
        /// <param name="max">maximum</param>
        public ContinuousUniformDistribution(Random random, double min, double max) : base(random)
        {
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Continuous Uniform Distribution
        /// </summary>
        /// <returns>Number from continuous uniform distribution</returns>
        public override double GetDistribution()
        {
            return (base.DistributionGenerator.NextDouble() * (_max - _min)) + _min;
        }
    }
}
