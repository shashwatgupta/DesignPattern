using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPattern
{
    class TemplateMethod
    {
        public static void Run()
        {
            SOAPRequestHandler handleRequest = new SOAPRequestHandler();
            handleRequest.HandleRequest();
        }
    }

    public class Message
    {
        public string UPN;
        public string DisplayName;
    }

    public abstract class RequestHandler
    {
        public abstract void ExtractHeaders(Message m);
        public void HandleRequest()
        {
            Message message = new Message();
            ExtractHeaders(message);

            Console.WriteLine("Fetching adata from UPN");
            message.DisplayName = "New Name";

            AttachHeaders(message);
        }
        public abstract void AttachHeaders(Message m);
    }


    public class SOAPRequestHandler :  RequestHandler
    {
        public override void ExtractHeaders(Message m)
        {
            m.UPN = "NewUser@DesignPattern.net";
        }

        public override void AttachHeaders(Message m)
        {
            Console.WriteLine(m.DisplayName);
        }
    }

    public class HttpRequestHandler : RequestHandler
    {
        public override void ExtractHeaders(Message m)
        {
            m.UPN = "NewUser2@DesignPattern.net";
        }

        public override void AttachHeaders(Message m)
        {
            Console.WriteLine(m.DisplayName);
        }
    }

}
