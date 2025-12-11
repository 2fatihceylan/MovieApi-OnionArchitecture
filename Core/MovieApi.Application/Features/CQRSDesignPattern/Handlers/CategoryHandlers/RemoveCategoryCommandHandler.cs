using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {


        private readonly MovieContext _context;


        public RemoveCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }





        public async Task Handle(RemoveCategoryCommand command)
        {

            var value = await _context.Categories.FindAsync(command.CategoryId);



            _context.Categories.Remove(value);


            await _context.SaveChangesAsync();
        }
    }
}
