using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;


namespace PZone.Web
{
    //public class StringEnumConverter : QueryStringConverter
    //{
    //    public override string Write(object value)
    //    {
    //        if (value == null)
    //        {
    //            return null;
    //        }
    //        var @enum = (Enum)value;
    //        string enumText = @enum.ToString("G");
    //        if (char.IsNumber(enumText[0]) || (int)enumText[0] == 45)
    //        {
    //            if (!this.AllowIntegerValues)
    //                throw JsonSerializationException.Create((IJsonLineInfo)null, writer.ContainerPath, "Integer value {0} is not allowed.".FormatWith((IFormatProvider)CultureInfo.InvariantCulture, (object)enumText), (Exception)null);
    //            writer.WriteValue(value);
    //        }
    //        else
    //        {
    //            string enumName = EnumUtils.ToEnumName(@enum.GetType(), enumText, this.CamelCaseText);
    //            writer.WriteValue(enumName);
    //        }
    //    }
    //}


    /// <summary>
    /// Преобразование между объектом и строкой запроса.
    /// </summary>
    public class QueryStringConvert
    {
        /// <summary>
        /// Серилазиция объекта в строку запроса.
        /// </summary>
        /// <param name="value">Объект, который необходимо сериализовать.</param>
        /// <returns>
        /// Метод сериализует объект в строку запроса.
        /// </returns>
        public static string SerializeObject(object value)
        {
            var pairs = new List<string>();

            foreach (var property in value.GetType().GetProperties())
            {
                var stringValue = property.GetValue(value, null).ToString();
                stringValue = ReplaceCommaToDot(property, stringValue);
                pairs.Add(property.Name + "=" + HttpUtility.UrlEncode(stringValue));
            }

            return string.Join("&", pairs.ToArray());
        }


        private static string ReplaceCommaToDot(PropertyInfo property, string value)
        {
            return property.PropertyType.IsValueType ? value.Replace(',', '.') : value;
        }
    }
}