using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona320
{
    class Queen
    {
        public Queen(Worker[] workers)
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
            shiftNumber++;
            string report = $"Raport zmiany numer {shiftNumber}\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i].WorkOneShift();
                if (workers[i].ShiftsLeft > 0)
                {
                    if (workers[i].ShiftsLeft > 1)
                        report += $"Robotnica numer {i} robi {workers[i].currentJob} jeszcze przez {workers[i].ShiftsLeft} zmiany\r\n";
                    else
                        report += $"Robotnica numer {i} zakończy {workers[i].currentJob} po tej zmianie\r\n";
                }
                else
                {
                    report += $"Robotnica numer {i} nie pracuje\r\n";
                }
            }
            return report;
        }
    }
}
