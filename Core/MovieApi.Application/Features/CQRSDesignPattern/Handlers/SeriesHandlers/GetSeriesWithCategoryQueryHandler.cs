using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Application.Features.CQRSDesignPattern.Results.SeriesResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class GetSeriesWithCategoryQueryHandler
    {

        private readonly MovieContext _context;

        public GetSeriesWithCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }




        public async Task<List<GetSeriesWithCategoryQueryResult>> Handle()
        {
            var values = await _context.Serieses.Include(y => y.Category).ToListAsync();

            return values.Select(x => new GetSeriesWithCategoryQueryResult
            {
                SeriesId = x.SeriesId,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                Rating = x.Rating,
                Description = x.Description,
                AverageEpisodeDuration = x.AverageEpisodeDuration,
                FirstAirDate = x.FirstAirDate,
                EpisodeCount = x.EpisodeCount,
                SeasonCount = x.SeasonCount,
                CreatedYear = x.CreatedYear,
                Status = x.Status,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.CategoryName
            }).ToList();


        }
    }
}
