using System;


namespace PZone.Logging
{
    /// <summary>
    /// Базовый класс журнализатора.
    /// </summary>
    public abstract class LoggerBase : ILogger
    {
        /// <inheritdoc />
        public IInternalLogger InternalLogger { get; }


        /// <summary>
        /// Идентификатор отслеживания.
        /// </summary>
        public Guid CorrelationId { get; }


        /// <summary>
        /// Конструор класса.
        /// </summary>
        protected LoggerBase()
        {
            CorrelationId = Guid.NewGuid();
            InternalLogger = new ListInternalLogger(this);
        }


        /// <inheritdoc />
        public void Debug(string message)
        {
            WriteToLog(LogLevel.Debug, message, null, null);
        }


        /// <inheritdoc />
        public void Debug(string message, object data)
        {
            WriteToLog(LogLevel.Debug, message, data, null);
        }


        /// <inheritdoc />
        public void Info(string message)
        {
            WriteToLog(LogLevel.Info, message, null, null);
        }


        /// <inheritdoc />
        public void Info(string message, object data)
        {
            WriteToLog(LogLevel.Info, message, data, null);
        }


        /// <inheritdoc />
        public void Warn(string message)
        {
            WriteToLog(LogLevel.Warn, message, null, null);
        }


        /// <inheritdoc />
        public void Warn(Exception exception)
        {
            WriteToLog(LogLevel.Warn, exception.Message, null, exception);
        }


        /// <inheritdoc />
        public void Warn(string message, object data)
        {
            WriteToLog(LogLevel.Warn, message, data, null);
        }


        /// <inheritdoc />
        public void Warn(string message, Exception exception)
        {
            WriteToLog(LogLevel.Warn, message, null, exception);
        }


        /// <inheritdoc />
        public void Warn(string message, object data, Exception exception)
        {
            WriteToLog(LogLevel.Warn, message, data, exception);
        }


        /// <inheritdoc />
        public void Error(string message)
        {
            WriteToLog(LogLevel.Error, message, null, null);
        }


        /// <inheritdoc />
        public void Error(Exception exception)
        {
            WriteToLog(LogLevel.Error, exception.Message, null, exception);
        }


        /// <inheritdoc />
        public void Error(string message, object data)
        {
            WriteToLog(LogLevel.Error, message, data, null);
        }


        /// <inheritdoc />
        public void Error(string message, Exception exception)
        {
            WriteToLog(LogLevel.Error, message, null, exception);
        }


        /// <inheritdoc />
        public void Error(string message, object data, Exception exception)
        {
            WriteToLog(LogLevel.Error, message, data, exception);
        }


        /// <inheritdoc />
        public void Fatal(string message)
        {
            WriteToLog(LogLevel.Fatal, message, null, null);
        }


        /// <inheritdoc />
        public void Fatal(Exception exception)
        {
            WriteToLog(LogLevel.Fatal, exception.Message, null, exception);
        }


        /// <inheritdoc />
        public void Fatal(string message, object data)
        {
            WriteToLog(LogLevel.Fatal, message, data, null);
        }


        /// <inheritdoc />
        public void Fatal(string message, Exception exception)
        {
            WriteToLog(LogLevel.Fatal, message, null, exception);
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