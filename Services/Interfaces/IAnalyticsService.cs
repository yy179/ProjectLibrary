using ProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Services.Interfaces
{
    public interface IAnalyticsService
    {
        Task<int> GetProcessedRequestsCount(TimeSpan period);
        Task<TimeSpan> GetAverageRequestCompletionTime(TimeSpan period);
        Task<List<VolunteerEntity>> GetTopVolunteers(int topCount);
        Task<int> GetVolunteerCount();
        Task<int> GetOrganizationCount();
    }
}
