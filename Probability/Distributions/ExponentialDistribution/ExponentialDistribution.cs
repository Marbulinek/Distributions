using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.ExponentialDistribution
{
    public class ExponentialDistribution : IDistribution
    {
        private Random _random;
        private double _median;

        /// <summary>
        /// Exponential distribution
        /// </summary>
        /// <param name="random">Seed from universal generator</param>
        /// <param name="median">Median value</param>
        public ExponentialDistribution(Random random, double median)
        {
            _random = new Random(random.Next());
            _median = median;
        }

        /// <summary>
        /// Exponential distribution
        /// </summary>
        /// <returns>Number from exponential distribution</returns>
        public double GetDistribution()
        {
            double lambda = 1 / _median;
            return -1 * Math.Log(1 - _random.NextDouble()) / lambda;
        }
    }
}
