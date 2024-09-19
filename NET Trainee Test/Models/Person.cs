using System.ComponentModel.DataAnnotations;


namespace NET_Trainee_Test.Models
{ 
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public bool Married { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Range(0, 1000000)]
        public decimal Salary { get; set; }
    }

}