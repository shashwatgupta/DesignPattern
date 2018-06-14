using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPattern
{
    class StrategyPattern
    {
        public static void Run()
        {
            StrongConsistency sc = new StrongConsistency();
            RsoManager rsoMgr = new RsoManager(new EventualConsistency());
            rsoMgr.ReplicaData();

        }
    }

    public class RsoManager
    {
        public  RsoManager(ConsistencyStrategy x)
        {
            consistencyStratgey = x;
        }
        public void ReplicaData()
        {
            consistencyStratgey.ReplicateData(this);
        }

        private ConsistencyStrategy consistencyStratgey;
        public string Data = "Some data";
    }

    public abstract class ConsistencyStrategy
    {
        public abstract void ReplicateData(RsoManager rso);
    }

    public class StrongConsistency : ConsistencyStrategy
    {
        public override void ReplicateData(RsoManager rso)
        {
            Console.WriteLine(" pUshing daata to All DCs {0}", rso.Data);
            System.Threading.Thread.Sleep(3000);
        }
    }

    public class EventualConsistency : ConsistencyStrategy
    {
        public override void ReplicateData(RsoManager rso)
        {
            Console.WriteLine("No force pushing data {0}", rso.Data);
            System.Threading.Thread.Sleep(0);
        }
    }

    public class SessionConsistency : ConsistencyStrategy
    {
        public override void ReplicateData(RsoManager rso)
        {
            Console.WriteLine("Pushing data to 1 Geo Redundent Replica {0}", rso.Data);
            System.Threading.Thread.Sleep(10);
        }
    }
}
