using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPattern
{
    class Decorator
    {
        public static void Run()
        {
            Room x = new BigPlace(new HotelRoom());
            Console.WriteLine(x.EmergencyNumber);
            Room y = new BigPlace(new IndiaRoom());
            Console.WriteLine(y.EmergencyNumber);
        }


        public abstract class Room
        {
           public abstract int EmergencyNumber { get;  }

           public  int RoomNumber { get; set; }

           public  int FloorNumber { get; set; }
        }

        public class HotelRoom : Room
        {
            public override int EmergencyNumber
            {
                get
                {
                    return 0;
                }
            }
        }

        public class HomeRoom : Room
        {
            public override int EmergencyNumber
            {
                get
                {
                    return 911;
                }
            }
        }

        public class IndiaRoom : Room
        {
            public override int EmergencyNumber
            {
                get
                {
                    return 100;
                }
            }
        }


        public class BigPlace : Room
        {
            public BigPlace(Room x)
            {
                Console.WriteLine("I Am at Big Place");
                _x = x;
            }

            public override int EmergencyNumber
            {
                get
                {
                    return _x.EmergencyNumber;
                }
            }

            private Room _x;
        } 
    }
}
