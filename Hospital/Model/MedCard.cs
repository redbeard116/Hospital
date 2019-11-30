using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Model
{
    [Table("card_id", Schema = "public")]
    public class MedCard
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("card_id")]
        public int CardId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("card_number")]
        public string CardNumber { get; set; }
    }
}
