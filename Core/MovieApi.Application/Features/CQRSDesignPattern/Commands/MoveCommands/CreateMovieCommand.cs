using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MoveCommands
{
    public class CreateMovieCommand
    {

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
