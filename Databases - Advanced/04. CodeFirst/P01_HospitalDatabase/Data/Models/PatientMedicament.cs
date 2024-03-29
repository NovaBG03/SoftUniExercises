﻿namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PatientsMedicaments")]
    public class PatientMedicament
    {
        public int PatientId { get; set; }

        public int MedicamentId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; }

        [ForeignKey(nameof(MedicamentId))]
        public Medicament Medicament { get; set; }
    }
}
