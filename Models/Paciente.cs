using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Runtime.Intrinsics.X86;

namespace RegistroPacientes.Models
{
    [Table(name: "P_Paciente")]
    public class Paciente
    {
        [Key]
        [Column("COD_PAC")]
        public int cod_pac {  get; set; }
        
        [DisplayName("Apellido Paterno")]
        [Required(ErrorMessage = "Ingrese el Apellido Paterno")]

        public string app_pate { get; set; }

        [DisplayName("Apellido Materno")]
        [Required(ErrorMessage = "Ingrese el Apellido Materno")]
        public string app_mate { get; set; }

        [DisplayName("Nombres")]
        [Required(ErrorMessage = "Ingrese los Nombres")]
        public string nom_paci { get; set; }

        [DisplayName("Distrito")]
        [Required(ErrorMessage = "Ingrese el Distrito")]
        public int cod_dist { get; set; }

        [DisplayName("Direccion")]
        [Required(ErrorMessage = "Ingrese la Direccion")]
        public string des_direcc { get; set; }

        [DisplayName("Fecha de Registro")]
        [Required(ErrorMessage = "Ingrese el Fecha de Registro")]
        public DateTime fec_registro { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Ingrese el Estado")]
        public int cod_esta { get; set; }

    }

    public class PacienteContext : DbContext
    {
        public PacienteContext(DbContextOptions options) : base(options) { }
        public DbSet<Paciente> Pacientes { get; set; }
    }


}
