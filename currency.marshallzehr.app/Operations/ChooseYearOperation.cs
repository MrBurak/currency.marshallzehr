using currency.marshallzehr.business.Interface;
using currency.marshallzehr.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace currency.marshallzehr.app.Operations
{
    public class ChooseYearOperation:IDisposable
    {
        public delegate void NextOperation();
        IConfigBusiness _configBusiness;
        private bool disposedValue;

        public ChooseYearOperation(IConfigBusiness configBusiness)
        {
            _configBusiness = configBusiness;
        }




        private List<Operation> Get() 
        {
            var startYear = int.Parse(_configBusiness.Get("startYear"));
            List<Operation> years = new List<Operation>();
            var yearcount = DateTime.Today.Year - startYear;

            for (var i = 0; i <= yearcount; i++)
            {
                var year = DateTime.Today.AddYears(i * -1).Year;
                years.Add(new Operation
                {
                    Id = year,
                    Message = string.Empty,
                    
                });
            }
            return years;

        }

        public void List() 
        {
            Console.WriteLine("");
            foreach (var opt in Get())
            {
                Console.WriteLine(opt.Id.ToString());
            }
            Console.WriteLine("");
            Console.WriteLine("Please choose year by number!");
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
                    _configBusiness.Dispose();
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
