using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPattern
{
    class StatePattern
    {
        public static void Run()
        {
            TestRun tr = new TestRun();
            tr.RunToFinishTest();
        }
    }

    public class TestRun
    {
        public TestRun()
        {
            currentTestState = new NotRunState();
        }

        public void RunToFinishTest()
        {
            while (currentTestState.IsFinalState != true)
            {
                currentTestState.Run(this);
            }
        }

        public TestState currentTestState;
    }

    public abstract  class TestState
    {
        public abstract void Run(TestRun t);

        public bool IsFinalState = false;

        public void ChangeState(TestRun tr, TestState newState)
        {
            tr.currentTestState = newState;
        }
    }

    public class RunState : TestState
    {
        public override void Run(TestRun t)
        {
            Console.WriteLine("Done  running, moving to next");
            ChangeState(t, new SuceededState());
        }
    }
    public class NotRunState : TestState
    {
        public override void Run(TestRun t)
        {
            Console.WriteLine("Done not running, moving to next");
            ChangeState(t, new RunState());
        }
        

    }
    public class AbondonedState : TestState
    {
        public override void Run(TestRun t)
        {
            Console.WriteLine("Done Abondoned");
            IsFinalState = true;
        }
    }
    public class SuceededState : TestState
    {
        public override void Run(TestRun t)
        {
            Console.WriteLine("Done Succededing");
            IsFinalState = true;
        }
    }
}
;