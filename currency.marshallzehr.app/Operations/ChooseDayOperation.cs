using currency.marshallzehr.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace currency.marshallzehr.app.Operations
{
    public class ChooseDayOperation:IDisposable
    {
        public delegate void NextOperation();

        private bool disposedValue;

        public ChooseDayOperation()
        {
        }




        private List<Operation> Get() 
        {

            var daylimit = 99;
            if (StaticsVariables.currentYear.Id.Equals(DateTime.Today.Year) && StaticsVariables.currentMonth.Id.Equals(DateTime.Today.Month))
            {
                daylimit = DateTime.Today.Day;

            }

            var startdate = new DateTime(StaticsVariables.currentYear.Id, StaticsVariables.currentMonth.Id, 1);
            var enddate = startdate.AddMonths(1);
            List<Operation> days = new List<Operation>();
            
            while (startdate < enddate)
            {
                if ((startdate.DayOfWeek != DayOfWeek.Saturday) && (startdate.DayOfWeek != DayOfWeek.Sunday))
                {
                    days.Add(new Operation { Id = startdate.Day, Message = $"{startdate.DayOfWeek}" });
            
                }
                
                    startdate = startdate.AddDays(1);
                if (daylimit == startdate.Day) break;

            }
            return days;

        }

        public void List() 
        {
            Console.WriteLine("");
            foreach (var opt in Get())
            {
                Console.WriteLine(opt.ToString());
            }
            Console.WriteLine("");
            Console.WriteLine("Please choose day by number!");
            Console.WriteLine("");
        }


        public bool Choose(out Operation operation, NextOperation nextOperation) 
        {

            var list = Get();
            var choosenOperationStr = Console.ReadLine();
            try
            {
                int choosenOperation = Convert.ToInt32(choosenOperationStr);
                if (list.Any(x => x.Id.Equals(choosenOperation)))
                {
                    operation = list.First(x => x.Id.Equals(choosenOperation));
                    nextOperation();
                    return true;
                }
                else
                {
                    operation = null;
                    return false;
                }
            }
            catch
            {
                operation = null;
                return false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

  
                disposedValue = true;
            }
        }


        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
