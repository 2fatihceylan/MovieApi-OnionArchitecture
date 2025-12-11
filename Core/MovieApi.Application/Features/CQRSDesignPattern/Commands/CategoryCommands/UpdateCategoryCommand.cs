using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
