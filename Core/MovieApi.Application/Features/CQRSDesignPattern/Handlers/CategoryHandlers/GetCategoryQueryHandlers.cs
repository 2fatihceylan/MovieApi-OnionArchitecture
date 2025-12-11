using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResult;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandlers
    {


        private readonly MovieContext _context;


        public GetCategoryQueryHandlers(MovieContext context)
        {
            _context = context;
        }



        public async Task<List<GetCategoryQueryResult>> Handle()
        {

            var values = await _context.Categories.ToListAsync();

            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                CategoryName =  x.CategoryName
            }).ToList();


        }
    }
}
