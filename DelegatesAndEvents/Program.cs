using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }

    internal class Program
    {
        public delegate void WorkPerformedHandler(int hours, WorkType workType);

        private static void Main(string[] args)
        {
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