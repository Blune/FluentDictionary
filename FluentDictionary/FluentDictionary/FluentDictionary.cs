using System;
using System.Collections.Generic;

namespace FluentDictionary
{
    /// <summary>
    /// Allows to access a dictionary with fluent methods.
    /// </summary>
    public class FluentDictionary
    {
        private readonly Dictionary<string, object> resultDictionary;
        private FluentDictionary(Dictionary<string, object> results) => resultDictionary = results ?? throw new ArgumentNullException("the passed dictionary was null");
        
        /// <summary>
        /// Creates a FluentDictionary for the passed dictionary.
        /// </summary>
        /// <param name="dict">The dictionary for getting and setting value. Is not allowed to be null</param>
        /// <returns></returns>
        public static FluentDictionary For(Dictionary<string, object> dict) => new FluentDictionary(dict);

        #region Getter

        /// <summary>
        /// Get a value from the dictionary.
        /// </summary>
        /// <param name="key">The key for the value</param>
        /// <returns></returns>
        public FluentDictionaryGetter Get(string key) => new FluentDictionaryGetter(resultDictionary).Get(key);

        /// <summary>
        /// Get a value from the dictionary.
        /// </summary>
        /// <param name="key">The enum key for the value</param>
        /// <returns></returns>
        public FluentDictionaryGetter Get<Enum>(Enum key) => new FluentDictionaryGetter(resultDictionary).Get(key.ToString());

        #endregion

        #region Setter

        /// <summary>
        /// Set a value to the dictionary
        /// </summary>
        /// <param name="key">The key for storing the value</param>
        /// <param name="value">The value to store</param>
        /// <returns></returns>
        public FluentDictionarySetter Set(string key, object value) => new FluentDictionarySetter(resultDictionary).Set(key, value);

        /// <summary>
        /// Set a value to the dictionary
        /// </summary>
        /// <param name="key">The enum key for storing the value</param>
        /// <param name="value">The value to store</param>
        /// <returns></returns>
        public FluentDictionarySetter Set(Enum key, object value) => new FluentDictionarySetter(resultDictionary).Set(key.ToString(), value);

        #endregion
    }
}
