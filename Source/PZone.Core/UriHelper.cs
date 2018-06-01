using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


namespace PZone
{
    /// <summary>
    /// Хелпер для работы с URI.
    /// </summary>
    public static class UriHelper
    {
        /// <summary>
        /// Формирование URI объединением нескольих строк.
        /// </summary>
        /// <param name="parts">Части URI.</param>
        /// <returns>Возвращает строку URI, полученную путем объединения нескольких строк.</returns>
        /// <remarks>
        /// <example>
        /// <code>
        /// var actual = UriHelper.Combine("http://domain.com/", "/path/", "/path/", "/", "/file.htm");
        /// // actual = "http://domain.com/path/path/file.htm"
        /// </code>
        /// </example>
        /// </remarks>
        public static string Combine(params string[] parts)
        {
            if (parts == null || parts.Length < 1)
                return null;
            return new Regex("(?<!:)[/]{2,}").Replace(string.Join("/", parts), "/");
        }


        /// <summary>
        /// Добавялет к основному адресу строку с параметрами.
        /// </summary>
        /// <param name="uri">Основной адрес.</param>
        /// <param name="parameters">Список параметров.</param>
        /// <returns>
        /// Метод возввращает новый URI, сформированный из основного адреса и добавленных к нему параметров.
        /// </returns>
        public static string AppendParameters(string uri, Dictionary<string, object> parameters)
        {
            if (parameters == null || parameters.Count < 1)
                return uri;
            return uri + "?" + string.Join("&", parameters.Select(dataItem => $"{dataItem.Key}={CreateParameter(dataItem.Value)}"));
        }


        private static string CreateParameter(object obj)
        {
            if (obj == null)
                return string.Empty;
            string value;
            if (obj is DateTime)
                value = ((DateTime)obj).ToString("s");
            else
                value = obj.ToString();
            return HttpUtility.UrlEncode(value);
        }
    }
}