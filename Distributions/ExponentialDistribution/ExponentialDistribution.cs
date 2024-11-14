namespace Distributions.ExponentialDistribution
{
    public class ExponentialDistribution : IDistribution
    {
        private readonly Random _random;
        private readonly double _median;

        /// <summary>
        /// Exponential distribution
        /// </summary>
        /// <param name="random">Seed from universal generator</param>
        /// <param name="median">Median value</param>
        public ExponentialDistribution(Random random, double median)
        {
            this._random = new Random(random.Next());
            this._median = median;
        }

        /// <summary>
        /// Exponential distribution
        /// </summary>
        /// <returns>Number from exponential distribution</returns>
        public double GetDistribution()
        {
            var lambda = 1 / this._median;
            return -1 * Math.Log(1 - this._random.NextDouble()) / lambda;
        }
    }
}
