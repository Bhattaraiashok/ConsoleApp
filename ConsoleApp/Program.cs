using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class MyDictionary
    {
        public string ReadKey { get; set; }
        public List<string> ReadValue { get; set; }
        public bool IsError { get; set; }
    }

    public class OptionsEnum
    {
        public const string ADD = "0";
        public const string GetKeys = "1";
        public const string MEMBERS = "2";
        public const string REMOVE = "3";
        public const string REMOVEALL = "4";
        public const string CLEAR = "5";
        public const string KEYEXISTS = "6";
        public const string MEMBEREXISTS = "7";
        public const string ALLMEMBERS = "8";
        public const string ITEMS = "9";
    }
    public class Program
    {

        public static void Main(string[] args)
        {
            Dictionary<string, List<string>> disc = new Dictionary<string, List<string>>();
            try
            {
                // this is giving an option to user what they want to do next.
                Console.WriteLine("What you want to do next?");
                Console.WriteLine("\t0=ADD");
                Console.WriteLine("\t1=KEYS"); //added this so that it is easy to retrieve only keys
                Console.WriteLine("\t2=MEMBERS");
                Console.WriteLine("\t3=REMOVE");
                Console.WriteLine("\t4=REMOVEALL");
                Console.WriteLine("\t5=CLEAR");
                Console.WriteLine("\t6=KEYEXISTS");
                Console.WriteLine("\t7=MEMBEREXISTS");
                Console.WriteLine("\t8=ALLMEMBERS");
                Console.WriteLine("\t9=ITEMS");
                AskUser(disc);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Opps!!Something went wrong. Please try again. ERROR: {0}", ex.Message.ToString());
            }
        }

        // AskUser: let user decide what they want to do next.
        public static void AskUser(Dictionary<string, List<string>> disc)
        {
            MyDictionary _dictionary = new MyDictionary();
            _dictionary.ReadValue = new List<string>();

            Console.Write("please choose an option from above: ");

            var userText = Console.ReadLine();
            switch (userText)
            {
                case OptionsEnum.ADD:
                    Console.Write("> ADD  ");
                    AssignKeyValue("key value", out _dictionary);
                    if (!_dictionary.IsError)
                        Add(disc, _dictionary);
                    break;
                case OptionsEnum.GetKeys:
                    GetKeys(disc);
                    break;
                case OptionsEnum.MEMBERS:
                    Console.Write("> MEMBERS ");
                    AssignKeyValue("key", out _dictionary);
                    if (!_dictionary.IsError)
                        Members(disc, _dictionary);
                    break;
                case OptionsEnum.REMOVE:
                    Console.Write("> REMOVE ");
                    AssignKeyValue("key value", out _dictionary);
                    if (!_dictionary.IsError)
                        Remove(disc, _dictionary);
                    break;
                case OptionsEnum.REMOVEALL:
                    Console.Write("> REMOVEALL ");
                    AssignKeyValue("key", out _dictionary);
                    if (!_dictionary.IsError)
                        RemoveAll(disc, _dictionary);
                    break;
                case OptionsEnum.CLEAR:
                    Console.WriteLine("> CLEAR ");
                    Clear(disc);
                    break;
                case OptionsEnum.KEYEXISTS:
                    Console.Write("> KEYEXISTS ");
                    AssignKeyValue("key", out _dictionary);
                    if (!_dictionary.IsError)
                        KeyExists(disc, _dictionary);
                    break;
                case OptionsEnum.MEMBEREXISTS:
                    Console.Write("> MEMBEREXISTS ");
                    AssignKeyValue("key value", out _dictionary);
                    if (!_dictionary.IsError)
                        MemberExist(disc, _dictionary);
                    break;
                case OptionsEnum.ALLMEMBERS:
                    Console.WriteLine("> ALLMEMBERS");
                    ALLMembers(disc);
                    break;
                case OptionsEnum.ITEMS:
                    Return_AllItems(disc);
                    break;
            }

            Console.WriteLine("\n");
            AskUser(disc);
        }

        public static void AssignKeyValue(string assignedTo, out MyDictionary _dictionary)
        {
            _dictionary = new MyDictionary();
            _dictionary.ReadValue = new List<string>();
            var split = Console.ReadLine().Split(new[] { ' ' });
            if (assignedTo == "key")
            {
                _dictionary.ReadKey = split[0];
            }
            else
            {
                if (split.Count() > 1)
                {
                    _dictionary.ReadKey = split[0];
                    _dictionary.ReadValue.Add(split[1]);
                    _dictionary.IsError = false;
                }
                else
                {
                    _dictionary.IsError = true;
                    Console.WriteLine("Please enter key and value.");
                }
            }
        }

        public static void Add(IDictionary<string, List<string>> disc, MyDictionary _dictionary)
        {
            List<string> listOfValues = new List<string>();
            // check for key -if exist update the collection
            if (disc.ContainsKey(_dictionary.ReadKey))
            {
                disc.TryGetValue(_dictionary.ReadKey, out listOfValues);

                // check if user enters same/duplicate value for the given key
                var duplicateMember = listOfValues.Any(x => x.Contains(_dictionary.ReadValue[0]));
                if (!duplicateMember)
                {
                    listOfValues.Add(_dictionary.ReadValue[0]);
                    disc[_dictionary.ReadKey] = listOfValues;
                    Console.WriteLine(") Added");
                }
                else
                {
                    Console.WriteLine(") ERROR , Member already exist for key");
                }
            }
            else
            {
                disc.Add(new KeyValuePair<string, List<string>>(_dictionary.ReadKey, _dictionary.ReadValue));
                Console.WriteLine(") Added");
            }
        }

        public static void GetKeys(Dictionary<string, List<string>> disc)
        {
            Console.WriteLine("> KEYS ");
            if (disc.Keys != null && disc.Keys.Count > 0)
            {
                var i = 1;
                foreach (var item in disc.Keys)
                {
                    Console.WriteLine("{0}){1}", i, item);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("(empty set)");
            }
        }

        public static void Members(Dictionary<string, List<string>> disc, MyDictionary _dictionary)
        {
            List<string> get_existedKeyValue = new List<string>();
            if (disc.ContainsKey(_dictionary.ReadKey))
            {
                //var get_existedKeyValue = disc.Where(x => x.Key == key).Select(a => a.Value).ToList();
                disc.TryGetValue(_dictionary.ReadKey, out get_existedKeyValue);
                var i = 1;
                foreach (var item in get_existedKeyValue)
                {
                    // displays exactly as use case with count and parentheses.
                    Console.WriteLine("{0}){1}", i, item);

                    i++;
                }
            }
            else
            {
                Console.WriteLine(") ERROR , Key does not exist");
            }
        }

        public static void Remove(Dictionary<string, List<string>> disc, MyDictionary _dictionary)
        {
            List<string> get_existedKeyValue = new List<string>();
            if (disc.ContainsKey(_dictionary.ReadKey))
            {
                disc.TryGetValue(_dictionary.ReadKey, out get_existedKeyValue);

                if (get_existedKeyValue.Count > 0 && _dictionary.ReadValue[0] != null)
                {

                    bool isRemoved = disc[_dictionary.ReadKey].Remove(_dictionary.ReadValue[0]); // removes the value
                    if (isRemoved)
                    {
                        Console.WriteLine("Removed");
                    }
                    else
                    {
                        Console.WriteLine(") ERROR, Member does not exist");
                    }
                }

                if (get_existedKeyValue.Count == 0)
                {
                    disc.Remove(_dictionary.ReadKey);     //removes the key if values are none.
                }
            }
            else
            {
                Console.WriteLine(") ERROR, key does not exist");
            }
        }

        public static void RemoveAll(Dictionary<string, List<string>> disc, MyDictionary _dictionary)
        {
            if (!disc.ContainsKey(_dictionary.ReadKey))
            {
                Console.WriteLine(") ERROR, key does not exist");
            }
            else
            {
                var items = disc.Where(x => x.Key == _dictionary.ReadKey).Select(a => a.Key).ToList();
                foreach (var _k in items)
                {
                    disc.Remove(_k);
                    Console.WriteLine(") Removed");
                }
            }
        }

        public static void Clear(Dictionary<string, List<string>> disc)
        {
            disc.Clear();
            Console.WriteLine(") Cleared");

            // one more check so that we can display empty set
            if (disc.Keys.Count == 0)
            {
                Console.WriteLine("(empty set)");
            }
        }

        public static void KeyExists(Dictionary<string, List<string>> disc, MyDictionary _dictionary)
        {
            if (disc.ContainsKey(_dictionary.ReadKey))
            {
                Console.WriteLine(") true");
            }
            else
            {
                Console.WriteLine(") false");
            }
        }

        public static void MemberExist(Dictionary<string, List<string>> disc, MyDictionary _dictionary)
        {
            List<string> get_existedKeyValue = new List<string>();
            if (disc.ContainsKey(_dictionary.ReadKey))
            {
                //var get_existedKeyValue = disc.Where(x => x.Key == key).Select(a => a.Value).ToList();
                disc.TryGetValue(_dictionary.ReadKey, out get_existedKeyValue);

                var i = 0;
                foreach (var item in get_existedKeyValue)
                {
                    if (item == _dictionary.ReadValue[0])
                    {
                        Console.WriteLine(") true");
                    }
                    else
                    {
                        Console.WriteLine(") false");
                    }

                    i++;
                }
            }
            else
            {
                // Console.WriteLine(") ERROR , Key does not exist");
                Console.WriteLine(") false");
            }
        }

        public static void ALLMembers(Dictionary<string, List<string>> disc)
        {
            if (disc.Keys != null && disc.Keys.Count > 0)
            {
                var result = disc.SelectMany(x => x.Value);
                var i = 1;
                foreach (var item in result)
                {
                    Console.WriteLine("{0}){1}", i, item);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("(empty set)");
            }
        }

        public static void Return_AllItems(Dictionary<string, List<string>> disc)
        {
            if (disc.Count > 0)
            {
                var i = 0;
                List<string> get_existedKeyValue = new List<string>();
                foreach (var item in disc.Keys)
                {
                    disc.TryGetValue(item, out get_existedKeyValue);
                    foreach (var val in get_existedKeyValue)
                    {
                        Console.WriteLine("{0}) {1}: {2}", i, item, val);
                        i++;
                    }
                }
            }
            else
            {
                Console.WriteLine("> ITEMS \n {0}", "(empty set)");
            }
        }
    }
}
