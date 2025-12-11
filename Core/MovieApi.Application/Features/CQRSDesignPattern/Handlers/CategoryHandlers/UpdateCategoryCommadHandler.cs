using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommadHandler
    {

        private readonly MovieContext _context;


        public UpdateCategoryCommadHandler(MovieContext context)
        {
            _context = context;
        }



        public async void Handle(UpdateCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.CategoryId);

            value.CategoryName = command.CategoryName;


            await _context.SaveChangesAsync();

        }
    }
}
