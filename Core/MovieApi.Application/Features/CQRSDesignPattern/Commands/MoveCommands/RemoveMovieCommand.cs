using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MoveCommands
{
    public class RemoveMovieCommand
    {
        public int MovieId { get; set; }

    }
}
