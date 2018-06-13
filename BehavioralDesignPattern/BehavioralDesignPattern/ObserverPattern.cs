using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPattern
{
    class ObserverPattern
    {
        public static void Run()
        {
            TenantPlans newTenantPlans = new TenantPlans();
            Observer ob = new Observer(newTenantPlans);
            newTenantPlans.AddPlan("XXX");
            newTenantPlans.AddPlan("YYY");
        }
    }

    public abstract class Subject
    {
        public void Attach(Observer o)
        {
            observerList.Add(o);
        }

        public void Detach(Observer o)
        {
            observerList.Remove(o);
        }

        public void Notify()
        {
            foreach (Observer o in observerList)
            {
                o.Update(this);
            }
        }
        List<Observer> observerList = new List<Observer>();
    }

    public class TenantPlans : Subject
    {
        public void AddPlan(string planId)
        {
            plans.Add(planId);
            this.Notify();
        }

        public List<string> GetPlan()
        {
            return plans;
        }

        List<String> plans = new List<string>();
    }



    public class Observer
    {
        TenantPlans _tp;

        public Observer(TenantPlans tp)
        {
            _tp = tp;
            _tp.Attach(this);
        }

        public void Update(Subject s)
        {
            if (_tp == s)
            {
                Console.WriteLine("I got a update for it" + _tp.GetPlan().Count());
            }
        }

    }



}
