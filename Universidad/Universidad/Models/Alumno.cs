using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public partial class Alumno
    {

        public Alumno()
        {
            Matricula = new HashSet<Matricula>();
        }
        [DisplayName("Cedula")]
        public int Idalumno { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20)]
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public ICollection<Matricula> Matricula { get; set; }
    }
}
