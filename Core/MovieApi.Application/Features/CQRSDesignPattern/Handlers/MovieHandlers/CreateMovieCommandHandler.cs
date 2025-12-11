using MovieApi.Application.Features.CQRSDesignPattern.Commands.MoveCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {

        private readonly MovieContext _context;

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }




        //asagıda AutoMapper kullanılmadıgı için manuel olarak atama yapıldı
        //eğer AutoMapper kullanılsaydı, mapping işlemi otomatik olarak yapılabilirdi

        public async Task Handle(CreateMovieCommand command)
        {
            _context.Movies.Add(new Movie
            {
                CoverImageUrl = command.CoverImageUrl,
                CreatedYear = command.CreatedYear,
                Description = command.Description,
                Duration = command.Duration,
                Rating = command.Rating,
                ReleaseDate = command.ReleaseDate,
                Status = command.Status,
                Title = command.Title
            });

            await _context.SaveChangesAsync();
        }
    }
}
