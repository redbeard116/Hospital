using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Model
{
    [Table("position", Schema = "public")]
    public class Position
    {
        [Column("position_id")]
        public int PositionId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
