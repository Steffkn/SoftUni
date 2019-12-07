﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public ExecutionType ExecutionType { get; set; }
        [Required]
        public LabelType LabelType { get; set; }
        
        // TODO? ForeighKey
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<EmployeeTask> EmployeesTasks { get; set; }
    }
}
