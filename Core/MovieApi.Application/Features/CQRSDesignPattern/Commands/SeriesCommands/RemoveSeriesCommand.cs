using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommands
{
    public class RemoveSeriesCommand
    {

        public RemoveSeriesCommand(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; set; }
    }
}
