using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Dto.Dtos.AdminMovieDtos
{
    public class AdminCreateMovieDto
    {
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }

        public decimal? Rating { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CreatedYear { get; set; }
        public string Status { get; set; }

        public int CategoryId { get; set; }
    }
}
