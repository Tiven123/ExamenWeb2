using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            Matricula = new HashSet<Matricula>();
        }
        [DisplayName("Codigo")]
        public int Idprofesor { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20)]
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int? Estado { get; set; }

        public ICollection<Matricula> Matricula { get; set; }
    }
}
