namespace StudentManagementSystemProject.Models
{
    // Student model representing Students table
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // Optional: Phone number
        public string Phone { get; set; }
        // Gender: Male/Female/Other
        public string Gender { get; set; }
        // Date of birth
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
