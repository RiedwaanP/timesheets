using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Common;

namespace Timesheets.Domain
{
    public class DomainLogicError : LogicError
    {
        public DomainLogicError(string message) : base(message) { }
    }
}
