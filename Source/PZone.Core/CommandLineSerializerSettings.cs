using System;

namespace PZone
{
    /// <summary>
    /// Параметры сериализватора командной строки.
    /// </summary>
    public class CommandLineSerializerSettings
    {
        /// <summary>
        /// Событие ошибки сериализации/десериализации свойства.
        /// </summary>
        public EventHandler<CommandLineSerializerErrorEventArgs> Error { get; set; }
    }
}