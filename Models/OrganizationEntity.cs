using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Models
{
    public class OrganizationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<VolunteerEntity> Volunteers { get; set; } = [];
        public List<RequestEntity> Requests { get; set; } = [];
    }
}
