namespace PZone.Logging
{
    /// <summary>
    /// Параметры журнализатора.
    /// </summary>
    public interface ILoggerConfiguration
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