using currency.marshallzehr.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace currency.marshallzehr.app.Operations
{
    public class ChooseOperation:IDisposable
    {
        private bool disposedValue;

        public delegate void NextOperation();
        
        
        

        private List<Operation> Get() 
        {
            return new List<Operation>
            {
                new Operation { Id=1, Message=$"XXX to {StaticsVariables.basecurrency.AlphabeticCode}"},
                new Operation { Id=2, Message=$"{StaticsVariables.basecurrency.AlphabeticCode} to XXX"}
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
            Console.WriteLine("Please choose your operation by number!");
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
