using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Common.Extensions;

[TestClass]
public class EnumExtensionTest
{
    [TestMethod]
    public void ToEnumStringTest()
    {
        const AddressComponentType ENUM = AddressComponentType.Postal_Code;

        var result = ENUM.ToEnumString('|');
        Assert.AreEqual("postal_code", result);
    }

    [TestMethod]
    public void ToEnumStringWhenFlagsTest()
    {
        const AvoidWay ENUM = AvoidWay.Highways | AvoidWay.Tolls;

        var result = ENUM.ToEnumString('|');
        Assert.AreEqual("tolls|highways", result);
    }

    [TestMethod]
    public void ToEnumMemberStringTest()
    {
        const StyleFeature ENUM = StyleFeature.Transit;

        var result = ENUM.ToEnumMemberString();
        Assert.AreEqual("transit", result);
    }
}