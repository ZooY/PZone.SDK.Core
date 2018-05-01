namespace PZone.Logging
{
    /// <summary>
    /// Уровень журналирования.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Журналирование отключено.
        /// </summary>
        Off,

        /// <summary>
        /// Отладочная информация.
        /// </summary>
        Debug,

        /// <summary>
        /// Информационное сообщение.
        /// </summary>
        Info,

        /// <summary>
        /// Предупреждающее сообщение.
        /// </summary>
        Warn,

        /// <summary>
        /// Сообщение об ошибке бизнес-логики.
        /// </summary>
        Error,

        /// <summary>
        /// Сообщение о фатальной ошибке приложения, из-за которого оно не может продолжать работу.
        /// </summary>
        Fatal
    }
}