using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Test2.Domain.Figures.Shapes;

namespace Test2.Infrastructure.JsonConverters
{
    public class ShapeConverter : JsonConverter<Shape>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, Shape value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override Shape ReadJson(JsonReader reader, Type objectType, Shape existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var target = GetShape(jObject.Value<string>("type"));
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        private Shape GetShape(string value)
        {
            return value switch
            {
                "Triangle" => new Triangle(),
                "Circle" => new Circle(),
                _ => throw new ArgumentException()
            };
        }
    }
}