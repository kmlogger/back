using Domain.Records;
using Domain.ValueObjects;
using MediatR;

using Environment = Domain.Enums.Environment;

namespace Application.UseCases.Log.Hot.Create;

public record Request(
    Guid AppId,
    string Message,
    string Level,
    string? StackTrace,
    string? Source,
    Environment Environment
) : IRequest<BaseResponse>;
