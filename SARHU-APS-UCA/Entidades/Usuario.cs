namespace Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
    }
}
