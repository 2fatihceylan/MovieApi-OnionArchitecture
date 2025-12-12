using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class UpdateTagCommand : IRequest
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}
