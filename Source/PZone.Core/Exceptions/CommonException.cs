using System;


namespace PZone.Exceptions
{
    /// <summary>
    /// Общая ошибка.
    /// </summary>
    /// <remarks>
    /// <para>Данный тип ошибки используется в случае отсутсвия более подходящего типа ошибок.</para>
    /// <para>Код ошибки: 0.</para>
    /// </remarks>
    public class CommonException : Exception
    {
        /// <summary>
        /// Код ошибки.
        /// </summary>
        public int Code => HResult;


        /// <summary>
        /// Технические подробности ошибки.
        /// </summary>
        public string Details { get; protected set; }


        /// <summary>
        /// Возможные варианты решения проблемы для пользователя системы.
        /// </summary>
        public string[] Solutions { get; set; } = { "Обратитесь в службу поддержки." };


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        public CommonException(string message) : this(0, message, null)
        {
        }

        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="code">Код ошибки</param>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        public CommonException(int code, string message) : this(code, message, null)
        {
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        /// <param name="exception">Вложенное исключение.</param>
        public CommonException(int code, string message, Exception exception) : this(code, message, null, exception)
        {
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        /// <param name="details">Технические подробности ошибки.</param>
        /// <param name="exception">Вложенное исключение.</param>
        public CommonException(int code, string message, string details, Exception exception) : base(message, exception)
        {
            HResult = code;
            Details = details;
        }
    }
}