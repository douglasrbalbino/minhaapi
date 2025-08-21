using System.ComponentModel.DataAnnotations;

namespace MinhaAPI.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o título do livro.")]
        [StringLength(100, ErrorMessage = "O título do livro deve ter no máximo 100 caracteres.")]
        [Display(Name = "Título do Livro")] // Exibe o nome do campo como "Título do Livro" na interface do usuário
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o autor do livro.")]
        [StringLength(50, ErrorMessage = "O nome do autor deve ter no máximo 100 caracteres.")]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o preço do livro.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço do livro deve ser maior que zero.")]

        public double Preco { get; set; }

    }
}
