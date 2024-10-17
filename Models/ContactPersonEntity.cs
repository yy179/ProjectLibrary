using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Models
{
    public class ContactPersonEntity
    {
        public Guid Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Guid? MilitaryUnitId { get; set; }
        public MilitaryUnitEntity? MilitaryUnit { get; set; }
    }
}
