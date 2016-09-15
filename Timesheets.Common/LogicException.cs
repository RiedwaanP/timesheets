using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Timesheets.Common
{
    public class LogicException : Exception
    {
        public LogicException(string message, LogicError error)
            : base(message)
        {
            Errors = new LogicErrors {error};
        }

        public LogicException(string message, LogicError error, Exception inner)
            : base(message, inner)
        {
            Errors = new LogicErrors {error};
        }

        public LogicException(LogicError error)
            : this(string.Empty, error)
        {
        }

        public LogicException(LogicError error, Exception inner)
            : this(string.Empty, error, inner)
        {
        }

        protected LogicException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Errors = new LogicErrors();
        }

        public LogicException(string message, LogicErrors errors)
            : base(message)
        {
            Errors = errors;
        }
        public LogicException(LogicErrors errors)
            : this(errors.GetCombinedMessages(), errors)
        {

        }
        public override string Message
        {
            get
            {
                var currentMessage = base.Message;
                if (!string.IsNullOrWhiteSpace(currentMessage))
                    return currentMessage;
                if (Errors.Count == 0)
                    return string.Empty;
                if (Errors.Count == 1)
                    return Errors.First().Message;
                var stringBuilder = new StringBuilder();
                for (int index = 0; index < Errors.Count; index++)
                {
                    var logicError = Errors[index];
                    stringBuilder.AppendFormat("Error #{0}: {1}\r\n", index + 1, logicError.Message);
                }
                return stringBuilder.ToString();
            }
        }

        public LogicErrors Errors { get; set; }
    }
}
