namespace Entidades
{
    public class Bitacora
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int OperacionId { get; set; }
        public string Tabla { get; set; }
    }
}
