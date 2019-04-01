using System;

namespace Entidades
{
    public class Adelanto
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaDeduccion { get; set; }
        public string Descripcion { get; set; }
        public bool Cancelado { get; set; }
        public bool Estado { get; set; }
    }
}
