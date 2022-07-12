using currency.marshallzehr.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace currency.marshallzehr.app.Operations
{
    public class ChooseMonthOperation:IDisposable
    {
        private bool disposedValue;

        public delegate void NextOperation();
   
        public ChooseMonthOperation()
        {
        }




        private List<Operation> Get() 
        {
            var mounthcount = 12;
            if (StaticsVariables.currentYear.Id.Equals(DateTime.Today.Year)) 
            {
                mounthcount = DateTime.Today.Month;

            }
            List<Operation> months = new List<Operation>();
            for (var i = 1; i <= mounthcount; i++)
            {
                months.Add(new Operation { Id = i, Message = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) });
            }
            return months;

        }

        public void List() 
        {
            Console.WriteLine("");
            foreach (var opt in Get())
            {
                Console.WriteLine(opt.ToString());
            }
            Console.WriteLine("");
            Console.WriteLine("Please choose month by number!");
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
           
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
