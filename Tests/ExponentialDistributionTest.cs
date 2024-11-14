using Distributions.ExponentialDistribution;

namespace Tests;

[TestClass]
public sealed class ExponentialDistributionTest
{
    [TestMethod]
    public void GetDistributionReturnsPositiveValue()
    {
        var random = new Random();
        var distribution = new ExponentialDistribution(random, 1.0);
        var result = distribution.GetDistribution();
        Assert.IsTrue(result > 0);
    }

    [TestMethod]
    public void GetDistributionHandlesLargeMedian()
    {
        var random = new Random();
        var distribution = new ExponentialDistribution(random, 1000.0);
        var result = distribution.GetDistribution();
        Assert.IsTrue(result > 0);
    }

    [TestMethod]
    public void GetDistributionHandlesSmallMedian()
    {
        var random = new Random();
        var distribution = new ExponentialDistribution(random, 0.001);
        var result = distribution.GetDistribution();
        Assert.IsTrue(result > 0);
    }
}