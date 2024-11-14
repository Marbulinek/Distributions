namespace Distributions.DiscreteDistribution
{
    public abstract class UniformDistribution(Random random) : IDistribution
    {
        public Random DistributionGenerator { get; set; } = new(random.Next());

        public abstract double GetDistribution();
    }
}
