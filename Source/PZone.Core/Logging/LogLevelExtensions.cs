using System.Diagnostics;


namespace PZone.Logging
{
    /// <summary>
    /// Расширение функционала перечисления <see cref="LogLevel"/>.
    /// </summary>
    public static class LogLevelExtensions
    {
        /// <summary>
        /// Приведение значения преечисления к значению типа <see cref="EventLogEntryType"/>.
        /// </summary>
        /// <param name="logLevel">Значение перечисления <see cref="LogLevel"/>.</param>
        /// <returns>
        /// Метод возвращает значение перечисления типа <see cref="EventLogEntryType"/>.
        /// </returns>
        public static EventLogEntryType ToEventLogEntryType(this LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Off:
                case LogLevel.Debug:
                case LogLevel.Info:
                    return EventLogEntryType.Information;
                case LogLevel.Warn:
                    return EventLogEntryType.Warning;
                case LogLevel.Error:
                case LogLevel.Fatal:
                    return EventLogEntryType.Error;
                default:
                    return EventLogEntryType.Information;
            }
        }
    }
}