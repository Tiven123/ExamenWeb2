using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public partial class Materia
    {
        public Materia()
        {
            Matricula = new HashSet<Matricula>();
        }
        [DisplayName("Codigo")]
        public int Idmateria { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20)]
        public string Nombre { get; set; }
        public int? Estado { get; set; }
        public double Precio { get; set; }

        public ICollection<Matricula> Matricula { get; set; }
    }
}
