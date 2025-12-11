using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        //Commandlar genellikle işlem yapmak için gerekli verileri taşır.
        

        public string CategoryName { get; set; }

    }
}
