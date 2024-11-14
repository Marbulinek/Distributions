namespace Distributions.EmpiricalDistribution
{
    public class EmpiricalData(Random random, int valueA, int valueB, double valueC)
    {
        public int ValueA { get; } = valueA;
        public int ValueB { get; } = valueB;
        public double ValueC { get; } = valueC;
        public Random Random { get; } = random;
    }
}
