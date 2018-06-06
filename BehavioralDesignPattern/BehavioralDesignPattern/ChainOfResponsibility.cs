using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPattern
{
    public class ChainOfResponsibility
    {
        public static void Run()
        {
            //Run
            SeatEjection se = new SeatEjection(null);
            AirBags ab = new AirBags(se);
            SeatBelt s = new SeatBelt(ab);

            s.HandleImpact(120);

        }
    }

    public class ImpactHandler
    {
        public ImpactHandler Successor { get; set; }

        public virtual void HandleImpact(int sizeofImpact)
        {
            Successor.HandleImpact(sizeofImpact);
        }
    }

    public class SeatBelt : ImpactHandler
    {
        public SeatBelt(ImpactHandler s)
        {
            this.Successor = s;
        }

        public override void HandleImpact(int sizeofImpact)
        {
            if (sizeofImpact < 10)
            {
                Console.WriteLine("Handled by SeatBelt");
            }
            else
            {
                base.HandleImpact(sizeofImpact);
            }
        }
    }

    public class AirBags : ImpactHandler
    {
        public AirBags(ImpactHandler s)
        {
            this.Successor = s;
        }
        public override void HandleImpact(int sizeofImpact)
        {
            if (sizeofImpact < 100)
            {
                Console.WriteLine("Handled by AirBags");
            }
            else
            {
                base.HandleImpact(sizeofImpact);
            }
        }
    }

    public class SeatEjection : ImpactHandler
    {
        public SeatEjection(ImpactHandler s)
        {
            this.Successor = null;
        }

        public override void HandleImpact(int sizeofImpact)
        {
            Console.WriteLine("Handled by SeatEjection");
        }
    }

}
