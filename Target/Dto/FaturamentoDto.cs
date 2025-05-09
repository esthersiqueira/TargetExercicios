namespace Target.Dto
{
    public class FaturamentoDto
    {
        public double MenorFaturamento { get; set; }
        public double MaiorFaturamento { get; set; }
        public int DiasAcimaDaMedia { get; set; }
        public List<int> DiasIgnorados { get; set; }
    }
}
