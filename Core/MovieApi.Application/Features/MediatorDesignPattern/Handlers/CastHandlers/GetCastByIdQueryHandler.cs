using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {



        private readonly MovieContext _context;


        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }





        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {

            var value = await _context.Casts.FindAsync(request.CastId);

            return new GetCastByIdQueryResult
            {
                Biography = value.Biography,
                CastId = value.CastId,
                ImageUrl = value.ImageUrl,
                Name = value.Name,
                Overview = value.Overview,
                Surname = value.Surname,
                Title = value.Title


            };


        }
    }
}
