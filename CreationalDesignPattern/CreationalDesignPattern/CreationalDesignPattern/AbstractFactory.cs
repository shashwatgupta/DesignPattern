using System;

namespace CreationalDesignPattern
{
    class AbstractFactory
    {
        static void Main(string[] args)
        {
            DoActionOnCar(new SUVFactory("honda","crv"));
            DoActionOnCar(new CarFactory("Tata", "nano"));
        }

        // This function does not care about whether its normal car vs SUV car.
        public static void DoActionOnCar(CarFactory x)
        {
            x.engine.MakeSound();
            Console.WriteLine("Car requires repair after", x.engine.RepairInterval());
            if (x.tire.RadialSize() > 18)
            {
                Console.WriteLine("can drive on beach");
            }
        }
    }


    public class SUVFactory : CarFactory
    {
        public SUVFactory(string make, string model) : base(make, model)
        {
            this.engine = new SUVEngine();
            this.tire = new BigTire();
        }
    }


    public class CarFactory
    {
        public CarFactory(string make, string model)
        {
            this.make = make;
            this.model = model;
            this.engine = new CarEngine();
            this.tire = new Tire();
        }

        public void Run()
        {
            if (!isRunning)
            {
                isRunning = true;
            }
            else
            {
                Console.WriteLine("Already running!");
            }

        }

        public void stop()
        {
            if (isRunning)
            {
                isRunning = false;
            }
            else
            {
                Console.WriteLine("Already stopped!");
            }

        }

        private bool isRunning;

        private string make;

        private string model;

        public Engine engine;

        public Tire tire;
    }

    public class Engine
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("zooooooooom");
        }

        public virtual int RepairInterval()
        {
            return 4;
        }
    }

    public class CarEngine : Engine
    { }

    public class SUVEngine : Engine
    {
        public override void MakeSound()
        {
            Console.WriteLine("zzzzzzzzoooooooooooooooooom");
        }

        public override int RepairInterval()
        {
            return 3;
        }
    }

    public class Tire
    {
        public virtual int RadialSize()
        {
            return 16;
        }
    }


    public class BigTire : Tire
    {
        public override int RadialSize()
        {
            return 19;
        }
    }
}