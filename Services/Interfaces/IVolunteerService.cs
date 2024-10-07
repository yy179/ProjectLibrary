﻿using ProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Services.Interfaces
{
    public interface IVolunteerService
    {
        Task<List<VolunteerEntity>> Get();
        Task<VolunteerEntity?> GetById(Guid id);
        Task Add(Guid id, string name, DateTime dateOfBirth, string city, string biography, List<OrganizationEntity> organizations, List<RequestEntity> requests);
        Task Update(Guid id, string name, DateTime dateOfBirth, string city, string biography, List<OrganizationEntity> organizations, List<RequestEntity> requests);
        Task Delete(Guid id);
    }
}
