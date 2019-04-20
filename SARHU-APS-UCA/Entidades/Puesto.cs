using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Puesto
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Required]
        public string Nombre { get; set; }

        [StringLength(150, MinimumLength = 5)]
        public string Descripcion { get; set; }

        [Required]
        public int CuentaId { get; set; }

        [Required]
        public int AreaId { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal SalarioBase { get; set; }
        public bool Estado { get; set; }

    }
}
