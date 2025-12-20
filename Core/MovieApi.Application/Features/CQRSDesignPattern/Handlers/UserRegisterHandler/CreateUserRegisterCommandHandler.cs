using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using MovieApi.Persistance.Context;
using MovieApi.Persistance.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandler
{
    public class CreateUserRegisterCommandHandler
    {


        private readonly MovieContext _movieContext;

        private readonly UserManager<AppUser> _userManager;


        public CreateUserRegisterCommandHandler(MovieContext context, UserManager<AppUser> userManager)
        {
            _movieContext = context;
            _userManager = userManager;
        }





        public async Task Handle(CreateUserRegisterCommand command)
        {
            var user = new AppUser()
            {
                Name = command.Name,
                Surname = command.Surname,
                Email = command.Email,
                UserName = command.Username
            };



            await _userManager.CreateAsync(user, command.Password);

            




        }


    }
}
