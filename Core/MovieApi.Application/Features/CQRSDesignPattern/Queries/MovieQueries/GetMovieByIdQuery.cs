using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries
{
    public class GetMovieByIdQuery
    {


        public GetMovieByIdQuery(int movieId)
        {
            MovieId= movieId;
        }

        public int MovieId { get; set; }
    
    }
}
