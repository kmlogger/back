using System;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Hot;
using Domain.Records;
using Grpc.Core;
using MediatR;

using ILogRepository = Domain.Interfaces.Repositories.Hot.ILogRepository;
using IAppRepository = Domain.Interfaces.Repositories.Cold.IAppRepository;

namespace Application.UseCases.Log.Hot.Create;

public class Handler : IRequestHandler<Request, BaseResponse>
{
    private readonly ILogRepository _logRepository;
    private readonly IMapper _mapper;
    private readonly IDbCommit _dbCommit;

    private readonly IAppRepository _appRepository;

    public Handler(ILogRepository logRepository, IMapper mapper, IDbCommit dbCommit, IAppRepository appRepository)
    {
        _logRepository = logRepository;
        _mapper = mapper;
        _dbCommit = dbCommit;
        _appRepository = appRepository;
    }
    public async Task<BaseResponse> Handle(Request request, CancellationToken cancellationToken)
    {
        if(await _appRepository.GetWithParametersAsync(x => x.Id.Equals(request.AppId), cancellationToken) is null)
            return new BaseResponse(404, "App not found");

        var log = _mapper.Map<LogApp>(request);
        if(log.Notifications.Any()) new BaseResponse(400, "There were some problems when creating logs", log.Notifications.ToList());

        await _logRepository.CreateAsync(log, cancellationToken);
        await _dbCommit.Commit(cancellationToken);
        return new BaseResponse(201, "Log created successfully");
    }
}
