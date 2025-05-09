using Microsoft.AspNetCore.Mvc;
using Target.Services.ExerciciosApi.Services;

namespace ExerciciosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciciosController : ControllerBase
    {
        private readonly ExercicioService _service;

        public ExerciciosController(ExercicioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Exercício 1 – Soma os números de 1 até 13 usando estrutura de repetição (while).
        /// Não recebe parâmetros. Basta clicar em "Try it out" e depois em "Execute" para ver o resultado.
        /// </summary>
        [HttpGet("calcularSoma")]
        public IActionResult CalcularSoma()
        {
            var resultado = _service.CalcularSoma();
            return Ok(new { resultado });
        }

        /// <summary>
        /// Exercício 2 – Gera a sequência de Fibonacci até o número informado
        /// e retorna se ele pertence ou não à sequência.
        /// </summary>
        /// <param name="numero">Número a ser verificado se pertence à sequência de Fibonacci.</param>
        [HttpGet("fibonacci/{numero}")]
        public IActionResult Fibonacci(int numero)
        {
            var resultado = _service.GerarFibonacci(numero);
            return Ok(resultado);
        }

        /// <summary>
        /// Exercício 3 – Lê os dados de faturamento diário (JSON ou XML)
        /// e retorna o menor valor, maior valor, dias acima da média e os dias ignorados (valor 0).
        /// </summary>
        /// <param name="fonte">Informe 'json' ou 'xml' para escolher o formato dos dados.</param>
        [HttpGet("faturamento")]
        public IActionResult Faturamento([FromQuery] string fonte)
        {
            try
            {
                var resultado = _service.CalcularFaturamento(fonte);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        /// <summary>
        /// Exercício 4 – Calcula o percentual que cada estado representa no total de faturamento mensal.
        /// Os valores são fixos conforme fornecido no exercício.
        /// </summary>
        [HttpGet("faturamento-estados")]
        public IActionResult FaturamentoPorEstado()
        {
            var resultado = _service.CalcularFaturamentoPorEstado();
            return Ok(resultado);
        }

        /// <summary>
        /// Exercício 5 – Inverte os caracteres da string informada sem utilizar métodos prontos como Reverse().
        /// </summary>
        /// <param name="texto">Texto a ser invertido. Informe na query string.</param>
        [HttpGet("inverter-string")]
        public IActionResult InverterString([FromQuery] string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return BadRequest(new { erro = "Você precisa informar uma string para inverter." });

            var resultado = _service.InverterString(texto);
            return Ok(resultado);
        }
    }
}
