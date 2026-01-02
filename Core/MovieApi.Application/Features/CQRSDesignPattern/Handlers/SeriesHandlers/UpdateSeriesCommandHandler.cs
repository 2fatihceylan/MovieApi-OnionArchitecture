using MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class UpdateSeriesCommandHandler
    {

        private readonly MovieContext _context;

        public UpdateSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }


        public async Task Handle(UpdateSeriesCommand command)
        {
            var value = await _context.Serieses.FindAsync(command.SeriesId);

         
            value.Title = command.Title;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Rating = command.Rating;
            value.Description = command.Description;
            value.FirstAirDate = command.FirstAirDate;
            value.CreatedYear = command.CreatedYear;
            value.Status = command.Status;
            value.AverageEpisodeDuration = command.AverageEpisodeDuration;
            value.SeasonCount = command.SeasonCount;
            value.EpisodeCount = command.EpisodeCount;
            value.CategoryId = command.CategoryId;
            await _context.SaveChangesAsync();
        }
    }
}
