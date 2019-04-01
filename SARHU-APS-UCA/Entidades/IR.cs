using System;

namespace Entidades
{
    public class IR
    {
        public int Id { get; set; }
        public decimal Desde { get; set; }
        public decimal Hasta { get; set; }
        public decimal Base { get; set; }
        public decimal Exceso { get; set; }
        public decimal PorcentajeAplicable { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
}
