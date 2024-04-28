using SQLite;
using MaxLenghtAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace TripExpenseManager.Models
{
    public class ExpenseCategory
    {
        //public int Id { get; set; }
        [PrimaryKey, MaxLenght(100)]
        public string Name { get; set; }
        public ExpenseCategory()
        {

        }
        public ExpenseCategory(string name)
        {
            Name = name;
        }
    }
}
