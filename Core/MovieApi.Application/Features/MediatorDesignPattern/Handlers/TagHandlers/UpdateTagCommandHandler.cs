using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {


        private readonly MovieContext _context;



        public UpdateTagCommandHandler(MovieContext context)
        {
            _context = context;
        }



        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {

            var value = await _context.Tags.FindAsync(request.TagId);

            value.Title = request.Title;

            await _context.SaveChangesAsync();
        }
    }
}
