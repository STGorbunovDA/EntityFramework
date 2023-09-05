using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Entities
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }


        //[ForeignKey(nameof(Department))]
        public int CurrentDepartmentId { get; set; }
        public Department Department { get; set;} // навигационное свойство

        //public int AdressId { get; set; }
        public Adress Adress { get; set; }

        public ICollection<Hobby> Hobbies { get; set; }
    }
}
