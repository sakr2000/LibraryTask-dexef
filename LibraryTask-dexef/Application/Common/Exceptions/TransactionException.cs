using LibraryTask_dexef.Application.Common.Exceptions;
using LibraryTask_dexef.Domain.Constants;
using LibraryTask_dexef.Shared.Enums;
using System.Diagnostics.CodeAnalysis;

namespace libraryTask_dexef.Application.Common.Exceptions
{

    [ExcludeFromCodeCoverage]
    public static class TransactionException
    {
        public static FriendlyException TransactionNotCommitException()
            => throw new FriendlyException(ErrorCode.Internal, ErrorMessage.TransactionNotCommit, ErrorMessage.TransactionNotCommit);

        public static FriendlyException TransactionNotExecuteException(Exception ex)
            => throw new FriendlyException(ErrorCode.Internal, ErrorMessage.TransactionNotExecute, ErrorMessage.TransactionNotExecute, ex);
    }
}