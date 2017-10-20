using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace PZone.Json
{
    /// <summary>
    /// Преобразование данных типа <see cref="WebException"/> в строку JSON.
    /// </summary>
    public class WebExceptionConverter : JsonConverter
    {
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var exception = value as WebException;
            if (exception == null)
            {
                return;
            }

            string response = null;
            if (exception.Response != null)
            {
                using (var stream = exception.Response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            response = reader.ReadToEnd();
                        }
                    }
                }
            }
            var data = new
            {
                ClassName = exception.GetType().FullName,
                Message = exception.Message,
                Data = exception.Data,
                InnerException = exception.InnerException,
                StackTraceString = exception.StackTrace,
                Source = exception.Source,
                Status = exception.Status,
                StatusName = exception.Status.ToString(),
                Response = response == null ? null : JsonConvert.DeserializeObject(response)
            };
            serializer.Serialize(writer, data);
        }


        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }


        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(WebException);
        }
    }
}