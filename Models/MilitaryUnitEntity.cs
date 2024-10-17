using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Models
{
    public class MilitaryUnitEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid? ContactPersonId { get; set; }
        public ContactPersonEntity? ContactPerson { get; set; }
        public List<RequestEntity> Requests { get; set; } = [];
    }
}
