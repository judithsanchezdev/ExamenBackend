using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsApiexamen.Models.System
{
    public class ResponseModels<T> where T : class
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T Model { get; set; }

        public List<string> Errors { get; set; }

    }
   
    public class ResponseModels
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }
    }
}
