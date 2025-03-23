using System;
using Domain.Interfaces;
using Domain.Interfaces.Repositories.Cold;
using Domain.Records;
using MediatR;

namespace Application.UseCases.Category.Delete;

public class Handler : IRequestHandler<Request, BaseResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IDbCommit _dbCommit;
    public Handler(ICategoryRepository repository, IDbCommit dbCommit)
    {
        _categoryRepository = repository;
        _dbCommit = dbCommit;
    }

    public async Task<BaseResponse> Handle(Request request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetWithParametersAsync(x => x.Id.Equals(request.id), 
            cancellationToken);

        if (category is null) new BaseResponse(404, "Category not found");
        
        await _categoryRepository.DeleteAsync(category, cancellationToken);
        await _dbCommit.Commit(cancellationToken);
        return new BaseResponse(201, "Category deleted successfully");
    }
}
