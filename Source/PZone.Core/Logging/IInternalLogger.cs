using System.Collections.Generic;


namespace PZone.Logging
{
    /// <summary>
    /// Внутренний журнализатор для отслеживания проблем работы основного журнализатора.
    /// </summary>
    public interface IInternalLogger
    {
        /// <summary>
        /// Родительский журнализатор.
        /// </summary>
        ILogger ParentLogger { get; }

        /// <summary>
        /// Флаг, показывающий включен ли внутренний журнал.
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// Сообщения журнала.
        /// </summary>
        IEnumerable<object> Messages { get; }


        /// <summary>
        /// Запись сообщения в журнализатор.
        /// </summary>
        /// <param name="data">Данные сообщения.</param>
        void Log(object data);
    }
}