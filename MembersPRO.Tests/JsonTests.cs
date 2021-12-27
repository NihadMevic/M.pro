using Xunit;
using MembersPRO.Controllers;
using Microsoft.AspNetCore.Mvc;
using FakeItEasy;
using Microsoft.Extensions.Logging;

namespace MembersPRO.Tests
{
    public class JsonTests
    {
        [Fact]
        public async void Serialize_CorrectData()
        {
            //Arrange
            var logger = A.Fake<ILogger<JsonConverter>>();
            var controller = new JsonConverter(logger);
            TestData testData = new TestData();

            //act
            var result = await controller.Serialize(testData.JsonToSerialize);

            //Assert
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(result);

            Assert.Equal(200, objectResponse.StatusCode);
            Assert.True(objectResponse.Value != null);
        }

        [Fact]
        public async void Serialize_InorrectData()
        {
            //Arrange
            var logger = A.Fake<ILogger<JsonConverter>>();
            var controller = new JsonConverter(logger);
            TestData testData = new TestData();

            //act
            var result = await controller.Serialize((JsonData)testData.JsonToFailSerialization);

            //Assert
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(result);
            Assert.True(200 != objectResponse.StatusCode);
        }
        [Fact]
        public async void Deserialize_CorrectData()
        {
            //Arrange
            var logger = A.Fake<ILogger<JsonConverter>>();
            var controller = new JsonConverter(logger);
            TestData testData = new TestData();

            //act
            var result = await controller.Deserialize(testData.JsonToDeserialize);

            //Assert
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(result);

            Assert.Equal(200, objectResponse.StatusCode);
            Assert.True(objectResponse.Value != null);
        }

        [Fact]
        public async void Deserialize_InorrectData()
        {
            //Arrange
            var logger = A.Fake<ILogger<JsonConverter>>();
            var controller = new JsonConverter(logger);
            TestData testData = new TestData();

            //act
            var result = await controller.Deserialize(testData.JsonToFailDeserialization);

            //Assert
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(result);
            Assert.True(200 != objectResponse.StatusCode);
        }
    }
}