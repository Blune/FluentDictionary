using System.Collections.Generic;

namespace FluentDictionary
{
    /// <summary>
    /// Contains all methods for receiving a certain value from the dictionary.
    /// </summary>
    public class FluentDictionaryGetter
    {
        //Members
        private readonly Dictionary<string, object> _dict;
        private object _currentValue;

        //Constructor for internal creation
        internal FluentDictionaryGetter(Dictionary<string, object> dictionary) => _dict = dictionary;

        //internal dictionary acess for getting the first value of the dictionary.
        internal FluentDictionaryGetter Get(string key)
        {
            if (_currentValue == null)
            {
                _dict.TryGetValue(key, out object value);
                _currentValue = _currentValue ?? value;
            }
            return this;
        }

        /// <summary>
        /// Returns the first value for the passed string key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns></returns>
        public FluentDictionaryGetter Or(string key)
        {
            return Get(key);
        }

        /// <summary>
        /// Returns the first value for the passed enum key.
        /// </summary>
        /// <typeparam name="Enum"></typeparam>
        /// <param name="key">The enum key of the value to get.</param>
        /// <returns></returns>
        public FluentDictionaryGetter Or<Enum>(Enum key)
        {
            return Or(key.ToString());
        }

        /// <summary>
        /// Casts the first found value to the desired type or returns the passed default value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="defaultValue">The default value that is returned if no value was found for a key in the dictionary</param>
        /// <returns></returns>
        public T? As<T>(T? defaultValue = null) where T : struct => (T?)_currentValue ?? defaultValue;
    }
}
