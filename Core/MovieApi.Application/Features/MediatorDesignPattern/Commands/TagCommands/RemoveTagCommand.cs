using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class RemoveTagCommand : IRequest
    {


        public RemoveTagCommand(int tagId)
        {
            TagId = tagId;
        }

        public int TagId { get; set; }
    }
}
