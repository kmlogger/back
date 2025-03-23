using Domain.Records;
using MediatR;

using Environment = Domain.Enums.Environment;

namespace Application.UseCases.App.Create;

public record  Request
(
    string name, 
    Guid categoryId,
    Environment environment
): IRequest<BaseResponse>;
