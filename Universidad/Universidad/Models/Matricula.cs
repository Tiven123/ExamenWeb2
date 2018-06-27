using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public partial class Matricula
    {
        [DisplayName("Codigo")]
        public int Idmatricula { get; set; }
        public int? Idalumno { get; set; }
        [DisplayName("Profesor")]
        public int? Idprofesor { get; set; }
        [DisplayName("Materia")]
        public int? Idmateria { get; set; }
        public double? Nota { get; set; }

        public Alumno IdalumnoNavigation { get; set; }
        public Materia IdmateriaNavigation { get; set; }
        public Profesor IdprofesorNavigation { get; set; }
    }
}
