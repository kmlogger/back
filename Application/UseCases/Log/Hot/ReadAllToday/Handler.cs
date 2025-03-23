using System;
using Domain.Interfaces.Repositories.Hot;
using Domain.Records;
using MediatR;

namespace Application.UseCases.Log.Hot.ReadAllToday;

public class Handler : IRequestHandler<Request, BaseResponse>
{
    private readonly ILogRepository _logRepository;
    public Handler(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<BaseResponse> Handle(Request request, CancellationToken cancellationToken)
    {
        var logs = await _logRepository.GetAllWithParametersAsync(x => x.CreatedDate.Value.Day.Equals(DateTime.Today)
        ,cancellationToken,
        request.skip, request.take);

        if(logs is null) return new BaseResponse(404, "No log found for today");
        return new BaseResponse(200, "Logs found", null, logs);
    }
}
