using System;
namespace CourseManager.Exceptions
{
    public class CourseNotFoundException : Exception
    {
        public CourseNotFoundException( string message ) : base ( message )
        {
        }

        public CourseNotFoundException( string message, Exception inner ) : base( message, inner)
        {

        }
    }
}
