using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApi.Domain.Entities
{
    public class Series
    {

        public int SeriesId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Rating { get; set; }
        public string Description { get; set; }
        public DateTime FirstAirDate { get; set; }
        public int CreatedYear { get; set; }
        public string Status { get; set; }


        public int? AverageEpisodeDuration { get; set; }
        public int SeasonCount { get; set; }
        public int EpisodeCount { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
