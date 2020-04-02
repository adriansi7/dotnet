using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2
{
    public class BusinessDateFormatStringBuilder
    {
        private readonly StringBuilder builder;
        public BusinessDateFormatStringBuilder(string format)
        {
            builder = new StringBuilder(format);
        }
        public BusinessDateFormatStringBuilder EscapeFormatSpecifier(string formatSpecifier)
        {
            builder.Replace(formatSpecifier, "\\" + formatSpecifier);
            return this;
        }
        public override string ToString()
        {
            return builder.ToString();
        }
    }
}
