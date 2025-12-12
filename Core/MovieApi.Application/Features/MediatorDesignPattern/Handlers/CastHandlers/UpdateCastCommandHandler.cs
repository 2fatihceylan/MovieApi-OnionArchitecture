using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {

        private readonly MovieContext _context;


        public UpdateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }




        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Casts.FindAsync(request.CastId);
            value.Title = request.Title;
            value.Name = request.Name;
            value.Surname = request.Surname;
            value.ImageUrl = request.ImageUrl;
            value.Overview = request.Overview;
            value.Biography = request.Biography;
            await _context.SaveChangesAsync();
        }
    }
}
