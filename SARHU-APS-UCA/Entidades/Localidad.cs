namespace Entidades
{
    public class Localidad
    {
        public int Id { get; set; }
        public int ProgramaId { get; set; }
        public int MunicipioId { get; set; }
        public int DirectorId { get; set; }
        public string Alias { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
    }
}
