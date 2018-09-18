using System;

namespace PZone
{
    /// <summary>
    /// Атрибут позволяет указать параметры свойства командной строки для сериализации/десериализации этого параметра.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class CommandLinePropertyAttribute : Attribute
    {
        /// <summary>
        /// Имя параметра, используемое в сериализации/десериализации.
        /// </summary>
        public string PropertyName { get; set; }


        /// <summary>
        /// Конструтор класа.
        /// </summary>
        public CommandLinePropertyAttribute()
        {
        }


        /// <summary>
        /// Конструтор класа.
        /// </summary>
        /// <param name="propertyName">Имя параметра, используемое в сериализации/десериализации.</param>
        public CommandLinePropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}