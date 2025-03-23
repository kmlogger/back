using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Hot;
using Domain.Records;
using MediatR;

namespace Application.UseCases.Log.Hot.Read.ReadByApp;

public class Handler : IRequestHandler<Request, BaseResponse>
{
    private readonly ILogRepository _logRepository;
    public Handler(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }
    public async Task<BaseResponse> Handle(Request request, CancellationToken cancellationToken)
    {
        var logs = await _logRepository.GetAllWithParametersAsync
            (x => x.AppId.Equals(request.AppId) && 
            x.CreatedDate >= request.StartDate && x.CreatedDate <= request.EndDate, cancellationToken);

        if(logs is null) new BaseResponse(404, "Logs not found");
        return new BaseResponse(0, "Logs found", null, logs);
    }
}
