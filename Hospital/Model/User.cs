using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Model
{
    [Table("users", Schema = "public")]
    public class User
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("second_name")]
        public string SecondName { get; set; }

        [Column("birth_date")]
        public string BirthDate { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}
