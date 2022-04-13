using System.ComponentModel.DataAnnotations;

namespace SportingEventsApp.Models
{
    public class Evento
    {
        [Display(Name = "ID:")]
        public int Id { get; set; }
        [Display(Name = "Título:")]
        public string Titulo { get; set; }
        [Display(Name = "Modalidade:")]
        public string Modalidade { get; set; }
        [Display(Name = "Limite de Participantes:")]
        public int TotalParticipantes { get; set; }
        [Display(Name = "Local:")]
        public string Local { get; set; }
        [Display(Name = "Data do Evento:")]
        public DateTime Data { get; set; }

        public IList<Atleta> Atletas { get; set; }

    }
}
