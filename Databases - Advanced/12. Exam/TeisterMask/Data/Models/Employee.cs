namespace TeisterMask.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public Employee()
        {
            this.EmployeesTasks = new HashSet<EmployeeTask>();
        }

        public int Id { get; set; }

        [MinLength(3), MaxLength(40)]
        [RegularExpression("[A-Za-z0-9]+")]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("^([0-9]{3}-){2}[0-9]{4}$")]
        public string Phone { get; set; }

        public ICollection<EmployeeTask> EmployeesTasks  { get; set; }
    }
}
