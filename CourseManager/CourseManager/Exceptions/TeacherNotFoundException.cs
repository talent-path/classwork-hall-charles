using System;
using System.Runtime.Serialization;

namespace CourseManager.Exceptions
{
    [Serializable]
    internal class TeacherNotFoundException : Exception
    {
        public TeacherNotFoundException()
        {
        }

        public TeacherNotFoundException(string message) : base(message)
        {
        }

        public TeacherNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TeacherNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}