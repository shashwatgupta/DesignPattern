using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPattern
{
    public class Facade
    {
        public static void Run()
        {
            FileReadFacade x = new FileReadFacade();
            x.ReadAndSendData("Program.cs");
        }
          
    }


    public class FileReadFacade
    {
        public void ReadAndSendData(string filename)
        {

            FileClient x = new FileClient();
            Logging lg = new Logging();

            Sender sd = new Sender();

            string data = x.ReadFile(filename);
            lg.logData(data.Length);
            sd.Send(data);
        }
    }

    public class Logging
    {
        public void logData(int length)
        {
            Console.WriteLine("Length is " + length);
        }
    }

    public class FileClient
    {
        public String ReadFile(string fileName)
        {
            string text = System.IO.File.ReadAllText(@"..\..\" + fileName);
            return text;
        }
    }

    public class Sender
    {
        public void Send(string str)
        {
            Console.WriteLine("Sent Data " + str);
        }
    }
}
