using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheets.Common
{
    public abstract class LogicError
    {
        protected LogicError()
            : this(null)
        {

        }

        protected LogicError(string message)
        {
            Message = message;
        }

        public string Message { get; set; }

        public void Throw()
        {
            throw AsException();
        }
        public LogicException AsException()
        {
            return new LogicException(this);
        }
    }
}
