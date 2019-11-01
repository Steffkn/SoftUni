﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiniORM.App.Data.Entities
{
    public class Projects
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<EmployeesProjects> EmployeesProjects { get; }
    }
}
