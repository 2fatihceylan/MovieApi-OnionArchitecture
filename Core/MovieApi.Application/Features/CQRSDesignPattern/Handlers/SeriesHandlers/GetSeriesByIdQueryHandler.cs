using MovieApi.Application.Features.CQRSDesignPattern.Queries.SeriesQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.SeriesResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class GetSeriesByIdQueryHandler
    {

        private readonly MovieContext _context;

        public GetSeriesByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }



        public async Task<GetSeriesByIdQueryResult> Handle(GetSeriesByIdQuery query)
        {
            var value = await _context.Serieses.FindAsync(query.SeriesId);

            return new GetSeriesByIdQueryResult
            {
                SeriesId = value.SeriesId,
                Title = value.Title,
                CoverImageUrl = value.CoverImageUrl,
                Rating = value.Rating,
                Description = value.Description,
                FirstAirDate = value.FirstAirDate,
                CreatedYear = value.CreatedYear,
                Status = value.Status,
                AverageEpisodeDuration = value.AverageEpisodeDuration,
                SeasonCount = value.SeasonCount,
                EpisodeCount = value.EpisodeCount,
                CategoryId = value.CategoryId
            };
        }


    }
}
