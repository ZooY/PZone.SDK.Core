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
        /// <remarks>
        /// Идентификатор экземпляра системы уточняет, в какой конкретно версии или среде работает 
        /// журнализатор. Например, это может быть тестовая среда системы.
        /// </remarks>
        string SystemInstanceId { get; }
    }
}