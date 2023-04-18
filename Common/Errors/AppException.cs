using System;
namespace Common.Errors
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {
        }
    }
}

