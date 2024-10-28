// Teacher.cs
namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Teacher(string name)
        {
            Name = name;
        }
    }
}