using System.Collections.Generic;

namespace FluentDictionary
{
    /// <summary>
    /// Contains all methods for setting a certain value in the dictionary.
    /// </summary>
    public class FluentDictionarySetter
    {
        //Members
        private Dictionary<string, object> _dict;
        private bool valueWasSet = false;

        //Constructor for internal creation
        internal FluentDictionarySetter(Dictionary<string, object> dictionary) => _dict = dictionary;

        //internal dictionary access for setting the requested value in the dictionary
        internal FluentDictionarySetter Set(string key, object value)
        {
            if (_dict.ContainsKey(key))
            {
                _dict[key] = value;
                valueWasSet = true;
            }

            return this;
        }

        /// <summary>
        /// Always sets the passed key and its value to the dictionary if the key is contained.
        /// </summary>
        /// <param name="key">Key of the value the set</param>
        /// <param name="value">The new value to set</param>
        /// <returns></returns>
        public FluentDictionarySetter And(string key, object value)
        {
            return Set(key, value);
        }

        /// <summary>
        /// Sets the passed key and its value to the dictionary if the key is contained and no other value was set before 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public FluentDictionarySetter Or(string key, object value)
        {
            return valueWasSet ? this: Set(key, value);
        }
    }
}
