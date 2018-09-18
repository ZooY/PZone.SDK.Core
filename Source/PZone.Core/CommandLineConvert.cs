using System;
using System.Collections.Generic;
using System.Linq;

namespace PZone
{
    /// <summary>
    /// Помощник сериализации/десериализации командной строки.
    /// </summary>
    public class CommandLineConvert
    {
        /// <summary>
        /// Десериализация командной строки, представленной в виде массива параметров.
        /// </summary>
        /// <param name="args">Массив параметров командной строки.</param>
        /// <typeparam name="T">Тип объекта, в который производится десериализация.</typeparam>
        /// <returns>
        /// Метод возвращает объект, десериализованный из командной строки.
        /// </returns>
        public static T DeserializeObject<T>(IEnumerable<string> args)
        {
            return DeserializeObject<T>(args, null);
        }


        /// <summary>
        /// Десериализация командной строки.
        /// </summary>
        /// <param name="value">Командная строка.</param>
        /// <typeparam name="T">Тип объекта, в который производится десериализация.</typeparam>
        /// <returns>
        /// Метод возвращает объект, десериализованный из командной строки.
        /// </returns>
        public static T DeserializeObject<T>(string value)
        {
            return DeserializeObject<T>(value, null);
        }


        /// <summary>
        /// Десериализация командной строки.
        /// </summary>
        /// <param name="value">Командная строка.</param>
        /// <param name="settings">Параметры сериализатора.</param>
        /// <typeparam name="T">Тип объекта, в который производится десериализация.</typeparam>
        /// <returns>
        /// Метод возвращает объект, десериализованный из командной строки.
        /// </returns>
        public static T DeserializeObject<T>(string value, CommandLineSerializerSettings settings)
        {
            return (T)DeserializeObject(value, typeof(T), settings);
        }


        /// <summary>
        /// Десериализация командной строки, представленной в виде массива параметров.
        /// </summary>
        /// <param name="args">Массив параметров командной строки.</param>
        /// <param name="settings">Параметры сериализатора.</param>
        /// <typeparam name="T">Тип объекта, в который производится десериализация.</typeparam>
        /// <returns>
        /// Метод возвращает объект, десериализованный из командной строки.
        /// </returns>
        public static T DeserializeObject<T>(IEnumerable<string> args, CommandLineSerializerSettings settings)
        {
            return (T)DeserializeObject(args, typeof(T), settings);
        }


        /// <summary>
        /// Десериализация командной строки.
        /// </summary>
        /// <param name="value">Командная строка.</param>
        /// <param name="type">Тип объекта, в который производится десериализация.</param>
        /// <param name="settings">Параметры сериализатора.</param>
        /// <returns>
        /// Метод возвращает объект, десериализованный из командной строки.
        /// </returns>
        public static object DeserializeObject(string value, Type type, CommandLineSerializerSettings settings)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            var serializer = new CommandLineSerializer(settings);
            return serializer.Deserialize(value, type);
        }


        /// <summary>
        /// Десериализация командной строки, представленной в виде массива параметров.
        /// </summary>
        /// <param name="args">Массив параметров командной строки.</param>
        /// <param name="type">Тип объекта, в который производится десериализация.</param>
        /// <param name="settings">Параметры сериализатора.</param>
        /// <returns>
        /// Метод возвращает объект, десериализованный из командной строки.
        /// </returns>
        public static object DeserializeObject(IEnumerable<string> args, Type type, CommandLineSerializerSettings settings)
        {
            var enumerable = args as string[] ?? args.ToArray();
            if (!enumerable.Any())
                return null;
            var serializer = new CommandLineSerializer(settings);
            return serializer.Deserialize(enumerable, type);
        }
    }
}