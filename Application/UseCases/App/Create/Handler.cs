using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Cold;
using Domain.Records;
using Domain.ValueObjects;
using Grpc.Core;
using MediatR;

namespace Application.UseCases.App.Create;

public class Handler : IRequestHandler<Request, BaseResponse>
{
    private readonly IAppRepository _appRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IDbCommit _dbCommit;

    public Handler(IAppRepository appRepository, ICategoryRepository categoryRepository, IDbCommit dbCommit)
    {
        _appRepository = appRepository;
        _categoryRepository = categoryRepository;
        _dbCommit = dbCommit;
    }
    public async Task<BaseResponse> Handle(Request request, CancellationToken cancellationToken)
    {
        if(await _appRepository.GetWithParametersAsync(x => x.Name.Name.Equals(request.name), cancellationToken) is not null)
             return new BaseResponse(400,"App already exists");

        var category = await _categoryRepository.GetWithParametersAsync(x => 
            x.Id.Equals(request.categoryId), cancellationToken);

        if(category is null) new BaseResponse(404, "Category not found");

        var app = new Domain.Entities.App(
            new UniqueName(request.name),
            category,
            request.environment,
            null, true);

        if(app.Notifications.Any()) return new BaseResponse(400, 
            "Some problems occurred when creating app", app.Notifications.ToList());

        await _appRepository.CreateAsync(app, cancellationToken);
        await _dbCommit.Commit(cancellationToken);
        return new BaseResponse(200,"App created successfully");
    }
}
