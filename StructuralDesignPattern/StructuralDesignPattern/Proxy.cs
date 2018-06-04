using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPattern
{
    public class Proxy
    {
        public static void Run()
        {
            ServiceProxy x = new ServiceProxy(new Service());
            x.HeavyLoadOperation();
        }
    }

    public interface ServiceInterface
    {
         void HeavyLoadOperation();

         int MakeSum(int a, int b);
    }

    public class ServiceProxy : ServiceInterface
    {
        public ServiceProxy(Service service)
        {
            this.service = service;
        }

        public void HeavyLoadOperation()
        {
            Console.WriteLine("Making over the wire call");
            Console.WriteLine("Setting up Authentication header");
            service.HeavyLoadOperation();
        }

        public int MakeSum(int a, int b)
        {
            return service.MakeSum(a, b);
        }

        private Service service;
    }

    public class Service : ServiceInterface
    {
        public void HeavyLoadOperation()
        {
            Console.WriteLine("Vert very heavy operation.");
            System.Threading.Thread.Sleep(1000);
        }

        public int MakeSum(int a, int b)
        {
            return a + b;
        }
    }

}
