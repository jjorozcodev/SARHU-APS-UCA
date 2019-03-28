using System;

namespace Entidades
{
    public class INSS
    {
        public int Id { get; set; }
        public decimal Porcentaje { get; set; }
        public bool Patronal { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
}
