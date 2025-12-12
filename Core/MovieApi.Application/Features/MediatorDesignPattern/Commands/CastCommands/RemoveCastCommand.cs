using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    public class RemoveCastCommand : IRequest
    {

        public RemoveCastCommand(int castId)
        {
            CastId = castId;
        }


        public int CastId { get; set; }

    }
}
