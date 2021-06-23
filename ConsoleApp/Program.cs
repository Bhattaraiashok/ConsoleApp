using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class MyDictionary
    {
        public string Command { get; set; }           // assigns first command what user want to perform
        public string ReadKey { get; set; }           // assigns keys
        public List<string> ReadValue { get; set; }   // assigns value
        public string[] ReadAllCommand { get; set; }  // this will hold all command from screen
        public string AssignedTo { get; set; }        // this holds whether Key, value or both needed to perform activity
    }

    public class OptionsEnum
    {
        public const string ADD = "add";
        public const string KEYS = "keys";
        public const string MEMBERS = "members";
        public const string REMOVE = "remove";
        public const string REMOVEALL = "removeall";
        public const string CLEAR = "clear";
        public const string KEYEXISTS = "keyexists";
        public const string MEMBEREXISTS = "memberexists";
        public const string ALLMEMBERS = "allmembers";
        public const string ITEMS = "items";
    }
    public class Program
    {

        public static void Main(string[] args)
        {
            Dictionary<string, List<string>> disc = new Dictionary<string, List<string>>();
            try
            {
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

            Console.Write("> ");
            _dictionary.ReadAllCommand = Console.ReadLine().Split(new[] { ' ' });
            if (_dictionary.ReadAllCommand.Count() > 0)
            {
                _dictionary.Command = _dictionary.ReadAllCommand[0];
            }
            switch (_dictionary.Command.ToLower())
            {
                case OptionsEnum.ADD:
                    _dictionary.AssignedTo = "key value";
                    if (!AssignKeyValue(_dictionary))
                        Add(disc, _dictionary);
                    break;
                case OptionsEnum.KEYS:
                    GetKeys(disc);
                    break;
                case OptionsEnum.MEMBERS:
                    _dictionary.AssignedTo = "key";
                    AssignKeyValue(_dictionary);
                    if (!AssignKeyValue(_dictionary))
                        Members(disc, _dictionary);
                    break;
                case OptionsEnum.REMOVE:
                    _dictionary.AssignedTo = "key value";
                    if (!AssignKeyValue(_dictionary))
                        Remove(disc, _dictionary);
                    break;
                case OptionsEnum.REMOVEALL:
                    _dictionary.AssignedTo = "key";
                    if (!AssignKeyValue(_dictionary))
                        RemoveAll(disc, _dictionary);
                    break;
                case OptionsEnum.CLEAR:
                    Clear(disc);
                    break;
                case OptionsEnum.KEYEXISTS:
                    _dictionary.AssignedTo = "key";
                    if (!AssignKeyValue(_dictionary))
                        KeyExists(disc, _dictionary);
                    break;
                case OptionsEnum.MEMBEREXISTS:
                    _dictionary.AssignedTo = "key value";
                    if (!AssignKeyValue(_dictionary))
                        MemberExist(disc, _dictionary);
                    break;
                case OptionsEnum.ALLMEMBERS:
                    ALLMembers(disc);
                    break;
                case OptionsEnum.ITEMS:
                    Return_AllItems(disc);
                    break;
            }

            Console.WriteLine("\n");
            AskUser(disc);
        }
        public static bool AssignKeyValue(MyDictionary _dictionary)
        {
            bool isError = false;
            _dictionary.ReadValue = new List<string>();
            var split = _dictionary.ReadAllCommand;
            if (_dictionary.AssignedTo == "key")
            {
                _dictionary.ReadKey = split[1];
            }
            else
            {
                if (split.Count() > 2)
                {
                    _dictionary.ReadKey = split[1];
                    _dictionary.ReadValue.Add(split[2]);
                }
                else
                {
                    isError = true;
                    Console.WriteLine("Please enter key and value.");
                }
            }
            return isError;
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
                Console.WriteLine("(empty set)");
            }
        }
    }
}
