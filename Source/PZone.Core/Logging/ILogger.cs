using System;


namespace PZone.Logging
{
    /// <summary>
    /// Журнализатор.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Внутренний журнализатор.
        /// </summary>
        IInternalLogger InternalLogger { get; }


        /// <summary>
        /// Настройки журналирования.
        /// </summary>
        ILoggerSettings Settings { get; }


        /// <summary>
        /// Идентификатор отслеживания.
        /// </summary>
        Guid CorrelationId { get; }


        #region Debug


        /// <summary>
        /// Запись в журнал отладочной информации.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        void Debug(string message);


        /// <summary>
        /// Запись в журнал отладочной информации.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        /// <param name="data">Объект для записи в журнал.</param>
        void Debug(string message, object data);


        #endregion


        #region Info


        /// <summary>
        /// Запись в журнал информационного сообщения.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        void Info(string message);


        /// <summary>
        /// Запись в журнал информационного сообщения.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        /// <param name="data">Объект для записи в журнал.</param>
        void Info(string message, object data);


        #endregion


        #region Warn


        /// <summary>
        /// Запись в журнал предупреждения.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        void Warn(string message);


        /// <summary>
        /// Запись в журнал предупреждения.
        /// </summary>
        /// <param name="exception">Данные исключения.</param>
        void Warn(Exception exception);


        /// <summary>
        /// Запись в журнал предупреждения.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        /// <param name="data">Объект для записи в журнал.</param>
        void Warn(string message, object data);


        /// <summary>
        /// Запись в журнал предупреждения.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        /// <param name="exception">Данные исключения.</param>
        void Warn(string message, Exception exception);


        /// <summary>
        /// Запись в журнал предупреждения.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        /// <param name="data">Объект для записи в журнал.</param>
        /// <param name="exception">Данные исключения.</param>
        void Warn(string message, object data, Exception exception);


        #endregion


        #region Error


        /// <summary>
        /// Запись в журнал сообщения об ошибке.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        void Error(string message);


        /// <summary>
        /// Запись в журнал сообщения об ошибке.
        /// </summary>
        /// <param name="exception">Данные исключения.</param>
        void Error(Exception exception);


        /// <summary>
        /// Запись в журнал сообщения об ошибке.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        /// <param name="data">Объект для записи в журнал.</param>
        void Error(string message, object data);


        /// <summary>
        /// Запись в журнал сообщения об ошибке.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        /// <param name="exception">Данные исключения.</param>
        void Error(string message, Exception exception);


        /// <summary>
        /// Запись в журнал сообщения об ошибке.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        /// <param name="data">Объект для записи в журнал.</param>
        /// <param name="exception">Данные исключения.</param>
        void Error(string message, object data, Exception exception);


        #endregion


        #region Fatal


        /// <summary>
        /// Запись в журнал критичной ошибки.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        void Fatal(string message);


        /// <summary>
        /// Запись в журнал критичной ошибки.
        /// </summary>
        /// <param name="exception">Данные исключения.</param>
        void Fatal(Exception exception);


        /// <summary>
        /// Запись в журнал критичной ошибки.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        /// <param name="data">Объект для записи в журнал.</param>
        void Fatal(string message, object data);


        /// <summary>
        /// Запись в журнал критичной ошибки.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        /// <param name="exception">Данные исключения.</param>
        void Fatal(string message, Exception exception);


        /// <summary>
        /// Запись в журнал критичной ошибки.
        /// </summary>
        /// <param name="message">Текстовое сообщение.</param>
        /// <param name="data">Объект для записи в журнал.</param>
        /// <param name="exception">Данные исключения.</param>
        void Fatal(string message, object data, Exception exception);


        #endregion
    }
}