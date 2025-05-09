using System.Text.Json;
using System.Xml.Linq;
using Target.Dto;
using Target.Models;

namespace Target.Services.ExerciciosApi.Services
{
    public class ExercicioService
    {
        public int CalcularSoma()
        {
            int indice = 13;
            int soma = 0;
            int K = 0;

            while (K < indice)
            {
                K = K + 1;
                soma = soma + K;
            }

            return soma;
        }

        public FibonacciDto GerarFibonacci(int numero)
        {
            var sequencia = new List<int>();
            int a = 0, b = 1;

            sequencia.Add(a);

            if (numero == 0)
            {
                return new FibonacciDto
                {
                    Numero = numero,
                    SequenciaFibonacci = sequencia,
                    Pertence = true
                };
            }

            while (b <= numero)
            {
                sequencia.Add(b);
                int temp = a;
                a = b;
                b = temp + b;
            }

            return new FibonacciDto
            {
                Numero = numero,
                SequenciaFibonacci = sequencia,
                Pertence = sequencia.Contains(numero)
            };
        }

        public FaturamentoDto CalcularFaturamento(string fonte)
        {
            List<DiaValor> dados;

            string basePath = Path.Combine(Directory.GetCurrentDirectory(), "Dados");
            string jsonPath = Path.Combine(basePath, "dadosJson.json");
            string xmlPath = Path.Combine(basePath, "dadosXml.xml");

            if (fonte.ToLower() == "json")
            {
                var json = File.ReadAllText(jsonPath);
                dados = JsonSerializer.Deserialize<List<DiaValor>>(json);
            }
            else if (fonte.ToLower() == "xml")
            {
                var xml = XDocument.Load(xmlPath);
                dados = xml.Descendants("row")
                           .Select(x => new DiaValor
                           {
                               Dia = int.Parse(x.Element("dia").Value),
                               Valor = double.Parse(x.Element("valor").Value.Replace(".", ","))
                           }).ToList();
            }
            else
            {
                throw new ArgumentException("Erro. Use 'json' ou 'xml'.");
            }

            var diasComFaturamento = dados.Where(d => d.Valor > 0).ToList();
            var diasIgnorados = dados.Where(d => d.Valor == 0).Select(d => d.Dia).ToList();

            // ✅ Proteção contra lista vazia
            if (!diasComFaturamento.Any())
            {
                return new FaturamentoDto
                {
                    MenorFaturamento = 0,
                    MaiorFaturamento = 0,
                    DiasAcimaDaMedia = 0,
                    DiasIgnorados = diasIgnorados
                };
            }

            double menor = diasComFaturamento.Min(x => x.Valor);
            double maior = diasComFaturamento.Max(x => x.Valor);
            double media = diasComFaturamento.Average(x => x.Valor);
            int diasAcima = diasComFaturamento.Count(x => x.Valor > media);

            return new FaturamentoDto
            {
                MenorFaturamento = Math.Round(menor, 2),
                MaiorFaturamento = Math.Round(maior, 2),
                DiasAcimaDaMedia = diasAcima,
                DiasIgnorados = diasIgnorados
            };
        }

        public List<FaturamentoEstadoDto> CalcularFaturamentoPorEstado()
        {
            var estados = new Dictionary<string, double>
            {
                { "SP", 67836.43 },
                { "RJ", 36678.66 },
                { "MG", 29229.88 },
                { "ES", 27165.48 },
                { "Outros", 19849.53 }
            };

            double total = estados.Values.Sum();

            var resultado = estados.Select(e => new FaturamentoEstadoDto
            {
                Estado = e.Key,
                Valor = e.Value,
                Percentual = Math.Round((e.Value / total) * 100, 2)
            }).ToList();

            return resultado;
        }

        public InverterDto InverterString(string texto)
        {
            var caracteres = texto.ToCharArray();
            char[] invertido = new char[caracteres.Length];

            for (int i = 0; i < caracteres.Length; i++)
            {
                invertido[i] = caracteres[caracteres.Length - 1 - i];
            }

            return new InverterDto
            {
                TextoOriginal = texto,
                TextoInvertido = new string(invertido)
            };
        }
    }
}
