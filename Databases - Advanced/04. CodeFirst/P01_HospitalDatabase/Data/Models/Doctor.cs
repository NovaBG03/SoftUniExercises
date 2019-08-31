namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Doctors")]
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }

        [Key]
        public int DoctorId { get; set; }

        [Column(TypeName = "nvarchar(100)")] 
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Specialty { get; set; }

        [InverseProperty(nameof(Visitation.Doctor))]
        public ICollection<Visitation> Visitations { get; set; }
    }
}
