using Microsoft.AspNetCore.Mvc;
using ExemploAPI.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ExemploAPI.Models.Request.ExemploAPI.Models.Request;

namespace ExemploAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NatalController : ControllerBase
    {
        private readonly string _jogoCaminhoArquivo;

        public NatalController()
        {
            _jogoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Natal.json");
        }
        #region Metodo Arquivos
        private List<CriancaViewModel> LerCriancaDoArquivo()
        {
            if (!System.IO.File.Exists(_jogoCaminhoArquivo))
            {
                return new List<CriancaViewModel>();
            }

            string json = System.IO.File.ReadAllText(_jogoCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<CriancaViewModel>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<CriancaViewModel> crianca = LerCriancaDoArquivo();
            if (crianca.Any())
            {
                return crianca.Max(p => p.Id) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverCriancaNoArquivo(List<CriancaViewModel> jogos)
        {
            string json = JsonConvert.SerializeObject(jogos);
            System.IO.File.WriteAllText(_jogoCaminhoArquivo, json);
        }

        #endregion


        [HttpGet]
        public IActionResult Get()
        {
            List<CriancaViewModel> jogos = LerCriancaDoArquivo();
            return Ok(jogos);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CriancaViewModel criaca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<CriancaViewModel> criancas = LerCriancaDoArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            CriancaViewModel novaCrianca = new CriancaViewModel()
            {
                Nome = criaca.Nome,
                Idade = criaca.Idade,
                Rua= criaca.Rua,
                Bairro= criaca.Bairro,
                NumeroCasa= criaca.NumeroCasa,
                Cidade= criaca.Cidade,
                Estado= criaca.Estado,
                Carta= criaca.Carta
                
            };

            criancas.Add(novaCrianca);
            EscreverCriancaNoArquivo(criancas);

            return Ok("Pedido para o papai noel Registrado com sucesso!");
        }
        
    }
}
