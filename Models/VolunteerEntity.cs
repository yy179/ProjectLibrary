using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Models
{
    public class VolunteerEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public List<OrganizationEntity> Organizations { get; set; } = [];
        public List<RequestEntity> Requests { get; set; } = [];
        public bool IsAdmin { get; set; }
    }
}
