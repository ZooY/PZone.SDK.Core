namespace PZone.Web
{
    public abstract class QueryStringConverter
    {
        public abstract string Write(object value);

        // public abstract object Read(JsonReader reader, Type objectType, object existingValue);
    }
}