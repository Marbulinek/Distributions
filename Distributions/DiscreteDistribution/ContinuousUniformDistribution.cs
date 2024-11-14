namespace Distributions.DiscreteDistribution
{
    /// <summary>
    /// Continuous Uniform Distribution
    /// </summary>
    public class ContinuousUniformDistribution : UniformDistribution
    {
        private readonly double _min;
        private readonly double _max;

        /// <summary>
        /// Initiate Continuous uniform distribution
        /// </summary>
        /// <param name="random">Seed from universal generator</param>
        /// <param name="min">minimum</param>
        /// <param name="max">maximum</param>
        public ContinuousUniformDistribution(Random random, double min, double max) : base(random)
        {
            this._min = min;
            this._max = max;
        }

        /// <summary>
        /// Continuous Uniform Distribution
        /// </summary>
        /// <returns>Number from continuous uniform distribution</returns>
        public override double GetDistribution()
        {
            return (base.DistributionGenerator.NextDouble() * (this._max - this._min)) + this._min;
        }
    }
}
