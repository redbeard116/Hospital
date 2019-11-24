using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Model
{
    [Table("outpatient_card", Schema = "public")]
    public class OutpatentCard
    {
        [Column("card_id")]
        public int CardId { get; set; }

        [Column("med_card_id")]
        public int MedCardId { get; set; }

        [Column("diagnoz")]
        public string Diagnoz { get; set; }
    }
}
