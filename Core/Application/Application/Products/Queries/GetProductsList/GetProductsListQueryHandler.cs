﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Common.Interfaces;

namespace Northwind.Application.Products.Queries.GetProductsList;

public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductsListVm>
{
    private readonly INorthwindDbContext _context;
    private readonly IMapper _mapper;

    public GetProductsListQueryHandler(INorthwindDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductsListVm> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .OrderBy(p => p.ProductName)
            .ToListAsync(cancellationToken);


        var vm = new ProductsListVm() { Products = products, CreateEnabled = true };
        return vm;
    }
}
