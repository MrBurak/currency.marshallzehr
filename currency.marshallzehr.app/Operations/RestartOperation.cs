using System;

namespace currency.marshallzehr.app.Operations
{
    public class RestartOperation : IDisposable
    {
        private bool disposedValue;

        public delegate void NextOperation();
        public delegate void CloseOperation();
        public string restart = "R";
        public string quit = "Q";






        public void Ask() 
        {
            Console.WriteLine("");
            Console.WriteLine($"Do you want Restart [{restart}] or Quit [{quit}] ?");
            Console.WriteLine("");
        }


        public bool Choose(NextOperation nextOperation, CloseOperation closeOperation) 
        {

           
            var choosenOperationStr = Console.ReadLine().ToUpper();
            if (choosenOperationStr.Equals(restart)) 
            {
                nextOperation();
                return true;
            }
            if (choosenOperationStr.Equals(quit))
            {
                closeOperation();
                return true;
            }
            return false;
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
