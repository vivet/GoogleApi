using System;
using GoogleApi.Entities.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Common;

[TestClass]
public class PlusCodeTests
{
    [TestMethod]
    public void ConstructorTest()
    {
        var plusCode = new PlusCode("global", "local");

        Assert.AreEqual("global", plusCode.GlobalCode);
        Assert.AreEqual("local", plusCode.LocalCode);
    }

    [TestMethod]
    public void ConstructorWhenGlobalCodeIsNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => new PlusCode(null, "local"));
    }

    [TestMethod]
    public void ConstructorWhenLocalCodeIsNullTest()
    {
        var plusCode = new PlusCode("global");
        Assert.IsNotNull(plusCode);
    }

    [TestMethod]
    public void ToStringTest()
    {
        var plusCode = new PlusCode("global", "local");

        var toString = plusCode.ToString();
        Assert.AreEqual($"{plusCode.GlobalCode}{plusCode.LocalCode}", toString);
    }
}