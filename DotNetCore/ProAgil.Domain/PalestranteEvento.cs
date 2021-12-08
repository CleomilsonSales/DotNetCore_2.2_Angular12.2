namespace ProAgil.Domain
{
    //Essa entidade foi criada porque a relação de Palestrante e Evento é de n para n
    public class PalestranteEvento
    {
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }

}