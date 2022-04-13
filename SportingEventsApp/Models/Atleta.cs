using System.ComponentModel.DataAnnotations;

namespace SportingEventsApp.Models
{
    public class Atleta
    {
        [Display(Name = "ID:")]
        public int Id { get; set; }
        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "É obrigatório informar o nome!")]
        public string Nome { get; set; }
        [Display(Name = "Modalidade:")]
        [Required(ErrorMessage = "É obrigatório informar a modalidade!")]
        public string Modalidade { get; set; }
        [Display(Name = "Nível de Experiência:")]
        [Required(ErrorMessage = "É obrigatório informar o nível de experiência!")]
        public string NivelExperiencia { get; set; }
        [Display(Name = "Confirmação no Evento:")]
        public DateTime DataConfirmacao { get; private set; } = DateTime.Now;
        [Display(Name = "Evento ID:")]
        [Required(ErrorMessage = "É obrigatório informar o evento!")]
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
