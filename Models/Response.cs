using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Explore_App.Models
{
    [Serializable]
    public class Response<T>
    {
        public Int16 Error;
        public bool Send;
        public string Message;
        public T Result;
        public void Passage(Int16 error, bool send, string message, T result)
        {
            this.Error = error;
            this.Send = send;
            this.Message = message;
            this.Result = result;
        }
    }
}