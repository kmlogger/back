using System;
using Domain.Interfaces;
using Domain.Interfaces.Repositories.Cold;
using Domain.Records;
using MediatR;

namespace Application.UseCases.Category.Read.RealAll;

public class Handler : IRequestHandler<Request, BaseResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    public Handler(ICategoryRepository repository)
    {
        _categoryRepository = repository;
    }

    public async Task<BaseResponse> Handle(Request request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllWithParametersAsync(null,cancellationToken, 
            request.Skip, request.Take);
        return new BaseResponse(201, "Categories retrieved successfully", null, categories);
    }
}
