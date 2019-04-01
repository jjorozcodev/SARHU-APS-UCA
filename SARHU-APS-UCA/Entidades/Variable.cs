using System;

namespace Entidades
{
    public class Variable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
}