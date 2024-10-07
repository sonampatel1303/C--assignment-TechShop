using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.Exceptions
{
    // Base exception class
    public class MyException : Exception
    {
        public MyException(string message) : base(message) { }
    }

    // Invalid data exception for validation scenarios
    public class InvalidEmailException : MyException
    {
        public InvalidEmailException(string message) : base(message) { }
    }

    // Exception for insufficient stock situations
    public class InsufficientStockException : MyException
    {
        public InsufficientStockException(string message) : base(message) { }
    }

    // Exception for incomplete order details
    public class IncompleteOrderException : MyException
    {
        public IncompleteOrderException(string message) : base(message) { }
    }

    // Exception for payment failures
    public class PaymentFailedException : MyException
    {
        public PaymentFailedException(string message) : base(message) { }
    }

    // Exception for file I/O errors
    public class FileIOException : MyException
    {
        public FileIOException(string message) : base(message) { }
    }

    // Exception for database access issues
    public class DatabaseAccessException : MyException
    {
        public DatabaseAccessException(string message) : base(message) { }
    }

    // Exception for concurrency control issues
    public class ConcurrencyException : MyException
    {
        public ConcurrencyException(string message) : base(message) { }
    }

    // Exception for authentication failures
    public class AuthenticationException : MyException
    {
        public AuthenticationException(string message) : base(message) { }
    }

    // Exception for authorization issues
    public class AuthorizationException : MyException
    {
        public AuthorizationException(string message) : base(message) { }
    }

}
