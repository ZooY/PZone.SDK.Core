using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PZone
{
    /// <summary>
    /// Сериализватор командной строки.
    /// </summary>
    public class CommandLineSerializer
    {
        /// <summary>
        /// Параметры сериализатора.
        /// </summary>
        public CommandLineSerializerSettings Settings { get; set; }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        public CommandLineSerializer() : this(null)
        {
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="settings">Параметры сериализатора.</param>
        public CommandLineSerializer(CommandLineSerializerSettings settings)
        {
            Settings = settings ?? new CommandLineSerializerSettings();
        }


        /// <summary>
        /// Десериализация командной строки.
        /// </summary>
        /// <param name="value">Командная строка.</param>
        /// <param name="type">Тип объекта, в который производится десериализация.</param>
        /// <returns>
        /// Метод возвращает объект, десериализованный из командной строки.
        /// </returns>
        public object Deserialize(string value, Type type)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            var args = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return Deserialize(args, type);
        }


        /// <summary>
        /// Десериализация командной строки, представленной в виде массива параметров.
        /// </summary>
        /// <param name="args">Массив параметров командной строки.</param>
        /// <param name="type">Тип объекта, в который производится десериализация.</param>
        /// <returns>
        /// Метод возвращает объект, десериализованный из командной строки.
        /// </returns>
        /// <exception cref="ArgumentException">Если не удалось привести значение к нужному типу и ошибка не перехвачена пользовательским
        /// кодом (значение <see cref="CommandLineSerializerErrorEventArgs.Handled"/> не установлено в <c>true</c>).</exception>
        public object Deserialize(IEnumerable<string> args, Type type)
        {
            var argsArray = args as string[] ?? args.ToArray();
            if (!argsArray.Any())
                return null;

            var propertyMap = new Dictionary<string, PropertyInfo>();
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                propertyMap.Add(property.Name, property);
                if (property.GetCustomAttributes(typeof(CommandLinePropertyAttribute), true).FirstOrDefault() is CommandLinePropertyAttribute attribute)
                    propertyMap.Add(attribute.PropertyName, property);
            }

            var typeInstance = Activator.CreateInstance(type);
            foreach (var arg in argsArray)
            {
                var argParts = arg.Split('=');
                var argName = argParts[0];
                var argValue = argParts[1];
                var property = propertyMap.ContainsKey(argName) ? propertyMap[argName] : null;
                if (property != null)
                {
                    object typedValue = null;
                    try
                    {
                        typedValue = Convert.ChangeType(argValue, property.PropertyType);
                    }
                    catch (Exception ex)
                    {
                        var error = new ArgumentException($"Unable to convert source property value \"{argValue}\" to type {property.PropertyType.FullName}", argName, ex);
                        var errorArgs = new CommandLineSerializerErrorEventArgs(error);
                        Settings.Error?.Invoke(this, errorArgs);
                        if (!errorArgs.Handled)
                            throw error;
                    }

                    if (typedValue != null)
                        property.SetValue(typeInstance, typedValue, null);
                }
            }

            return typeInstance;
        }
    }
}