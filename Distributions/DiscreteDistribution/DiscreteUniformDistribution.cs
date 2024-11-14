namespace Distributions.DiscreteDistribution
{
    public class DiscreteUniformDistribution(Random random, int min, int max) : UniformDistribution(random)
    {
        private int _min = min;
        private int _max = max;

        public override double GetDistribution()
        {
            return base.DistributionGenerator.Next( _max - (_min - 1)) + _min;
        }

        internal void SetParameters(int min, int max)
        {
            this._min = min;
            this._max = max;
        }
    }
}
