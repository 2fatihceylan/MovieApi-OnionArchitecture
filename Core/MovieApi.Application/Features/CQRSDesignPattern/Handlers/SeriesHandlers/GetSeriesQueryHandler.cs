using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.SeriesResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class GetSeriesQueryHandler
    {

        private readonly MovieContext _context;

        public GetSeriesQueryHandler(MovieContext context)
        {
            _context = context;
        }




        public async Task<List<GetSeriesQueryResult>> Handle()
        {
            var values = await _context.Serieses.ToListAsync();

            return values.Select(value => new GetSeriesQueryResult
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
            }).ToList();
        
        }
    }
}
