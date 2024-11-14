using Distributions.DiscreteDistribution;

namespace Tests;

[TestClass]
public sealed class ContinuousUniformDistributionTest
{
    [TestMethod]
    public void GetDistributionReturnsValueWithinRange()
    {
        var random = new Random();
        var distribution = new ContinuousUniformDistribution(random, 1.0, 10.0);
        var result = distribution.GetDistribution();
        Assert.IsTrue(result is >= 1.0 and <= 10.0);
    }

    [TestMethod]
    public void GetDistributionHandlesMinEqualsMax()
    {
        var random = new Random();
        var distribution = new ContinuousUniformDistribution(random, 5.0, 5.0);
        var result = distribution.GetDistribution();
        Assert.AreEqual(5.0, result);
    }

    [TestMethod]
    public void GetDistributionHandlesNegativeRange()
    {
        var random = new Random();
        var distribution = new ContinuousUniformDistribution(random, -10.0, -1.0);
        var result = distribution.GetDistribution();
        Assert.IsTrue(result is >= -10.0 and <= -1.0);
    }

    [TestMethod]
    public void GetDistributionHandlesZeroRange()
    {
        var random = new Random();
        var distribution = new ContinuousUniformDistribution(random, 0.0, 0.0);
        var result = distribution.GetDistribution();
        Assert.AreEqual(0.0, result);
    }
}