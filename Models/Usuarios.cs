using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa.Models
{
    public partial class Usuarios
    {
        [Key]
        [Column("id_Usuario")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage="Ingrese Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage="Ingrese Apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required(ErrorMessage="Ingrese Edad")]
        [Range(18,120,ErrorMessage="Ingrese Edad mayor a 18 años")]
        public int Edad { get; set; }
        [Required(ErrorMessage="Ingrese Email")]
        [EmailAddress(ErrorMessage="Ingrese Email valido")]
        public string Email { get; set; }
    }
}
