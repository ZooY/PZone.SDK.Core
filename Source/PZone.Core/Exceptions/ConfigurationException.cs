using System;


namespace PZone.Exceptions
{
    /// <summary>
    /// Ошибка использования компонентов кода.
    /// </summary>
    /// <remarks>
    /// Ошибочное использование классов и программных конструкций.
    /// </remarks>
    public class ConfigurationException : CommonException
    {
        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        public ConfigurationException(string message) : base(20000, message)
        {
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="code">Код ошибки</param>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        public ConfigurationException(int code, string message) : base(code, message)
        {
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        /// <param name="exception">Вложенное исключение.</param>
        public ConfigurationException(int code, string message, Exception exception) : base(code, message, exception)
        {
        }
    }
}