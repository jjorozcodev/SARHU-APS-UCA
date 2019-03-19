namespace Entidades
{
    public class Localidad
    {
        public int Id { get; set; }
        public int ProgramaId { get; set; }
        public string ProgramaNombre { get; set; }
        public int MunicipioId { get; set; }
        public string MunicipioNombre { get; set; }
        public int DepartamentoId { get; set; }
        public string DepartamentoNombre { get; set; }
        public int DirectorId { get; set; }
        public string DirectorName { get; set;}
        public string Alias { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
    }
}
