using System;
namespace Common.Errors
{
    public class UpSertFailException : AppException
    {
        public UpSertFailException() : base("Update or Insert has been failed")

        {
        }
    }
}

