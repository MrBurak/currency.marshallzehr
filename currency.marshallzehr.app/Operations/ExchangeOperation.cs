using currency.marshallzehr.business;
using currency.marshallzehr.model;
using System;

namespace currency.marshallzehr.app.Operations
{
    public class ExchangeOperation:IDisposable
    {
        private bool disposedValue;

        public delegate void NextOperation();

        private readonly ExchangeRateBusiness _business;
        public ExchangeOperation()
        {
            _business = new ExchangeRateBusiness();
        }
        

        

        public void Validate() 
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the amount you want to exchange!");
            Console.WriteLine("");

        }


        public bool Choose(ExchangeRequest request, NextOperation nextOperation) 
        {

            
            var valueStr = Console.ReadLine();
            try
            {
                ExchangeResult exchangedvalue = new ExchangeResult
                {
                    SourceUnit = request.SourceUnit,
                    TargetUnit = request.TargetUnit,
                    dateTime = request.dateTime,
                    SourceValue = Convert.ToDecimal(valueStr),
                  
                };
                bool nodata;
                var appresult = _business.GetRate(exchangedvalue.dateTime, request.UnitPrefix,out nodata);

                if (nodata) 
                {
                    Console.WriteLine("");
                    Console.WriteLine("*********************************************************");
                    Console.WriteLine("");
                    Console.WriteLine($"There is no exchange data to show between {request.SourceUnit} and {request.TargetUnit} for {((DateTime)request.dateTime).ToString("yyyy-MM-dd")}");
                    Console.WriteLine("");
                    Console.WriteLine("*********************************************************");
                    nextOperation();
                    return true;
                }


                if (appresult != null)
                {
                    
                    
                    exchangedvalue.RateValue = Convert.ToDecimal(appresult.Unit.v);
                    exchangedvalue.dateTime = appresult.Date;
                    exchangedvalue.TargetValue = exchangedvalue.SourceValue * exchangedvalue.RateValue;
                    Console.WriteLine("");
                    Console.WriteLine("*********************************************************");
                    Console.WriteLine("");
                    Console.WriteLine($"Date : {((DateTime)exchangedvalue.dateTime).ToString("yyyy-MM-dd")} Rate : {string.Format("{0:N4}", exchangedvalue.RateValue)}");
                    Console.WriteLine("");
                    Console.WriteLine($"{string.Format("{0:N2}", exchangedvalue.SourceValue)} {exchangedvalue.SourceUnit} = {string.Format("{0:N2}", exchangedvalue.TargetValue)} {exchangedvalue.TargetUnit}");
                    Console.WriteLine("");
                    Console.WriteLine("*********************************************************");



                    nextOperation();
                    return true;
                }
                else 
                {
                    Console.WriteLine("");
                    Console.WriteLine("*********************************************************");
                    Console.WriteLine("An error oocured on convert currencies");
                    Console.WriteLine("");
                    Console.WriteLine("*********************************************************");
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("*********************************************************");
                Console.WriteLine("An error oocured on convert currencies");
                Console.WriteLine("");
                Console.WriteLine("*********************************************************");
                return false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _business.Dispose();
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
