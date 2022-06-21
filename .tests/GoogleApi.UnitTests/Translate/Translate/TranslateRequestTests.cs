using System;
using System.Linq;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Translate.Translate;

[TestFixture]
public class TranslateRequestTests
{
    [Test]
    public void ConstructorDefaultTest()
    {
        var request = new TranslateRequest();

        Assert.IsNull(request.Source);
        Assert.IsNull(request.Target);
        Assert.AreEqual(Model.Base, request.Model);
        Assert.AreEqual(Format.Html, request.Format);
    }

    [Test]
    public void GetQueryStringParametersTest()
    {
        var request = new TranslateRequest
        {
            Key = "key",
            Target = Language.Afrikaans,
            Qs = new[]
            {
                "query"
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var target = queryStringParameters.FirstOrDefault(x => x.Key == "target");
        var targetExpected = request.Target.GetValueOrDefault().ToCode();
        Assert.IsNotNull(target);
        Assert.AreEqual(targetExpected, target.Value);

        var qs = queryStringParameters.FirstOrDefault(x => x.Key == "q");
        var qsExpected = request.Qs.FirstOrDefault();
        Assert.IsNotNull(qs);
        Assert.AreEqual(qsExpected, qs.Value);

        var model = queryStringParameters.FirstOrDefault(x => x.Key == "model");
        var modelExpected = request.Model.ToString().ToLower();
        Assert.IsNotNull(model);
        Assert.AreEqual(modelExpected, model.Value);

        var format = queryStringParameters.FirstOrDefault(x => x.Key == "format");
        var formatExpected = request.Format.ToString().ToLower();
        Assert.IsNotNull(format);
        Assert.AreEqual(formatExpected, format.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new TranslateRequest
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
        var request = new TranslateRequest
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
    public void GetQueryStringParametersWhenTargetIsNullTest()
    {
        var request = new TranslateRequest
        {
            Key = "key",
            Target = null
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Target' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenQsIsNullTest()
    {
        var request = new TranslateRequest
        {
            Key = "key",
            Target = Language.Danish,
            Qs = null
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Qs' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenQsIsEmptyTest()
    {
        var request = new TranslateRequest
        {
            Key = "key",
            Target = Language.Danish,
            Qs = Array.Empty<string>()
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Qs' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenSourceIsNotValidNmtTest()
    {
        var request = new TranslateRequest
        {
            Key = "key",
            Source = Language.Amharic,
            Target = Language.English,
            Qs = new[] { "Hej Verden" },
            Model = Model.Nmt
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Source' is not compatible with model 'Nmt'");
    }

    [Test]
    public void GetQueryStringParametersWhenTargetIsNotValidNmtTest()
    {
        var request = new TranslateRequest
        {
            Key = "key",
            Source = Language.English,
            Target = Language.Amharic,
            Qs = new[] { "Hej Verden" },
            Model = Model.Nmt
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Target' is not compatible with model 'Nmt'");
    }

    [Test]
    public void GetQueryStringParametersWhenModelIsNmtAndSourceOrTargetIsNotEnglishTest()
    {
        var request = new TranslateRequest
        {
            Key = "key",
            Source = Language.Danish,
            Target = Language.Danish,
            Model = Model.Nmt,
            Qs = new[] { "Hej Verden" }
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Source' or 'Target' must be english");
    }
}