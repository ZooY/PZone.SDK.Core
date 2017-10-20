using System;
using System.ComponentModel;
using System.Linq;


namespace PZone
{
    /// <summary>
    /// Расширение стандартной функциональности значений перечислений.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Получение значения атрибута <see cref="DescriptionAttribute"/>.
        /// </summary>
        /// <param name="item">Значение перечисления.</param>
        /// <returns>
        /// Метод возвращает значение свойства <see cref="DescriptionAttribute.Description"/> атриубта <see cref="DescriptionAttribute"/>, определенного для значения перечисления.
        /// Если атрибут не определён, возвращается <c>null</c>.
        /// </returns>
        public static string GetDescription(this Enum item)
        {
            return item.GetAttribute<DescriptionAttribute>()?.Description;
        }


        /// <summary>
        /// Получение значения атрибута <see cref="NameAttribute"/>.
        /// </summary>
        /// <param name="item">Значение перечисления.</param>
        /// <returns>
        /// Метод возвращает значение свойства <see cref="NameAttribute.Name"/> атриубта <see cref="NameAttribute"/>, определенного для значения перечисления.
        /// Если атрибут не определён, возвращается <c>null</c>.
        /// </returns>
        public static string GetName(this Enum item)
        {
            return item.GetAttribute<NameAttribute>()?.Name;
        }


        /// <summary>
        /// Получение атрибута, определенного для значения перечисления.
        /// </summary>
        /// <param name="item">Значение перечисления.</param>
        /// <returns>
        /// Метод возвращает указанный атрибут, если он определен для значения перечисления.
        /// Если атрибут не определён, возвращается <c>null</c>.
        /// </returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum item)
        {
            var fi = item.GetType().GetField(item.ToString());
            var attributes = fi.GetCustomAttributes(typeof(TAttribute), false);
            return (TAttribute)attributes.FirstOrDefault();
        }
    }
}