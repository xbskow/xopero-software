using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona320
{
    class Worker : Bee
    {
        public Worker(string[] jobsICanDo, double weightMg) : base(weightMg)
        {
            this.jobsICanDo = jobsICanDo;
        }

        const double honeyUnitsPerShiftWorked = .65;

        public override double HoneyConsumptionRate()
        {
            double consumption = base.HoneyConsumptionRate();
            consumption += shiftsWorked * honeyUnitsPerShiftWorked;
            return consumption;
        }

        public string CurrentJob;
        private string currentJob
        {
            get
            {
                return CurrentJob;
            }
        }
        public int ShiftsLeft
        {
            get
            {
                return shiftsToWork - shiftsWorked;
            }
        }

        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;

        public bool DoThisJob(string job, int shiftsToWork)
        {
            if (!String.IsNullOrEmpty(currentJob))
                return false;
            foreach (string jobICanDo in jobsICanDo)
            {
                if (job == jobICanDo)
                {
                    CurrentJob = job;
                    this.shiftsToWork = shiftsToWork;
                    shiftsWorked = 0;
                    return true;
                }
            }
            return false;

        }
        public bool DidYouFinish()
        {
            if (String.IsNullOrEmpty(currentJob))
                return false;
            shiftsWorked++;
            if (shiftsWorked > shiftsToWork)
            {
                shiftsWorked = 0;
                shiftsToWork = 0;
                CurrentJob = "";
                return true;
            }
            else
                return false;
        }
        public bool WorkOneShift()
        {
            if (String.IsNullOrEmpty(currentJob))
                return false;
            shiftsWorked++;
            if (shiftsWorked > shiftsToWork)
            {
                shiftsToWork = 0;
                shiftsWorked = 0;
                CurrentJob = "";
                return true;
            }
            else
                return false;


        }
    }
}
