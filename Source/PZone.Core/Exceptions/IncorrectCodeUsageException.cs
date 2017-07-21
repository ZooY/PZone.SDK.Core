namespace PZone.Exceptions
{
    /// <summary>
    /// Ошибка использования компонентов кода.
    /// </summary>
    /// <remarks>
    /// Ошибочное использование классов и программных конструкций.
    /// </remarks>
    public class IncorrectCodeUsageException : CommonException
    {
        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        public IncorrectCodeUsageException(string message) : base(10000, message)
        {
        }
    }
}