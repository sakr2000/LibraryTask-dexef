using System.Net;
using LibraryTask_dexef.Application.Common.Exceptions;
using LibraryTask_dexef.Domain;
using LibraryTask_dexef.Domain.Constants;
using LibraryTask_dexef.Shared.Enums;
using Microsoft.AspNetCore.Diagnostics;

namespace LibraryTask_dexef.WebApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                AllowStatusCode404Response = true,
                ExceptionHandler = async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var errorId = Guid.NewGuid();

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        string errorMessage = string.Empty;
                        string errorCode = string.Empty;

                        if (contextFeature.Error is FriendlyException FriendlyException)
                        {
                            switch (FriendlyException.ErrorCode)
                            {
                                case ErrorCode.NotFound:
                                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                                    errorMessage = FriendlyException.FriendlyMessage;
                                    errorCode = $"{ApplicationConstants.Name}.{ErrorRespondCode.NOT_FOUND}";
                                    break;
                                case ErrorCode.VersionConflict:
                                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                                    errorMessage = FriendlyException.FriendlyMessage;
                                    errorCode = $"{ApplicationConstants.Name}.{ErrorRespondCode.VERSION_CONFLICT}";
                                    break;
                                case ErrorCode.ItemAlreadyExists:
                                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                                    errorMessage = FriendlyException.FriendlyMessage;

                                    errorCode = $"{ApplicationConstants.Name}.{ErrorRespondCode.ITEM_ALREADY_EXISTS}";
                                    break;
                                case ErrorCode.Conflict:
                                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                                    errorMessage = FriendlyException.FriendlyMessage;

                                    errorCode = $"{ApplicationConstants.Name}.{ErrorRespondCode.CONFLICT}";
                                    break;
                                case ErrorCode.BadRequest:
                                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                    errorMessage = FriendlyException.FriendlyMessage;
                                    errorCode = $"{ApplicationConstants.Name}.{ErrorRespondCode.BAD_REQUEST}";
                                    break;
                                case ErrorCode.Unauthorized:
                                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                    errorMessage = FriendlyException.FriendlyMessage;
                                    errorCode = $"{ApplicationConstants.Name}.{ErrorRespondCode.UNAUTHORIZED}";
                                    break;
                                case ErrorCode.Internal:
                                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                    errorMessage = FriendlyException.FriendlyMessage;
                                    errorCode = $"{ApplicationConstants.Name}.{ErrorRespondCode.INTERNAL_ERROR}";
                                    break;
                                case ErrorCode.UnprocessableEntity:
                                    context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                                    errorMessage = FriendlyException.FriendlyMessage;
                                    errorCode = $"{ApplicationConstants.Name}.{ErrorRespondCode.UNPROCESSABLE_ENTITY}";
                                    break;
                                default:
                                    context.Response.StatusCode = 500;
                                    errorMessage = FriendlyException.FriendlyMessage;
                                    errorCode = $"{ApplicationConstants.Name}.{ErrorRespondCode.GENERAL_ERROR}";
                                    break;
                            }
                        }
                        else
                        {
                            context.Response.StatusCode = 500;
                            errorCode = $"{ApplicationConstants.Name}.{ErrorRespondCode.GENERAL_ERROR}";
                            errorMessage = "An error has occurred.";
                        }
                        await context.Response.WriteAsync(new Error(errorCode, errorMessage, errorId));
                        logger.LogError("ErrorId:{errorId} Exception:{contextFeature.Error}", errorId, contextFeature.Error);
                    }
                }
            });
        }
    }
}