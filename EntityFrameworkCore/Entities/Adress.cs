using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Entities
{
    class Adress
    {
        public int Id { get; set; }
        public string Street { get; set; }

        //[Key]
        //[ForeignKey(nameof(Person))]
        public int? PersonId { get; set; }
        public Person Person { get; set; }
    }
}
