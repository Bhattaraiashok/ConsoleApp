using System;
using System.Collections.Generic;
using ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_ADD()
        {
            Dictionary<string, List<string>> disc = new Dictionary<string, List<string>>();
            MyDictionary _dictionary = new MyDictionary();
            _dictionary.Command = "ADD";
            _dictionary.ReadKey = "foo";
            _dictionary.ReadValue = new List<string>();
            _dictionary.ReadValue.Add("bar");
            _dictionary.ReadAllCommand="ADD foo bar".Split(new[] { ' ' });
            _dictionary.AssignedTo = "key value";
            
           ConsoleApp.Program.Add(disc, _dictionary);

            List<string> listOfValues = new List<string>();
            disc.TryGetValue(_dictionary.ReadKey, out listOfValues);

            // positive test
            Assert.AreEqual(listOfValues[0], "bar");

            //nagative test
            Assert.AreNotEqual(listOfValues[0], "bad");

            // now lets try to add same foo bar again
            ConsoleApp.Program.Add(disc, _dictionary);

            var listOfValue = listOfValues.FindAll(x => x == "bar");

            // it should not add two same value twice 
            Assert.AreNotEqual(listOfValue.Count, 2);

            // add different value to same key foo
            _dictionary.ReadValue.Add("baz");
            ConsoleApp.Program.Add(disc, _dictionary);

            listOfValue = listOfValues.FindAll(x => x == "baz");

            // it should add value on same key 
            Assert.AreEqual(listOfValue.Count, 1);
        }

    }
}
