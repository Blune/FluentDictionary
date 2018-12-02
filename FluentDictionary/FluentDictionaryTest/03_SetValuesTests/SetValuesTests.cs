using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FluentDictionaryTest._03_SetValuesTests
{
    [TestClass]
    public class SetValueTests
    {
        private Dictionary<string, object> resultDictionary;

        [TestInitialize]
        public void ResetTestDictionary()
        {
            resultDictionary = new Dictionary<string, object>()
            {
                {"Key1", 1.0},
                {"Key2", 2.0},
                {"Key3", 3.0},
                {"Key4", 4.0},
                {"Key5", 5.0},
                {"Key6", 6.0},
                {"Key7", 7.0},
                {"Key8", 8.0},
                {"Nothing", null},
            };
        }

        [TestMethod]
        public void SetSingleValueForDictionary()
        {
            FluentDictionary.FluentDictionary
                .For(resultDictionary)
                .Set("Key1", 123);

            Assert.AreEqual(123, resultDictionary["Key1"]);
        }

        [TestMethod]
        public void SetTwoValuesForDicionary()
        {
            FluentDictionary.FluentDictionary
                .For(resultDictionary)
                .Set("Key1", 123)
                .And("Key2", 456);

            Assert.AreEqual(123, resultDictionary["Key1"]);
            Assert.AreEqual(456, resultDictionary["Key2"]);
        }
        
        [TestMethod]
        public void UpdateFirstValueForDictionary()
        {
            FluentDictionary.FluentDictionary
                .For(resultDictionary)
                .Set("Key1", 123)
                .Or("Key2", 123);

            Assert.AreEqual(123, resultDictionary["Key1"]);
            Assert.AreEqual(2.0, resultDictionary["Key2"]);
        }
    }
}
