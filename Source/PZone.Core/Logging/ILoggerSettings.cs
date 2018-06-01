namespace PZone.Logging
{
    /// <summary>
    /// Настройки журнализатора.
    /// </summary>
    public interface ILoggerSettings
    {
        /// <summary>
        /// Идентификатор системы.
        /// </summary>
        string SystemId { get; }


        /// <summary>
        /// Идентификатор экземпляра системы.
        /// </summary>
        string SystemInstanceId { get; }
    }
}