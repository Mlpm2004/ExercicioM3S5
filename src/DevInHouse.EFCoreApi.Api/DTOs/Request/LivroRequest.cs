using System.ComponentModel.DataAnnotations;

namespace DevInHouse.EFCoreApi.Api.DTOs.Request
{
    public class LivroRequest
    {
        [Required(ErrorMessage = "Titulo � requerido")]
        [StringLength(255, ErrorMessage = "Titulo n�o pode exceder de 255 carateres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Categoria � requerido")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Autor � requerido")]
        public int AutorId { get; set; }

        public DateTime DataPublicacao { get; set; }
        public decimal Preco { get; set; }
    }
}