using System;

namespace currency.marshallzehr.model
{
    /// <summary>
    ///  General business requests response object 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : IDisposable
    {
        private bool disposedValue;

        public T Entity { get; set; }
        private bool isSuccess { get; set; }
        public bool IsSuccess { get { return isSuccess; } }

        private string _message { get; set; }
        public string Message { get { return _message; } }

        private string _description { get; set; }
        public string Description { get { return _description; } }

        public void Success(string message=null) 
        {
            isSuccess = true;
            _message = string.IsNullOrWhiteSpace(message)? "Success" : message;
            _description = string.Empty;
        }
        public void Fail(string message = null, string description=null)
        {
            isSuccess = false;
            _message = string.IsNullOrWhiteSpace(message) ? "Fail" : message;
            _description = string.IsNullOrWhiteSpace(description) ? "" : description;
            Entity = default(T);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                   
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
