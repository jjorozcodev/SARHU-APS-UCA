using System;

namespace Entidades
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Foto { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public bool Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int EstadoCivilId { get; set; }
        public int NivelAcademicoId { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string SeguroSocial { get; set; }
        public bool Banco { get; set; }
        public string CuentaBanco { get; set; }
        public int LocalidadId { get; set; }
        public int PuestoId { get; set; }
        public string Observaciones { get; set; }
        public bool Estado { get; set; }
    }
}