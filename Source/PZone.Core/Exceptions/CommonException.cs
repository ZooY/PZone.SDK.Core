using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PZone.Json;


namespace PZone.Exceptions
{
    /// <summary>
    /// Общая ошибка.
    /// </summary>
    /// <remarks>
    /// <para>Данный тип ошибки используется в случае отсутсвия более подходящего типа ошибок.</para>
    /// <para>Код ошибки: 0.</para>
    /// </remarks>
    public class CommonException : Exception
    {
        /// <summary>
        /// Код ошибки.
        /// </summary>
        public int Code => HResult;


        /// <summary>
        /// Технические подробности ошибки.
        /// </summary>
        public string Details { get; protected set; }


        /// <summary>
        /// Возможные варианты решения проблемы для пользователя системы.
        /// </summary>
        public string[] Solutions { get; set; } = { "Обратитесь в службу поддержки." };


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        public CommonException(string message) : this(message, null)
        {
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        /// <param name="exception">Вложенное исключение.</param>
        public CommonException(string message, Exception exception) : this(message, null, exception)
        {
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        /// <param name="data">Дополнительные данные по ошибке.</param>
        /// <param name="exception">Вложенное исключение.</param>
        public CommonException(string message, IDictionary<string, object> data, Exception exception) : this(0, message, null, data, exception)
        {
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="code">Код ошибки</param>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        public CommonException(int code, string message) : this(code, message, null)
        {
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        /// <param name="exception">Вложенное исключение.</param>
        public CommonException(int code, string message, Exception exception) : this(code, message, null, exception)
        {
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        /// <param name="details">Технические подробности ошибки.</param>
        /// <param name="exception">Вложенное исключение.</param>
        public CommonException(int code, string message, string details, Exception exception) : this(code, message, details, null, exception)
        {
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="message">Сообщение об ошибке для отображения пользователю.</param>
        /// <param name="details">Технические подробности ошибки.</param>
        /// <param name="data">Дополнительные данные по ошибке.</param>
        /// <param name="exception">Вложенное исключение.</param>
        public CommonException(int code, string message, string details, IDictionary<string, object> data, Exception exception) : base(message, exception)
        {
            HResult = code;
            Details = details;

            if (data == null || data.Count <= 0)
                return;
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                Error = (s, e) => { e.ErrorContext.Handled = true; },
                Converters = new List<JsonConverter> { new WebExceptionConverter() }
            };

            foreach (var dataItem in data)
            {
                if(dataItem.Value == null)
                {
                    exception.Data.Add(dataItem.Key, "<null>");
                    continue;
                }
                var dataItemType = dataItem.Value.GetType();
                if (dataItemType.IsValueType)
                {
                    exception.Data.Add(dataItem.Key, dataItem.Value);
                    continue;
                }
                try
                {
                    var json = JsonConvert.SerializeObject(dataItem.Value, jsonSettings);
                    exception.Data.Add(dataItem.Key, json);
                }
                catch (Exception ex)
                {
                    exception.Data.Add(dataItem.Key, $"#ERROR# Не удалось сериализовать объект типа {dataItemType.FullName}. {ex.Message}");
                }
            }
        }
    }
}