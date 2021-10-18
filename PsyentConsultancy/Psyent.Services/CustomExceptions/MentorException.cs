using System;

namespace Psyent.Services.CustomExceptions
{
    public class MentorException : Exception
    {
        public MentorException() { }

        public MentorException(string message) : base(message) { }

        public MentorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
