using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona320
{
    class Queen : Bee
    {
        public Queen(Worker[] workers, double weightMg) : base(weightMg)
        {
            this.workers = workers;
        }
        private Worker[] workers;
        private int shiftNumber;

        public bool AssignWork(string job, int numberOfShifts)
        {
            for (int i = 0; i < workers.Length; i++)
                if (workers[i].DoThisJob(job, numberOfShifts))
                    return true;
            return false;
        }

        public string WorkTheNextShift()
        {
            double honeyConsumed = HoneyConsumptionRate();
            shiftNumber++;
            string report = $"Raport zmiany numer {shiftNumber}\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DidYouFinish())
                    report += $"Robotnica numer {i + 1} zakończyła swoje zadanie\r\n";
                if (String.IsNullOrEmpty(workers[i].CurrentJob))
                    report += $"Robotnica numer {i + 1} nie pracuje\r\n";
                else
                {
                    if (workers[i].ShiftsLeft > 0)
                        report += $"Robotnica numer {i + 1} robi {workers[i].CurrentJob} jeszcze przez {workers[i].ShiftsLeft} zmiany\r\n";
                    else
                        report += $"Robotnica numer {i + 1} zakończy {workers[i].CurrentJob} po tej zmianie\r\n";
                }
            }
            return report;
        }
    }
}
