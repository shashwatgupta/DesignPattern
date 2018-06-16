using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPattern
{
    class Mediator
    {
        public static void Run()
        {
            Director d = new Director();

            Engine e = new Engine(d);
            Accelator ac = new Accelator(d);
            CarBreak cb = new CarBreak(d);
            d.Setup(e, cb, ac);
            e.EngineStart();

        }
    }

    public class Director
    {
        public void Setup(Engine e , CarBreak cb, Accelator ac)
        {
            this.e = e;
            this.cb = cb;
            this.ac = ac;
        }

        public void EngineStarted()
        {
            ac.SetupAcceelatorToZero();
            cb.PressBreak();
        }

        Engine e;
        Accelator ac;
        CarBreak cb;
    }

    public class CarWidget
    {
        public CarWidget(Director d)
        {
            _director = d;
        }

        protected Director _director;
    }

    public class Engine : CarWidget
    {
        public Engine(Director d) : base(d)
        {

        }

        public void EngineStart()
        {
            Console.WriteLine("Starting Engine...");
            _director.EngineStarted();
        }
    }

    public class Accelator : CarWidget
    {
        public Accelator(Director d) : base(d)
        {

        }

        public void SetupAcceelatorToZero()
        {
            Console.WriteLine("Accelator set to 0...");
        }
    }

    public class CarBreak : CarWidget
    {
        public CarBreak(Director d) : base(d)
        {

        }

        public void PressBreak()
        {
            Console.WriteLine("Pressed break...");
        }
    }


}
