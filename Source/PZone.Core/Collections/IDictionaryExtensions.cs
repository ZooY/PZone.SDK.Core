using System.Collections.Generic;


namespace PZone.Collections
{
    /// <summary>
    /// Расширение функциональности словаря.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IDictionaryExtensions
    {
        /// <summary>
        /// Добавление элемента, если его нет в словаре или обновление элемента, если в словаре есть элемент с указанным ключем.
        /// </summary>
        /// <param name="dictionary">Экземпляр словаря.</param>
        /// <param name="key">Ключ элемента.</param>
        /// <param name="value">Значение элемента.</param>
        /// <typeparam name="TKey">Тип ключа элемента.</typeparam>
        /// <typeparam name="TValue">Тип значения элемента.</typeparam>
        public static void Upsert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }


        /// <summary>
        /// Добавление элемента, если его нет в словаре или обновление элемента, если в словаре есть элемент с указанным ключем.
        /// </summary>
        /// <param name="dictionary">Экземпляр словаря.</param>
        /// <param name="item">Элемента словаря.</param>
        /// <typeparam name="TKey">Тип ключа элемента.</typeparam>
        /// <typeparam name="TValue">Тип значения элемента.</typeparam>
        public static void Upsert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> item)
        {
            if (dictionary.ContainsKey(item.Key))
                dictionary[item.Key] = item.Value;
            else
                dictionary.Add(item);
        }
    }
}