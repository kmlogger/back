using System;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Cold;
using Domain.Records;
using MediatR;

namespace Application.UseCases.App.Read.ReadAll;

public class Handler : IRequestHandler<Request, BaseResponse>
{
    private readonly IAppRepository _appRepository;
    public Handler(IAppRepository appRepository)
    {
        _appRepository = appRepository;
    }
    public async Task<BaseResponse> Handle(Request request, CancellationToken cancellationToken)
    => new BaseResponse(200, "Apps retrieved successfully", null, 
        await _appRepository.GetAll(cancellationToken, request.skip, request.take));
}
