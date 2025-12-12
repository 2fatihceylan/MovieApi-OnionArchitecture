using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand>
    {



        private readonly MovieContext _context;


        public RemoveTagCommandHandler(MovieContext context)
        {
            _context = context;
        }




        public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Tags.FindAsync(request.TagId);
            _context.Tags.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
