using PZone.Localization;


namespace PZone
{
    /// <summary>
    /// Единицы измерения времени.
    /// </summary>
    public enum TimeUnit
    {
        /// <summary>
        /// Неизвестная единица измерения.
        /// </summary>
        /// <remarks>
        /// Значение используется как значение по умолчанию.
        /// </remarks>
        [Name(typeof(Labels), "Unknown")]
        Unknown,

        /// <summary>
        /// Миллисекунда.
        /// </summary>
        [Name(typeof(Labels), "Millisecond")]
        Millisecond,

        /// <summary>
        /// Секунда.
        /// </summary>
        [Name(typeof(Labels), "Second")]
        Second,

        /// <summary>
        /// Минута.
        /// </summary>
        [Name(typeof(Labels), "Minute")]
        Minute,

        /// <summary>
        /// Час.
        /// </summary>
        [Name(typeof(Labels), "Hour")]
        Hour,

        /// <summary>
        /// День.
        /// </summary>
        [Name(typeof(Labels), "Day")]
        Day,

        /// <summary>
        /// Неделя.
        /// </summary>
        [Name(typeof(Labels), "Week")]
        Week,

        /// <summary>
        /// Месяц.
        /// </summary>
        [Name(typeof(Labels), "Month")]
        Month,

        /// <summary>
        /// Квартал.
        /// </summary>
        [Name(typeof(Labels), "Quarter")]
        Quarter,

        /// <summary>
        /// Год.
        /// </summary>
        [Name(typeof(Labels), "Year")]
        Year,

        /// <summary>
        /// Век.
        /// </summary>
        [Name(typeof(Labels), "Century")]
        Century
    }
}