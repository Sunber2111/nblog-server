using System;
namespace Common.Errors
{
    public class DeleteFailException : AppException
    {
        public DeleteFailException() : base("Delete has been failed")
        {
        }
    }
}

