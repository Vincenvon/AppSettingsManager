using System;

namespace AppSettingsManager.Exceptions
{
    public class WrongCredentialsException: AppSettingsManagerException
    {
        public WrongCredentialsException() : base()
        {
        }

        public WrongCredentialsException(string message) : base(message)
        {
        }

        public WrongCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
