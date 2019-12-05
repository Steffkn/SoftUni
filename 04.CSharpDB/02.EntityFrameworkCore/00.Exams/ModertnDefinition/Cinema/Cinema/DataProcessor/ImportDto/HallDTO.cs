using Cinema.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class HallDTO
    {
        public string Name { get; set; }
        public bool Is4Dx { get; set; }
        public bool Is3D { get; set; }
        public int Seats { get; set; }
    }
}
