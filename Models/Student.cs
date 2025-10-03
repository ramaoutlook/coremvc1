using System.ComponentModel;

namespace coremvc.Models
{
    public class Student
    {
        [DisplayName("Roll Number")]
        public int roll { get; set; }
        [DisplayName("Enter Your Name")]
        public string name { get; set; }
        [DisplayName("Enter Gender")]
        public string gender { get; set; }
        [DisplayName("Enter Course")]
        public string course { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime dob { get; set; }
        [DisplayName("Your Age")]
        public int age { get; set; }
        [DisplayName("Fee")]
        public float fee { get; set; }
    }

    public class Product
    {
        public int prodId { get; set; }
        public string? prodName { get; set; }
        public float prodPrice { get; set; }
        public int prodQty { get; set; }
    }
}
