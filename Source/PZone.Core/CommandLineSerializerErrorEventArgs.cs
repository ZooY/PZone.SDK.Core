using System;

namespace PZone
{
    /// <summary>
    /// Данные ошибки сериализации командной строки.
    /// </summary>
    public class CommandLineSerializerErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Содержимое ошибки.
        /// </summary>
        public Exception Error { get; }


        /// <summary>
        /// Флаг перехвата ошибки. Если <c>true</c> - ошибка считается обработанной и сериализатор не будет выбрасывать исключение.
        /// </summary>
        public bool Handled { get; set; }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="error">Содержимое ошибки.</param>
        public CommandLineSerializerErrorEventArgs(Exception error)
        {
            Error = error;
        }
    }
}