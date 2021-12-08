namespace ProAgil.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; }//o '?' após o tipo informa que o atributo pode ser nulo 
        public Evento Evento { get; }
        public int? PalestranteId { get; set; }
        public Palestrante Palestrante { get; }
    }


}