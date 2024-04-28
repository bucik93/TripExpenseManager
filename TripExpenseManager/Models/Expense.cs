using SQLite;
using System.ComponentModel.DataAnnotations;
using MaxLenghtAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace TripExpenseManager.Models
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public int TripId { get; set; }
        [Required, MaxLenght(100)]
        public string For { get; set; }
        [Range(0.1, double.MaxValue)]
        public double Amount { get; set; }
        [Required]
        public string Category { get; set; }
        public DateTime? SpentOn { get; set; }


    }
}
