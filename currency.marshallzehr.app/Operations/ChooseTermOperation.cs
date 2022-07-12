using currency.marshallzehr.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace currency.marshallzehr.app.Operations
{
    public class ChooseTermOperation:IDisposable
    {
        private bool disposedValue;

        public delegate void NextOperation();
        public delegate void DateOperation();

        public ChooseTermOperation()
        {   

        }
        

        private List<OperationTerm> Get() 
        {
            return new List<OperationTerm>
            {
                new OperationTerm { Id=1, Message=$"Latest rates"},
                new OperationTerm { Id=2, Message=$"Rates by date", NeedEntry=true}
            };

        }

        public void List() 
        {
            Console.WriteLine("");
            foreach (var opt in Get())
            {
                Console.WriteLine(opt.ToString());
            }
            Console.WriteLine("");
            Console.WriteLine("Please choose your operation term by number!");
            Console.WriteLine("");
        }


        public bool Choose(out OperationTerm operation, NextOperation nextOperation, DateOperation dateOperation) 
        {

            var list = Get();
            var choosenOperationStr = Console.ReadLine();
            try
            {
                int choosenOperation = Convert.ToInt32(choosenOperationStr);
                if (list.Any(x => x.Id.Equals(choosenOperation)))
                {
                    operation = list.First(x => x.Id.Equals(choosenOperation));
                    if (operation.NeedEntry)
                    {
                        dateOperation();
                    }
                    else 
                    {
                        nextOperation();
                    }
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
