using System;
using System.Linq;
using GoogleApi.Entities.Places.Photos.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Places.Photos;

[TestFixture]
public class PhotosRequestTests
{
    [Test]
    public void GetQueryStringParametersTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "key",
            PhotoReference = "photoreference",
            MaxHeight = 10
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var photoreference = queryStringParameters.FirstOrDefault(x => x.Key == "photoreference");
        var photoreferenceExpected = request.PhotoReference;
        Assert.IsNotNull(photoreference);
        Assert.AreEqual(photoreferenceExpected, photoreference.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenMaxWidthTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "key",
            PhotoReference = "photoreference",
            MaxWidth = 10
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var maxwidth = queryStringParameters.FirstOrDefault(x => x.Key == "maxwidth");
        var maxwidthExpected = request.MaxWidth.ToString();
        Assert.IsNotNull(maxwidth);
        Assert.AreEqual(maxwidthExpected, maxwidth.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenMaxHeightTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "key",
            PhotoReference = "photoreference",
            MaxHeight = 10
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var maxheight = queryStringParameters.FirstOrDefault(x => x.Key == "maxheight");
        var maxheightExpected = request.MaxHeight.ToString();
        Assert.IsNotNull(maxheight);
        Assert.AreEqual(maxheightExpected, maxheight.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = null
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenPhotoReferenceIsNullTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "key",
            PhotoReference = null
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'PhotoReference' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenPhotoReferenceIsStringEmptyTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "key",
            PhotoReference = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'PhotoReference' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenMaxHeightIsNullAndMaxWidthIsNullTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "key",
            PhotoReference = "photoReference"
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'MaxHeight' or 'MaxWidth' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenMaxHeightIsLessThanOneTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "key",
            PhotoReference = "photoReference",
            MaxHeight = 0
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'MaxHeight' must be greater than or equal to 1 and less than or equal to 1.600");
    }

    [Test]
    public void GetQueryStringParametersWhenMaxHeightIsGreaterThanSexteenHundredthsTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "key",
            PhotoReference = "photoReference",
            MaxHeight = 1601
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'MaxHeight' must be greater than or equal to 1 and less than or equal to 1.600");
    }

    [Test]
    public void GetQueryStringParametersWhenMaxWidthIsLessThanOneTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "key",
            PhotoReference = "photoReference",
            MaxWidth = 0
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'MaxWidth' must be greater than or equal to 1 and less than or equal to 1.600");
    }

    [Test]
    public void GetQueryStringParametersWhenMaxWidthIsGreaterThanSexteenHundredthsTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "key",
            PhotoReference = "photoReference",
            MaxWidth = 1601
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'MaxWidth' must be greater than or equal to 1 and less than or equal to 1.600");
    }
}