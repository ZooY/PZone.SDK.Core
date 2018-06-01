using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PZone.Json;


namespace PZone.Logging
{
    /// <summary>
    /// Базовый класс журнализатора.
    /// </summary>
    public abstract class LoggerBase : ILogger
    {
        /// <inheritdoc />
        public IInternalLogger InternalLogger { get; }

        /// <inheritdoc />
        public ILoggerSettings Settings { get; }

        /// <summary>
        /// Идентификатор отслеживания.
        /// </summary>
        public Guid CorrelationId { get; }


        /// <summary>
        /// Конструор класса.
        /// </summary>
        /// <param name="settings">Настройки журналирования.</param>
        protected LoggerBase(ILoggerSettings settings)
        {
            Settings = settings;
            CorrelationId = Guid.NewGuid();
            InternalLogger = new ListInternalLogger(this);
        }


        /// <inheritdoc />
        public void Debug(string message)
        {
            Debug(message, null);
        }


        /// <inheritdoc />
        public void Debug(string message, object data)
        {
            WriteToLog(LogLevel.Debug, message, data, null);
        }


        /// <inheritdoc />
        public void Info(string message)
        {
            Info(message, null);
        }


        /// <inheritdoc />
        public void Info(string message, object data)
        {
            WriteToLog(LogLevel.Info, message, data, null);
        }


        /// <inheritdoc />
        public void Warn(string message)
        {
            Warn(message, null);
        }


        /// <inheritdoc />
        public void Warn(Exception exception)
        {
            Warn(exception.Message, null, null);
        }


        /// <inheritdoc />
        public void Warn(string message, object data)
        {
            Warn(message, data, null);
        }


        /// <inheritdoc />
        public void Warn(string message, Exception exception)
        {
            Warn(message, null, exception);
        }


        /// <inheritdoc />
        public void Warn(string message, object data, Exception exception)
        {
            WriteToLog(LogLevel.Warn, message, data, exception);
        }


        /// <inheritdoc />
        public void Error(string message)
        {
            Error(message, null, null);
        }


        /// <inheritdoc />
        public void Error(Exception exception)
        {
            Error(exception.Message, null, exception);
        }


        /// <inheritdoc />
        public void Error(string message, object data)
        {
            Error(message, data, null);
        }


        /// <inheritdoc />
        public void Error(string message, Exception exception)
        {
            Error(exception.Message, null, exception);
        }


        /// <inheritdoc />
        public void Error(string message, object data, Exception exception)
        {
            WriteToLog(LogLevel.Error, message, data, exception);
        }


        /// <inheritdoc />
        public void Fatal(string message)
        {
            Fatal(message, null, null);
        }


        /// <inheritdoc />
        public void Fatal(Exception exception)
        {
            Fatal(exception.Message, null, exception);
        }


        /// <inheritdoc />
        public void Fatal(string message, object data)
        {
            Fatal(message, data, null);
        }


        /// <inheritdoc />
        public void Fatal(string message, Exception exception)
        {
            Fatal(message, null, exception);
        }


        /// <inheritdoc />
        public void Fatal(string message, object data, Exception exception)
        {
            WriteToLog(LogLevel.Fatal, message, data, exception);
        }


        /// <summary>
        /// Метод непосредственной записи в журнал.
        /// </summary>
        /// <param name="level">Уровень журналирования.</param>
        /// <param name="message">Заголовок сообщения.</param>
        /// <param name="data">Данные сообщения.</param>
        /// <param name="exception">Данные исключения.</param>
        protected abstract void WriteToLog(LogLevel level, string message, object data, Exception exception);
    }
}