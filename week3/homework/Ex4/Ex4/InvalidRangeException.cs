using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4
{
    [Serializable]
    class InvalidRangeException<T> : Exception
    {
        private static readonly string DefaultMessage = "The specified value is in an invalid range";

        public T Start { get; set; }
        public T End { get; set; }
        public InvalidRangeException() : base(DefaultMessage) { }
        public InvalidRangeException(string message) : base(message) { }
        public InvalidRangeException(string message, Exception innerException): base(message, innerException) { }
        public InvalidRangeException(T start, T end, string message) : base(message) 
        {
            this.Start = start;
            this.End = end;
        }

    }
}
