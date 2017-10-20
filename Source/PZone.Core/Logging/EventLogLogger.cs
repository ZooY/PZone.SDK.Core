using System;
using System.Diagnostics;


namespace PZone.Logging
{
    /// <summary>
    /// Журнализатор, записывающий сообщения в Windows Event Log.
    /// </summary>
    public class EventLogLogger : LoggerBase
    {
        /// <summary>
        /// Экземпляр журнала Windows.
        /// </summary>
        protected EventLog EventLog { get; }


        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="correlationId">Идентификатор для связывания сообщения.</param>
        /// <param name="appId">Идентификатор приложения.</param>
        /// <param name="appVersion">Версия приложения.</param>
        /// <param name="eventLog">Экземпляр журнала Windows.</param>
        public EventLogLogger(string correlationId, string appId, string appVersion, EventLog eventLog) : base(correlationId, appId, appVersion)
        {
            EventLog = eventLog;
        }


        /// <inheritdoc />
        protected override void WriteToLog(LogLevel level, string message, object data, Exception exception)
        {
            try
            {
                EventLog.WriteEntry(BuildJson(AppId, AppVersion, message, data, exception), level.ToEventLogEntryType(), 0, 0);
            }
            catch (Exception ex)
            {
                InternalLogger.Log(ex);
            }
        }
    }
}