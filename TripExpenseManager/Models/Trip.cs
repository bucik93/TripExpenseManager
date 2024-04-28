using SQLite;
using System.ComponentModel.DataAnnotations;
using MaxLenghtAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace TripExpenseManager.Models
{
    public class Trip
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required, MaxLenght(30)]
        public string Title { get; set; }
        [Required, MaxLenght(50)]
        public string Location { get; set; }
        [Required, MaxLenght(30)]
        public string CategoryImage { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public TripStatus Status { get; set; } = TripStatus.Palnned;


    }
}
