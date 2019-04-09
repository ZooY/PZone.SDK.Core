using System.Collections.Generic;


namespace PZone.Logging
{
    /// <summary>
    /// Внутренний журнализатор для отслеживания проблем работы основного журнализатора с записью 
    /// сообщений в спсок в памяти.
    /// </summary>
    /// <remarks>
    /// <note type="caution">В журнале содержиться 100 последних сообщений.</note>
    /// </remarks>
    public class ListInternalLogger : IInternalLogger
    {
        private readonly List<object> _messages;


        /// <summary>
        /// Родительский журнализатор.
        /// </summary>
        public ILogger ParentLogger { get; }


        /// <summary>
        /// Флаг, показывающий включен ли внутренний журнал.
        /// </summary>
        public bool IsEnabled { get; set; }


        /// <summary>
        /// Сообщения журнала.
        /// </summary>
        public IEnumerable<object> Messages => _messages;


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="parentLog">Родительский журнализатор.</param>
        public ListInternalLogger(ILogger parentLog)
        {
            ParentLogger = parentLog;
            _messages = new List<object>();
        }


        /// <summary>
        /// Запись сообщения в журнализатор.
        /// </summary>
        /// <param name="data">Данные сообщения.</param>
        public void Log(object data)
        {
            if (!IsEnabled)
                return;
            if (_messages.Count > 100)
                _messages.RemoveAt(0);
            _messages.Add(data);
        }
    }
}