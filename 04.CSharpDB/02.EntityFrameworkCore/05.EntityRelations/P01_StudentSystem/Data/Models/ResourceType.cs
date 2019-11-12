using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public enum ResourceType
    {
        Video = 1,
        Presentation = 2,
        Document = 3,
        Other = 99
    }
}
