﻿namespace TeisterMask.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        public Project()
        {
            this.Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }

        [MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
