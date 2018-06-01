namespace PZone.Logging
{
    /// <summary>
    /// Конфигуратор журналирования.
    /// </summary>
    public interface ILoggerConfigurator
    {
        /// <summary>
        /// Флаг конфигуррирования журнализатора. Если <c>true</c> - журниализатор сконфигурирован.
        /// </summary>
        bool Configured { get; }


        /// <summary>
        /// Кунфигурирование журнализатора.
        /// </summary>
        /// <param name="configuration">Параметры конфигурирования.</param>
        void Configure(ILoggerConfiguration configuration);
    }
}