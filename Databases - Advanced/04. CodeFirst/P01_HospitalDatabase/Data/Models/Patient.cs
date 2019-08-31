namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Patients")]
    public class Patient
    {
        public Patient()
        {
            this.Visitations = new HashSet<Visitation>();
            this.Diagnoses = new HashSet<Diagnose>();
            this.Prescriptions = new HashSet<PatientMedicament>();
        }

        [Key]
        public int PatientId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(80)")]
        [EmailAddress]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        [InverseProperty(nameof(Visitation.Patient))]
        public ICollection<Visitation> Visitations { get; set; }

        [InverseProperty(nameof(Diagnose.Patient))]
        public ICollection<Diagnose> Diagnoses { get; set; }

        [InverseProperty(nameof(PatientMedicament.Patient))]
        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
