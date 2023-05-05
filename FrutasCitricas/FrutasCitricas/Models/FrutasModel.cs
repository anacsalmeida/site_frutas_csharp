using System.ComponentModel.DataAnnotations;

namespace FrutasCitricas.Models
{
    public class FrutasModel
    {
        [Key]
        public int Id { get; set; }
        public string IdUrl { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

    }
}
