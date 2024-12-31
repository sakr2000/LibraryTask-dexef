using LibraryTask_dexef.Shared.Enums;

namespace LibraryTask_dexef.Application.Common.Exceptions
{
    public class FriendlyException : Exception
    {
        public string FriendlyMessage { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public FriendlyException(ErrorCode errorCode, string userFriendlyMessage, Exception? innerException = null) : base(userFriendlyMessage, innerException)
        {
            ErrorCode = errorCode;
            FriendlyMessage = userFriendlyMessage;
        }
        public FriendlyException(string message, string userFriendlyMessage, Exception? innerException = null) : base(message, innerException)
        {
            FriendlyMessage = userFriendlyMessage;
        }
        public FriendlyException(ErrorCode errorCode, string message, string userFriendlyMessage, Exception? innerException = null) : base(message, innerException)
        {
            ErrorCode = errorCode;
            FriendlyMessage = userFriendlyMessage;
        }
    }
}
