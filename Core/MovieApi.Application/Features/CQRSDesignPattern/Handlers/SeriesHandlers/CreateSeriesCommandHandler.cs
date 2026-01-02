using MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class CreateSeriesCommandHandler
    {


        private readonly MovieContext _context;


        public CreateSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }




        public async Task Handle(CreateSeriesCommand command)
        {
            _context.Serieses.Add(new Series
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                FirstAirDate = command.FirstAirDate,
                CreatedYear = command.CreatedYear,
                Status = command.Status,
                AverageEpisodeDuration = command.AverageEpisodeDuration,
                SeasonCount = command.SeasonCount,
                EpisodeCount = command.EpisodeCount,
                CategoryId = command.CategoryId

            });

            await _context.SaveChangesAsync();
        }


    }
}
