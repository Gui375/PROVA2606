namespace ExemploAPI.Models.Request
{
    //using ExemploAPI.Models.Validations;
    using global::ExemploAPI.Models.Validations;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    namespace ExemploAPI.Models.Request
    {
        public class CriancaViewModel
        {
            [JsonIgnore]
            public int Id { get; set; } 
            [Required(ErrorMessage = "Nome é obrigatorio")]
            [MinLength(3, ErrorMessage = "Nome deve ter no mínimo 3 caracteres.")]
            [MaxLength(255, ErrorMessage = "Nome deve ter no maximo 255 caracteres.")]
            public string Nome { get; set; }
            [Required]
            [Range(1, 15, ErrorMessage = "Idade invalida")]
            public int Idade { get; set; }
            [Required]
            public string Rua { get; set; }
            [Required]
            public string Bairro { get; set; }
            [Required]
            public int NumeroCasa { get; set; }
            [Required]
            public string Cidade { get; set; }
            [Required]
            public string Estado { get; set; }

            [Required(ErrorMessage ="Conteudo da Carta Obrigatorio !")]
            [MinLength(3, ErrorMessage = "Carta deve ter no mínimo 1 caracteres.")]
            [MaxLength(500, ErrorMessage = "Nome deve ter no maximo 500 caracteres.")]
            public string Carta{ get; set; }

        }
    }

}
