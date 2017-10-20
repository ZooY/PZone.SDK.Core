using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PZone.Json;


namespace PZone.Logging
{
    /// <summary>
    /// Базовый класс журнализатора.
    /// </summary>
    public abstract class LoggerBase : ILogger
    {
        /// <summary>
        /// Идентификатор приложения.
        /// </summary>
        protected string AppId { get; }


        /// <summary>
        /// Версия приложения.
        /// </summary>
        protected string AppVersion { get; }


        /// <summary>
        /// Идентификатор, объединяющий сообщения журнала в группу (например, в рамках одного запроса).
        /// </summary>
        protected string CorrelationId { get; }


        /// <summary>
        /// Конструор класса.
        /// </summary>
        /// <param name="correlationId">Идентификатор для связывания сообщения.</param>
        /// <param name="appId">Идентификатор приложения.</param>
        /// <param name="appVersion">Версия приложения.</param>
        protected LoggerBase(string correlationId, string appId, string appVersion)
        {
            CorrelationId = correlationId;
            AppId = appId;
            AppVersion = appVersion;
            InternalLogger = new ListInternalLogger(this);
        }


        /// <inheritdoc />
        public IInternalLogger InternalLogger { get; }


        /// <inheritdoc />
        public void Debug(string message)
        {
            Debug(message, null);
        }


        /// <inheritdoc />
        public void Debug(string message, object data)
        {
            WriteToLog(LogLevel.Debug, message, data, null);
        }


        /// <inheritdoc />
        public void Info(string message)
        {
            Info(message, null);
        }


        /// <inheritdoc />
        public void Info(string message, object data)
        {
            WriteToLog(LogLevel.Info, message, data, null);
        }


        /// <inheritdoc />
        public void Warn(string message)
        {
            Warn(message, null);
        }


        /// <inheritdoc />
        public void Warn(Exception exception)
        {
            Warn(exception.Message, null, null);
        }


        /// <inheritdoc />
        public void Warn(string message, object data)
        {
            Warn(message, data, null);
        }


        /// <inheritdoc />
        public void Warn(string message, Exception exception)
        {
            Warn(message, null, exception);
        }


        /// <inheritdoc />
        public void Warn(string message, object data, Exception exception)
        {
            WriteToLog(LogLevel.Warn, message, data, exception);
        }


        /// <inheritdoc />
        public void Error(string message)
        {
            Error(message, null, null);
        }


        /// <inheritdoc />
        public void Error(Exception exception)
        {
            Error(exception.Message, null, exception);
        }


        /// <inheritdoc />
        public void Error(string message, object data)
        {
            Error(message, data, null);
        }


        /// <inheritdoc />
        public void Error(string message, Exception exception)
        {
            Error(exception.Message, null, exception);
        }


        /// <inheritdoc />
        public void Error(string message, object data, Exception exception)
        {
            WriteToLog(LogLevel.Error, message, data, exception);
        }


        /// <inheritdoc />
        public void Fatal(string message)
        {
            Fatal(message, null, null);
        }


        /// <inheritdoc />
        public void Fatal(Exception exception)
        {
            Fatal(exception.Message, null, exception);
        }


        /// <inheritdoc />
        public void Fatal(string message, object data)
        {
            Fatal(message, data, null);
        }


        /// <inheritdoc />
        public void Fatal(string message, Exception exception)
        {
            Fatal(message, null, exception);
        }


        /// <inheritdoc />
        public void Fatal(string message, object data, Exception exception)
        {
            WriteToLog(LogLevel.Fatal, message, data, exception);
        }


        /// <summary>
        /// Метод непосредственной записи в журнал.
        /// </summary>
        /// <param name="level">Уровень журналирования.</param>
        /// <param name="message">Заголовок сообщения.</param>
        /// <param name="data">Данные сообщения.</param>
        /// <param name="exception">Данные исключения.</param>
        protected abstract void WriteToLog(LogLevel level, string message, object data, Exception exception);


        /// <summary>
        /// Формирование строки JSON по данным, переданным в журнализатор.
        /// </summary>
        /// <param name="appId">Идентификатор приложения.</param>
        /// <param name="appVersion">Версия приложения.</param>
        /// <param name="message">Заголовок сообщения.</param>
        /// <param name="data">Данные сообщения.</param>
        /// <param name="exception">Данные исключения.</param>
        /// <returns>
        /// Метод возвращает строку объекта JSON в формате 
        /// <code>
        /// {
        ///     AppId: &lt;app-id&gt;,
        ///     AppVersion: &lt;app-version&gt;,
        ///     Message: &lt;message&gt;,
        ///     Data: &lt;data&gt;,
        ///     Exception: &lt;exception&gt;
        /// }
        /// </code>
        /// Если какие то свойства объекта не заданы (равны <c>null</c>), то они не попадают в результат.
        /// </returns>
        protected static string BuildJson(string appId = null, string appVersion = null, string message = null, object data = null, Exception exception = null)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                Error = (s, e) => { e.ErrorContext.Handled = true; },
                Converters = new List<JsonConverter> { new WebExceptionConverter() }
            };
            try
            {
                // Пробуем сериализовать объект целиком.
                return JsonConvert.SerializeObject(new { AppId = appId, AppVersion = appVersion, Message = message, Data = data, Exception = exception }, jsonSettings);
            }
            catch
            {
                // Если сериализовать объект целиком не получилось, пробуем сериализовать его по частям.

                var messageBuilder = new StringBuilder();

                messageBuilder.AppendLine("{");

                messageBuilder.Append("    \"AppId\": " + JsonConvert.SerializeObject(appId));
                var hasPreviousData = !string.IsNullOrWhiteSpace(appId);

                if (hasPreviousData)
                    messageBuilder.AppendLine(",");
                messageBuilder.Append("    \"AppVersion\": " + JsonConvert.SerializeObject(appVersion));
                hasPreviousData = hasPreviousData || !string.IsNullOrWhiteSpace(appVersion);

                if (hasPreviousData)
                    messageBuilder.AppendLine(",");
                messageBuilder.Append("    \"Message\": " + JsonConvert.SerializeObject(message));
                hasPreviousData = hasPreviousData || !string.IsNullOrWhiteSpace(message);

                if (hasPreviousData)
                    messageBuilder.AppendLine(",");
                if (data != null)
                {
                    hasPreviousData = true;
                    try
                    {
                        messageBuilder.Append($"    \"Data\": {JsonConvert.SerializeObject(data, jsonSettings)}");
                    }
                    catch (Exception ex)
                    {
                        messageBuilder.Append($"    \"Data\": \"#ERROR#: Не удалось cериализовать объект данных типа {data.GetType().FullName}. {ex.Message}\"");
                    }
                }

                if (hasPreviousData)
                    messageBuilder.AppendLine(",");
                if (exception != null)
                {
                    try
                    {
                        messageBuilder.Append($"    \"Exception\": {JsonConvert.SerializeObject(exception, jsonSettings)}");
                    }
                    catch (Exception ex)
                    {
                        messageBuilder.Append($"    \"Exception\": \"#ERROR#: Не удалось cериализовать объект данных типа {exception.GetType().FullName}. {ex.Message}\"");
                    }
                }

                messageBuilder.AppendLine("");
                messageBuilder.AppendLine("}");

                return messageBuilder.ToString();
            }
        }
    }
}