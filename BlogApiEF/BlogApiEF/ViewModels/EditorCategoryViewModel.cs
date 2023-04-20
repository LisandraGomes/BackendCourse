using System.ComponentModel.DataAnnotations;

namespace BlogApiEF.ViewModels
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage = "O Nome é Obrigatório!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Este campo deve ter tamanho minimo de 3 e máximo de 40 caracteres!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O Slug é Obrigatório!")]
        public string Slug { get; set; }
    }
}
