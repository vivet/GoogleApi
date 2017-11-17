using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Add.Request;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Add
{
    [TestFixture]
    public class AddTests : BaseTest
    {
        [Test]
        public void PlacesAddTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = Guid.NewGuid().ToString("N"),
                Types = new[] { PlaceLocationType.Street_Address },
                Location = new Location(55.664425, 12.502264),
                Accuracy = 50,
                PhoneNumber = "+45 00000000",
                Address = Guid.NewGuid().ToString("N"),
                Website = "http://www.google.com",
                Language = Language.English
            };
            var response = GooglePlaces.Add.Query(request);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.PlaceId);
            Assert.AreEqual(response.Scope, Scope.App);
            Assert.AreEqual(response.Status, Status.Ok);

            var request2 = new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId= response.PlaceId
            };

            var response2 = GooglePlaces.Details.Query(request2);

            Assert.IsNotNull(response2);
            Assert.AreEqual(Status.Ok, response2.Status);
            Assert.AreEqual(response2.Result.Name, request.Name);
            Assert.AreEqual(response2.Result.Website, request.Website);
            Assert.AreEqual(response2.Result.FormattedAddress, request.Address);
            Assert.AreEqual(response2.Result.FormattedPhoneNumber, request.PhoneNumber);
            Assert.AreEqual(response2.Result.Geometry.Location.Latitude, request.Location.Latitude);
            Assert.AreEqual(response2.Result.Geometry.Location.Longitude, request.Location.Longitude);

            Assert.AreEqual(Scope.App, response2.Result.Scope);
            Assert.AreEqual(response2.Result.PlaceId, response.PlaceId);
            Assert.AreEqual(PlaceLocationType.Street_Address, response2.Result.Types.FirstOrDefault());
        }

        [Test]
        public void PlacesAddWhenAsyncTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = Guid.NewGuid().ToString("N"),
                Types = new[] { PlaceLocationType.Street_Address },
                Location = new Location(55.664425, 12.502264),
                Accuracy = 50,
                PhoneNumber = "+45 00000000",
                Address = "MyAddress",
                Website = "http://www.google.com",
                Language = Language.English
            };
            var response = GooglePlaces.Add.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.PlaceId);
            Assert.AreEqual(response.Scope, Scope.App);
            Assert.AreEqual(response.Status, Status.Ok);
        }

        [Test]
        public void PlacesAddWhenAsyncAndTimeoutTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = Guid.NewGuid().ToString("N"),
                Types = new[] { PlaceLocationType.Street_Address },
                Location = new Location(55.664425, 12.502264),
                Accuracy = 50,
                PhoneNumber = "+45 00000000",
                Address = "MyAddress",
                Website = "http://www.google.com",
                Language = Language.English
            };

            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GooglePlaces.Add.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
                Assert.IsNull(result);
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "One or more errors occurred.");

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(innerException.GetType(), typeof(TaskCanceledException));
            Assert.AreEqual(innerException.Message, "A task was canceled.");
        }

        [Test]
        public void PlacesAddWhenAsyncAndCancelledTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = Guid.NewGuid().ToString("N"),
                Types = new[] { PlaceLocationType.Street_Address },
                Location = new Location(55.664425, 12.502264),
                Accuracy = 50,
                PhoneNumber = "+45 00000000",
                Address = "MyAddress",
                Website = "http://www.google.com",
                Language = Language.English
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.Add.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesAddWhenInvalidKeyTest()
        {
            var request = new PlacesAddRequest
            {
                Key = "test",
                Name = Guid.NewGuid().ToString("N"),
                Types = new[] { PlaceLocationType.Street_Address },
                Location = new Location(55.664425, 12.502264),
                Accuracy = 50,
                PhoneNumber = "+45 00000000",
                Address = Guid.NewGuid().ToString("N"),
                Website = "http://www.google.com",
                Language = Language.English
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Add.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("The provided API key is invalid.", innerException.Message);
        }

        [Test]
        public void PlacesAddWhenLanguageTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = Guid.NewGuid().ToString("N"),
                Types = new[] { PlaceLocationType.Street_Address },
                Location = new Location(55.664425, 12.502264),
                Accuracy = 50,
                PhoneNumber = "+45 00000000",
                Address = Guid.NewGuid().ToString("N"),
                Website = "http://www.google.com",
                Language = Language.Arabic
            };
            var response = GooglePlaces.Add.Query(request);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.PlaceId);
            Assert.AreEqual(response.Scope, Scope.App);
            Assert.AreEqual(response.Status, Status.Ok);

            var request2 = new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId = response.PlaceId
            };

            var response2 = GooglePlaces.Details.Query(request2);

            Assert.IsNotNull(response2);
            Assert.AreEqual(Status.Ok, response2.Status);
            Assert.AreEqual(response2.Result.Name, request.Name);
            Assert.AreEqual(response2.Result.Website, request.Website);
            Assert.AreEqual(response2.Result.FormattedAddress, request.Address);
            Assert.AreEqual(response2.Result.FormattedPhoneNumber, request.PhoneNumber);
            Assert.AreEqual(response2.Result.Geometry.Location.Latitude, request.Location.Latitude);
            Assert.AreEqual(response2.Result.Geometry.Location.Longitude, request.Location.Longitude);

            Assert.AreEqual(Scope.App, response2.Result.Scope);
            Assert.AreEqual(response2.Result.PlaceId, response.PlaceId);
            Assert.AreEqual(PlaceLocationType.Street_Address, response2.Result.Types.FirstOrDefault());
        }

        [Test]
        public void PlacesAddWhenKeyIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = null,
                Name = "test",
                Location = new Location(0, 0),
                Types = new[] { PlaceLocationType.Street_Address }
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void PlacesAddWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesAddRequest
            {
                Key = string.Empty,
                Name = "test",
                Location = new Location(0, 0),
                Types = new[] { PlaceLocationType.Street_Address }
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void PlacesAddWhenNameIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Name is required");
        }

        [Test]
        public void PlacesAddWhenNameIsStringEmptyTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Name is required");
        }

        [Test]
        public void PlacesAddWhenLocationIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Location = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Location is required");
        }

        [Test]
        public void PlacesAddWhenTypesIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Location = new Location(55.664425, 12.502264),
                Types = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Types is required. At least one type must be specified");
        }

        [Test]
        public void PlacesAddWhenTypesIsEmptyTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Location = new Location(55.664425, 12.502264),
                Types = new PlaceLocationType[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Types is required. At least one type must be specified");
        }
    }
}