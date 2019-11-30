using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Model
{
    [Table("auth", Schema = "public")]
    public class AuthM
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("auth_id")]
        public int AuthId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }
}
