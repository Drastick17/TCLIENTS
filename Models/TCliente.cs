using System.ComponentModel.DataAnnotations;

namespace TCLIENTS.Models
{
    public class TCliente
    {
        [Key]
        public int CLI_Id { get; set; }
        public string? CLI_Identificacion { get; set; }
        public string? CLI_TipoIdentificacion { get; set; }
        public string? CLI_NombrePrincipal { get; set; }
        public string? CLI_NombreSecundario { get; set; }
        public string? CLI_ApellidoPaterno { get; set; }
        public string? CLI_ApellidoMaterno { get; set; }
        public string? CLI_Direccion { get; set; }
        public string? CLI_Telefono { get; set; }
        public string? CLI_Correo { get; set; }
        public DateTime CLI_FechaNacimiento { get; set; }
        public DateTime CLI_FechaCreacion { get; set; }
        public int CLI_Estado { get; set; }
    }
}
