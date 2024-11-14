using Distributions.EmpiricalDistribution;

namespace Tests;

[TestClass]
public sealed class EmpiricalDistributionTest
{
    [TestMethod]
    public void GetDistributionReturnsValueWithinEmpiricalRange()
    {
        var seed = new Random();
        var empiricalDistribution = new EmpiricalDistribution(seed);
        empiricalDistribution.AddEmpiricalData(1, 10, 0.5);
        empiricalDistribution.AddEmpiricalData(11, 20, 1.0);
        var result = empiricalDistribution.GetDistribution();
        Assert.IsTrue(result is >= 1 and <= 20);
    }

    [TestMethod]
    public void GetDistributionHandlesSingleEmpiricalData()
    {
        var seed = new Random();
        var empiricalDistribution = new EmpiricalDistribution(seed);
        empiricalDistribution.AddEmpiricalData(5, 5, 1.0);
        var result = empiricalDistribution.GetDistribution();
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void GetDistributionHandlesMultipleEmpiricalData()
    {
        var seed = new Random();
        var empiricalDistribution = new EmpiricalDistribution(seed);
        empiricalDistribution.AddEmpiricalData(1, 5, 0.3);
        empiricalDistribution.AddEmpiricalData(6, 10, 0.7);
        empiricalDistribution.AddEmpiricalData(11, 15, 1.0);
        var result = empiricalDistribution.GetDistribution();
        Assert.IsTrue(result is >= 1 and <= 15);
    }

    [TestMethod]
    public void GetDistributionHandlesEdgeCaseWithZeroProbability()
    {
        var seed = new Random();
        var empiricalDistribution = new EmpiricalDistribution(seed);
        empiricalDistribution.AddEmpiricalData(1, 10, 0.0);
        empiricalDistribution.AddEmpiricalData(11, 20, 1.0);
        var result = empiricalDistribution.GetDistribution();
        Assert.IsTrue(result is >= 11 and <= 20);
    }

    [TestMethod]
    public void GetDistributionHandlesNegativeValues()
    {
        var seed = new Random();
        var empiricalDistribution = new EmpiricalDistribution(seed);
        empiricalDistribution.AddEmpiricalData(-10, -1, 0.5);
        empiricalDistribution.AddEmpiricalData(0, 10, 1.0);
        var result = empiricalDistribution.GetDistribution();
        Assert.IsTrue(result is >= -10 and <= 10);
    }
}