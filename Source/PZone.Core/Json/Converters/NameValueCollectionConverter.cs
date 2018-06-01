using System;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace PZone.Json.Converters
{
    /// <summary>
    /// Конвертер для сериализации типа <see cref="NameValueCollection"/>.
    /// </summary>
    /// <remarks>
    /// Без исползования конвертера объект типа <see cref="NameValueCollection"/> сериализуется в 
    /// виде массива с набором ключей коллекции.
    /// </remarks>
    public class NameValueCollectionConverter : JsonConverter
    {
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var collection = value as NameValueCollection;
            if (collection == null)
                return;

            var o = new JObject();
            foreach (var key in collection.AllKeys)
                o.Add(key, collection[key]);
            o.WriteTo(writer);
        }


        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }


        /// <inheritdoc />
        public override bool CanRead => false;


        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(NameValueCollection);
        }
    }
}