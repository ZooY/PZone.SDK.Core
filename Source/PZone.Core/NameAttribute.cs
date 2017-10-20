using System;


namespace PZone
{
    /// <summary>
    /// Имя элемента.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class NameAttribute : Attribute
    {
        /// <summary>
        /// Значение имени.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Конструор класса.
        /// </summary>
        /// <param name="name">Значение имени.</param>
        public NameAttribute(string name)
        {
            Name = name;
        }
    }
}