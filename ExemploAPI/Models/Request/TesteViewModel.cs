using ExemploAPI.Models.Validations;

namespace ExemploAPI.Models.Request
{
	public class TesteViewModel
	{
		public string Nome { get; set; }
		public int Idade { get; set; }

		[CpfValidation(ErrorMessage = "CPF inválido.")]
		public string Cpf { get; set; }
	}

}
