using System;
using System.Net;
using System.Text;


namespace PZone.Net
{
    /// <summary>
    /// Расширение функциональности класса <see cref="WebHeaderCollection"/>.
    /// </summary>
    public static class WebHeaderCollectionExtensions
    {
        /// <summary>
        /// Установка заголовка с базовой авторизацией.
        /// </summary>
        /// <param name="headers">Коллекция заголовков.</param>
        /// <param name="userName">Имя пользователя.</param>
        /// <param name="userPass">Пароль пользователя.</param>
        public static void SetBasicAuthorization(this WebHeaderCollection headers, string userName, string userPass)
        {
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userName}:{userPass}"));
            headers.Set(HttpRequestHeader.Authorization, $"Basic {credentials}");
        }


        /// <summary>
        /// Установка заголовка с авторизацией по ключу.
        /// </summary>
        /// <param name="headers">Коллекция заголовков.</param>
        /// <param name="accessToken">Ключ авторизации.</param>
        public static void SetTokenAuthorization(this WebHeaderCollection headers, string accessToken)
        {
            headers.Set(HttpRequestHeader.Authorization, $"Bearer {accessToken}");
        }
    }
}