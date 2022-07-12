using currency.marshallzehr.model;
using System;
using System.Linq;

namespace currency.marshallzehr.app.Operations
{
    public class ChooseUnitOperation:IDisposable
    {
        private bool disposedValue;

        public delegate void NextOperation();

        public void List() 
        {

            Console.WriteLine("");
            foreach (var opt in StaticsVariables.currencylist.Where(x=> x.Key!= StaticsVariables.basecurrency.AlphabeticCode).OrderBy(x=> x.Key))
            {
                Console.WriteLine($"{opt.Value.AlphabeticCode} - {opt.Value.Currency}");
            }

            Console.WriteLine("");
            Console.WriteLine("Please choose your currency unit by code!");
            Console.WriteLine("");
        }


        public bool Choose(out CurrencyUnit operation, NextOperation nextOperation) 
        {

            var unit = Console.ReadLine().ToUpper();
            if (StaticsVariables.currencylist.Any(x => x.Key.Equals(unit)))
            {
                operation = StaticsVariables.currencylist.First(x => x.Key.Equals(unit)).Value;
                nextOperation();
                return true;
            }
            else
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
