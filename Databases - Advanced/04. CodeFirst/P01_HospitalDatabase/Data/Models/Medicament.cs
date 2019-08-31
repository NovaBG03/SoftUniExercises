namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Medicaments")]
    public class Medicament
    {
        public Medicament()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
        }

        [Key]
        public int MedicamentId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [InverseProperty(nameof(PatientMedicament.Medicament))]
        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
