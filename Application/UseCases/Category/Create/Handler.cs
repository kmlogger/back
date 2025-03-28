using System;
using Domain.Interfaces;
using Domain.Interfaces.Repositories.Cold;
using Domain.Records;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Category.Create;

public class Handler : IRequestHandler<Request, BaseResponse>
{
    private readonly ICategoryRepository  _categoryRepository;
    private readonly IDbCommit _dbCommit;
    public Handler(ICategoryRepository categoryRepository, IDbCommit dbCommit)
    {
        _categoryRepository = categoryRepository;
        _dbCommit = dbCommit;
    }
    public async Task<BaseResponse> Handle(Request request, CancellationToken cancellationToken)
    {
        if(await _categoryRepository.GetAllWithParametersAsync(x => x.Name.Name.Trim()
            .Equals(request.name.Trim()), cancellationToken) is not null) 
            new BaseResponse(400, "Category already exists");

        var category = new Domain.Entities.Category
            (new UniqueName(request.name), true);

        if (category.Notifications.Any()) new BaseResponse(400, "An ocurred Errors in create Category", 
            category.Notifications.ToList());

        await _categoryRepository.CreateAsync(category, cancellationToken);
        await _dbCommit.Commit(cancellationToken);
        return new BaseResponse(0, "Category created successfully", null, null);
    }
}