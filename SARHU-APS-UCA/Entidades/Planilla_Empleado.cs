using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Planilla_Empleado
    {
        public int Id { get; set; }
        public int Idlocalidad { get; set; }
        public int Iddirector { get; set; }
        public DateTime Fecha_elaboracion { get; set; }
        public int Idresponsable { get; set; }
        public DateTime Fecha_aprobacion { get; set; }
        public string Observacion { get; set; }
        public bool Guardado { get; set; }
        public bool Aprobado { get; set; }
        public bool Estado { get; set; }
    }
}
