using System;

namespace DatabaseModelCreator
{
    static class ValidationHelper
    {
        public static (bool, string) ValidateConnString(string connString)
        {
            // Check if connection string is empty
            if (string.IsNullOrWhiteSpace(connString))
            {
                return(false, "Please enter a connection string first");
            }

            // Check valid connection string
            if (!DatabaseHelper.CheckValidConnection(connString))
            {
                return(false, "Not a valid connection string");
            }

            return (true, string.Empty);
        }
    }
}
