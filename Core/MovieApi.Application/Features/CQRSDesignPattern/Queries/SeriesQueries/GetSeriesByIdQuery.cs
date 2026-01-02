using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.SeriesQueries
{
    public class GetSeriesByIdQuery
    {


        public GetSeriesByIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }

        public int SeriesId { get; set; }
    }
}
