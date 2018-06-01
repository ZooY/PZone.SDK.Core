using System.Text;

namespace PZone.Security
{
    /// <summary>
    /// Методы для работы с алгоритмом MD5.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class MD5
    {
        /// <summary>
        /// Получение строки хеша MD5.
        /// </summary>
        /// <param name="str">Входная строка.</param>
        /// <returns>
        /// <para>Метод возвращает строку хеша, полученную из входной строки.</para>
        /// <note>Строка хеша возвращается содержит символы в нижнем регистре.</note>
        /// </returns>
        public static string HashString(string str)
        {
            var hash = System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str));
            var stringBuilder = new StringBuilder();
            foreach (var t in hash)
                stringBuilder.Append(t.ToString("x2"));
            return stringBuilder.ToString();
        }
    }
}