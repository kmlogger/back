using System;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Cold;
using Domain.Records;
using MediatR;

namespace Application.UseCases.Log.Cold.Read.ReadByInterval;

public class Handler : IRequestHandler<Request, BaseResponse>
{
    private readonly ILogRepository _logRepository;

    public Handler(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<BaseResponse> Handle(Request request, CancellationToken cancellationToken)
    {
        var logs = await _logRepository.GetAllWithParametersAsync(
             x => x.CreatedDate >= request.StartDate && x.CreatedDate <= request.EndDate,
             cancellationToken,
             request.skip, request.take
        );
        if(logs is null) new BaseResponse(404, "Log not found");
        return new BaseResponse(200, "Logs retrieved successfully", null, logs);
    }
}
