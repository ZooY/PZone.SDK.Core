using System;


namespace PZone.Web
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class QueryStringConverterAttribute : Attribute
    {
        private readonly Type _converterType;

        public Type ConverterType => _converterType;

        public object[] ConverterParameters { get; }


        public QueryStringConverterAttribute(Type converterType)
        {
            if (converterType == null)
                throw new ArgumentNullException(nameof(converterType));
            this._converterType = converterType;
        }


        public QueryStringConverterAttribute(Type converterType, params object[] converterParameters)
            : this(converterType)
        {
            this.ConverterParameters = converterParameters;
        }
    }
}