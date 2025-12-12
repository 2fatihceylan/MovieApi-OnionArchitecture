using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {


        private readonly MovieContext _context;



        public RemoveCastCommandHandler(MovieContext context)
        {
            _context = context;
        }






        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Casts.FindAsync(request.CastId);
            _context.Casts.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
