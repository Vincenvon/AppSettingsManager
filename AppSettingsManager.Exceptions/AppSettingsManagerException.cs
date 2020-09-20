using System;

namespace AppSettingsManager.Exceptions
{
    public class AppSettingsManagerException: Exception
    {
        public AppSettingsManagerException() : base()
        {
        }

        public AppSettingsManagerException(string message) : base(message)
        {
        }

        public AppSettingsManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
