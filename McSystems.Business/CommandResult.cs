using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystems.Business
{
    public class CommandResult
    {
        private static string DefaultFailureMessage="İşlem Başarısız";
        private static string DefaultSuccessMessage = "İşlem Başarılı";

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public string ErrorMessage { get; private set; }

        internal static CommandResult Failure( Exception ex)
        {
            return Failure(DefaultFailureMessage, ex);
        }

        internal static CommandResult Failure(string message,Exception ex)
        {
            return new CommandResult
            {
                IsSuccess = false,
                Message = message,
                ErrorMessage = ex.ToString()
            };
        }
        internal static CommandResult Success(string message)
        {
            return new CommandResult
            {
                IsSuccess = true,
                Message = DefaultSuccessMessage,
                ErrorMessage=string.Empty
            };
        }
        internal static CommandResult Success()
        {
            return Success(DefaultSuccessMessage);
        }

    }
}
