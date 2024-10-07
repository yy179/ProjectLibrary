using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Models
{

    public class RequestEntity
    {
        public Guid Id { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public DateTime SubmissionDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsActive { get; set; }
        public Guid MilitaryUnitId { get; set; }
        public MilitaryUnitEntity MilitaryUnit { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public Guid? OrganizationId { get; set; }
        public OrganizationEntity Organization { get; set; }
        public Guid? VolunteerId { get; set; }
        public VolunteerEntity Volunteer { get; set; }

    }
}
