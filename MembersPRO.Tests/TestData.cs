using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MembersPRO.Tests
{
    public class TestData
    {
        public string JsonToDeserialize { get; set; }

        public object JsonToFailSerialization { get; set; }
        public string JsonToFailDeserialization { get; set; }

        public JsonData JsonToSerialize { get; set; }
        public TestData()
        {
            //serialize is from object to string
            //deserialize is from string to object
            this.JsonToDeserialize = TestJsonData.JsonToPass;
            this.JsonToFailDeserialization = TestJsonData.JsonToFail;
            this.JsonToSerialize = (JsonData?)System.Text.Json.JsonSerializer.Deserialize(this.JsonToDeserialize, typeof(JsonData));
            this.JsonToFailSerialization = null;
        }
    }
}
