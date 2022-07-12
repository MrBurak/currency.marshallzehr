using currency.marshallzehr.app.Operations;
using currency.marshallzehr.business.Interface;
using System;


namespace currency.marshallzehr.app
{
    public class OperationsLogic : IDisposable
    {
        public OperationsLogic(IConfigBusiness configBusiness)
        {
            _chooseOperation = new ChooseOperation();
            _chooseUnitOperation = new ChooseUnitOperation();
            _chooseTermOperation = new ChooseTermOperation();
            _chooseYearOperation = new ChooseYearOperation(configBusiness);
            _chooseMonthOperation = new ChooseMonthOperation();
            _exchangeOperation = new ExchangeOperation();
            _chooseDayOperation = new ChooseDayOperation();
            _restartOperation = new RestartOperation();

        }

        public ChooseOperation _chooseOperation { get; set; }
        public ChooseUnitOperation _chooseUnitOperation { get; set; }
        public ChooseTermOperation _chooseTermOperation { get; set; }
        public ChooseYearOperation _chooseYearOperation { get; set; }
        public ChooseMonthOperation _chooseMonthOperation { get; set; }
        public ChooseDayOperation _chooseDayOperation { get; set; }

        public ExchangeOperation _exchangeOperation { get; set; }
        public RestartOperation _restartOperation { get; set; }

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _chooseOperation.Dispose();
                    _chooseUnitOperation.Dispose();
                    _chooseTermOperation.Dispose();
                    _chooseYearOperation.Dispose();
                    _chooseMonthOperation.Dispose();
                    _chooseDayOperation.Dispose();
                    _exchangeOperation.Dispose();
                    _restartOperation.Dispose();
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
