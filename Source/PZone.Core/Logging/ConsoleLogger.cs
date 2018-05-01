using System;


namespace PZone.Logging
{
    /// <summary>
    /// Журнализатор с выводом данных в консоль.
    /// </summary>
    /// <remarks>
    /// Журнализатор используется для тестирования и отладки.
    /// </remarks>
    public class ConsoleLogger : LoggerBase
    {
        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="correlationId">Идентификатор для связывания сообщения.</param>
        /// <param name="appId">Идентификатор приложения.</param>
        /// <param name="appVersion">Версия приложения.</param>
        public ConsoleLogger(string correlationId, string appId, string appVersion) : base(correlationId, appId, appVersion)
        {
        }


        /// <inheritdoc />
        protected override void WriteToLog(LogLevel level, string message, object data, Exception exception)
        {
            try
            {
                Console.WriteLine($"{level.ToString().ToUpper()} {DateTime.Now}");
                Console.WriteLine(BuildJson(message: message, data: data, exception: exception));
            }
            catch (Exception ex)
            {
                InternalLogger.Log(ex);
            }
        }
    }
}