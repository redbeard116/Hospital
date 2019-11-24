using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Model
{
    [Table("appointment", Schema = "public")]
    public class Appointment
    {
        [Column("appoint_id")]
        public int AppointmentId { get; set; }

        [Column("medcard_id")]
        public int MedCardId { get; set; }

        [Column("doctor")]
        public int DoctorId { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
