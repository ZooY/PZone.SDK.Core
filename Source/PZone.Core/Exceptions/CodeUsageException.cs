namespace PZone.Exceptions
{
    /// <summary>
    /// Ошибка использования компонентов кода.
    /// </summary>
    /// <remarks>
    /// Ошибочное использование классов и программных конструкций.
    /// </remarks>
    public class CodeUsageException : CommonException
    {
        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        public CodeUsageException(string message) : base(10000, message)
        {
        }
    }
}