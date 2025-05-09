# 💻 Target - Teste Técnico

Este projeto foi desenvolvido como solução para o teste técnico proposto pela Target Sistemas, contendo 5 desafios de lógica e manipulação de dados, implementados em ASP.NET Core Web API (C#).

---

## 🚀 Como rodar o projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/esthersiqueira/TargetExercicios.git

2. Abra o projeto no Visual Studio.

3. Certifique-se de que os arquivos dadosJson.json e dadosXml.xml estão na pasta Dados/ e com as seguintes propriedades:
   Ação de compilação: Conteúdo
   Copiar para o diretório de saída: Copiar se for mais novo

4. Rode o projeto (F5 ou botão ▶️) e acesse no navegador:

🧠 Desafios resolvidos
✅ 1. Soma com While
Soma os números de 1 a 13 usando estrutura de repetição.
  - Endpoint: GET /api/exercicios/calcularSoma

✅ 2. Fibonacci
Gera a sequência de Fibonacci até o número informado e indica se ele pertence ou não à sequência.
  - Endpoint: GET /api/exercicios/fibonacci/{numero}

✅ 3. Faturamento Diário
Lê dados de faturamento por dia (JSON ou XML) e retorna:
  - Menor valor
  - Maior valor
  - Número de dias com valor acima da média
  - Dias ignorados (valor 0)
  - Endpoint: GET /api/exercicios/faturamento?fonte=json ou fonte=xml

✅ 4. Percentual por Estado
Calcula o percentual de participação de cada estado no faturamento total mensal.
  - Endpoint: GET /api/exercicios/faturamento-estados

✅ 5. Inversão de String
Inverte os caracteres de uma string informada, sem usar métodos prontos como .Reverse().
  - Endpoint: GET /api/exercicios/inverter-string?texto=exemplo

📂 Organização do projeto
  - Controllers/ → Endpoints da API
  - Services/ → Lógica dos exercícios
  - Dto/ → Objetos de entrada/saída
  - Models/ → Modelos para leitura dos arquivos JSON/XML

✨ Observações
  - Toda a lógica foi feita sem bibliotecas externas, focando na clareza e resolução direta dos problemas propostos.
  - A API conta com documentação Swagger e comentários XML ativados.

Feito com dedicação por @esthersiqueira 🚗💻
