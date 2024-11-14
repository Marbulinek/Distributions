using Distributions.DiscreteDistribution;

namespace Tests;

[TestClass]
public sealed class DiscreteUniformDistributionTest
{
    [TestMethod]
    public void GetDistributionReturnsValueWithinRange()
    {
        var random = new Random();
        var distribution = new DiscreteUniformDistribution(random, 1, 10);
        var result = distribution.GetDistribution();
        Assert.IsTrue(result is >= 1 and <= 10);
    }

    [TestMethod]
    public void GetDistributionHandlesMinEqualsMax()
    {
        var random = new Random();
        var distribution = new DiscreteUniformDistribution(random, 5, 5);
        var result = distribution.GetDistribution();
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void GetDistributionHandlesNegativeRange()
    {
        var random = new Random();
        var distribution = new DiscreteUniformDistribution(random, -10, -1);
        var result = distribution.GetDistribution();
        Assert.IsTrue(result is >= -10 and <= -1);
    }

    [TestMethod]
    public void GetDistributionHandlesLargeRange()
    {
        var random = new Random();
        var distribution = new DiscreteUniformDistribution(random, int.MinValue, int.MaxValue);
        var result = distribution.GetDistribution();
        Assert.IsTrue(result is >= int.MinValue and <= int.MaxValue);
    }
}