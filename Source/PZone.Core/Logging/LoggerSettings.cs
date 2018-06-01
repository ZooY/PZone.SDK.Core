namespace PZone.Logging
{
    /// <summary>
    /// Настройки журнализатора.
    /// </summary>
    public class LoggerConfiguration : ILoggerConfiguration
    {
        /// <inheritdoc />
        public string SystemId { get; set; }


        /// <inheritdoc />
        public string SystemInstanceId { get; set; }
    }
}