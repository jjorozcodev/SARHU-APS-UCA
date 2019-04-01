using System;
namespace Entidades
{
    public class Adendum
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public decimal IncrementoSalarial { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public string Observaciones { get; set; }
        public bool Estado { get; set; }
    }
}
