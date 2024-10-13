using ProjectLibrary.Models;
using ProjectLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IRequestService _requestService;
        private readonly IVolunteerService _volunteerService;
        private readonly IOrganizationService _organizationService;

        public AnalyticsService(IRequestService requestService, IVolunteerService volunteerService, IOrganizationService organizationService)
        {
            _requestService = requestService;
            _volunteerService = volunteerService;
            _organizationService = organizationService;
        }
        public async Task<int> GetProcessedRequestsCount(TimeSpan period)
        {
            var requests = await _requestService.Get();
            return requests.Count(r => r.IsActive == false && r.SubmissionDate >= DateTime.Now - period);
        }
        public async Task<TimeSpan> GetAverageRequestCompletionTime(TimeSpan period)
        {
            var requests = await _requestService.Get();
            var completedRequests = requests.Where(r => r.IsActive == false && r.SubmissionDate >= DateTime.Now - period).ToList();

            if (!completedRequests.Any()) return TimeSpan.Zero;

            var totalCompletionTime = completedRequests.Sum(r => (r.DueDate.Value - r.SubmissionDate).TotalSeconds);
            return TimeSpan.FromSeconds(totalCompletionTime / completedRequests.Count);
        }
        public async Task<List<VolunteerEntity>> GetTopVolunteers(int topCount)
        {
            var volunteers = await _volunteerService.Get();
            return volunteers.OrderByDescending(v => v.Requests.Count(r => r.IsActive == false))
                             .Take(topCount)
                             .ToList();
        }
        public async Task<int> GetVolunteerCount()
        {
            return (await _volunteerService.Get()).Count;
        }
        public async Task<int> GetOrganizationCount()
        {
            return (await _organizationService.Get()).Count;
        }
    }
}
