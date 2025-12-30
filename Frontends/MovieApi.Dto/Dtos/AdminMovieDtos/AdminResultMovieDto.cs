using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Dto.Dtos.AdminMovieDtos
{
    public class AdminResultMovieDto
    {

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }

        public decimal? Rating { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CreatedYear { get; set; }
        public bool Status { get; set; }
    }
}
