using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalDesignPattern
{
    class Singleton
    {
        public static void Run()
        {
            SingletonSubClass st = (SingletonSubClass)SingletonSubClass.GetInstance("SingletonSubClass");
            SingletonSubClass2 sb = (SingletonSubClass2)SingletonSubClass2.GetInstance("SingletonSubClass2");
        }
    }


    public class SingletonTest
    {
        private static SingletonTest _instance;

        public static SingletonTest GetInstance(string name)
        {
            if (lookupDictionary.TryGetValue(name, out _instance))
            {

                return _instance;
            }

            if ("SingletonSubClass".Equals(name))
            {
                _instance = new SingletonSubClass();
            }

            if ("SingletonSubClass2".Equals(name))
            {
                _instance = new SingletonSubClass2();
            }


            return _instance;
        }


        public static void Register(string name, SingletonTest st)
        {
            lookupDictionary.Add(name, st);
        }

        protected static Dictionary<string, SingletonTest> lookupDictionary =
             new Dictionary<string, SingletonTest>();

        protected SingletonTest() { }
    }


    public class SingletonSubClass : SingletonTest
    {
        public SingletonSubClass()
        {
            SingletonTest.Register("SingletonSubClass", this);
        }
     }

    public class SingletonSubClass2 : SingletonTest
    {
        public SingletonSubClass2()
        {
            SingletonTest.Register("SingletonSubClass2", this);
        }
    }


}
