namespace PZone.Logging
{
    /// <summary>
    /// Настройки журнализатора.
    /// </summary>
    public class LoggerSettings : ILoggerSettings
    {
        /// <inheritdoc />
        public string SystemId { get; set; }


        /// <inheritdoc />
        public string SystemInstanceId { get; set; }
    }
}