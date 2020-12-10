using System;

namespace Hostel.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        private const string ExceptionMessage = "Bad Request";
        
        public BadRequestException(): base(ExceptionMessage)
        {
            
        }
    }
}