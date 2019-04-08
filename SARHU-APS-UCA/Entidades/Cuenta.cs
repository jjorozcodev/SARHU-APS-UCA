namespace Entidades
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string CodigoContable { get; set; }
        public string CuentaSalario { get; set; }
        public string CuentaImpuestos { get; set; }
        public string CuentaSeguros { get; set; }
        public bool Planilla { get; set; }
        public bool Estado { get; set; }
    }
}
