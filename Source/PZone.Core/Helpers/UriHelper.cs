using System.Text.RegularExpressions;


namespace PZone.Helpers
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
    }
}