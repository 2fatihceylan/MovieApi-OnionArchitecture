using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {


        private readonly MovieContext _context;


        public GetTagByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }




        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Tags.FindAsync(request.TagId);

            return new GetTagByIdQueryResult
            {
                TagId = value.TagId,
                Title = value.Title 
            };
        }
    }
}
