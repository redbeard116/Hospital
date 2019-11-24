using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Model
{
    [Table("card_id", Schema = "public")]
    public class MedCard
    {
        [Column("card_id")]
        public int CardId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("card_number")]
        public int CardNumber { get; set; }
    }
}
