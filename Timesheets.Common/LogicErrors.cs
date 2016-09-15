using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheets.Common
{
    public class LogicErrors : Collection<LogicError>
    {
        public bool HasErrors
        {
            get { return Count > 0; }
        }

        /// <summary>
        /// Throws a LogicException with all errors in this list.
        /// Will NOT throw an exception if there are no errors (duh!)
        /// </summary>
        public void ThrowExceptionIfErrors()
        {
            if (HasErrors)
                throw new LogicException(this);
        }

        /// <summary>
        /// Returns a list of all the error messages in all logic errors. 
        /// </summary>
        /// <returns></returns>
        public string GetCombinedMessages()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var error in this)
            {
                builder.AppendLine(error.Message ?? error.ToString());
            }
            return builder.ToString();
        }

    }
}
