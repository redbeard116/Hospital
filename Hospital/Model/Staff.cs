using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Model
{
    [Table("staff", Schema = "public")]
    public class Staff
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("staff_id")]
        public int StaffId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("position_id")]
        public int PositionId { get; set; }
    }
}
