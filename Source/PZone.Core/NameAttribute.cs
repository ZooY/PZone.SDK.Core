using System;
using System.Resources;


namespace PZone
{
    /// <summary>
    /// Имя элемента.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class NameAttribute : Attribute
    {
        private Type _resourceType;
        private string _resourceName;
        private Lazy<ResourceManager> _resource;
        private string _name;


        /// <summary>
        /// Значение имени.
        /// </summary>
        public string Name
        {
            get
            {
                return _resourceType == null ? _name : _resource.Value.GetString(_resourceName);
            }
            set
            {
                _name = value;
                _resourceType = null;
                _resourceName = null;
                _resource = null;
            }
        }


        /// <summary>
        /// Конструор класса.
        /// </summary>
        /// <param name="name">Значение имени.</param>
        public NameAttribute(string name)
        {
            _name = name;
        }


        /// <summary>
        /// Конструор класса с получением строки имени из ресурса.
        /// </summary>
        /// <param name="resourceType">Тип ресурса.</param>
        /// <param name="resourceName">Имя свойства ресурса.</param>
        public NameAttribute(Type resourceType, string resourceName)
        {
            if (resourceType == null || resourceName == null)
                return;
            _resourceType = resourceType;
            _resourceName = resourceName;
            _resource = new Lazy<ResourceManager>(() => new ResourceManager(resourceType));
        }
    }
}