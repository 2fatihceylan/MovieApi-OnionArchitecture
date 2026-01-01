using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Dto.Dtos.AdminCastDtos
{
    public class AdminCreateCastDto
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string? Overview { get; set; }
        public string? Biography { get; set; }
    }
}
