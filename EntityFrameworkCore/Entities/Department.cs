using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Entities
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[ForeignKey("CurrentDepartmentId")]
        public ICollection<Person> Persons { get; set; }
    }
}
