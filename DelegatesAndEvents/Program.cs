using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class Program
    {
        public delegate void WorkPerformedHandler(int hours, WorkType workType);

        public delegate int BizRulesDelegate(int x, int y);

        private static void Main(string[] args)
        {
            List<int> p = new List<int>();

            #region DelegatesOperations

            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //del1 += del2;
            //del1 += del3;

            //del1(10, WorkType.GenerateReports);

            #endregion

            #region InlineDelegate

            // Inline Delegate with Annonymous Method
            // worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            // {
            //     Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
            // };

            #endregion

            var worker = new Worker();

            worker.WorkPerformed += Worker_WorkPerformed; // Delegate Inference
            worker.WorkCompleted += Worker_WorkCompleted;

            #region UsingLambda

            // Using Lambda
            worker.WorkPerformed += (s, e) => Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);

            #endregion

            worker.DoWork(8, WorkType.GenerateReports);

            Console.WriteLine("USING LAMBDAS");

            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(2, 3, multiplyDel);

            Console.WriteLine("USING ACTION");

            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);

            data.ProcessAction(2, 3, myAction);

            Console.WriteLine("USING FUNC");

            Func<int, int, int> funcAddDel = (x, y) => { return x + y; };
            Func<int, int, int> funcMultiplyDel = (x, y) => { return x * y; };

            data.ProcessFunc(3, 2, funcMultiplyDel);

            Console.Read();
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Worker is Done");
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
        }

        //static void DoWork(WorkPerformedHandler del)
        //{
        //    del(5, WorkType.Golf);
        //}

        //static void WorkPerformed1(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed1 called " + hours.ToString());
        //}

        //static void WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed2 called " + hours.ToString());
        //}

        //private static void WorkPerformed3(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed3 called " + hours.ToString());
        //}
    }
}