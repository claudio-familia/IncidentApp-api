using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Services.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IncidentApp.Tests
{
    public class IncidentService
    {
        private readonly Mock<IBaseService<Incident, IncidentDto>> incidentService;
        private object mockIncident;

        public IncidentService()
        {
            incidentService = new Mock<IBaseService<Incident, IncidentDto>>();
            mockIncident = new IncidentDto()
            {                
                DepartmentId = 1,
                AssignedUserId = 1,
                ReportedUserId = 1,
                PriorityId = 2,
                Description = "Mock Incident",
                Title = "New Mock Incident",
                IsIncidentClosed = false,
                ClosedDate = null,
                ClosedComment = null
            };
        }

        [Fact]
        public void CreateIncident()
        {
            incidentService.Setup(service => service.Add(It.IsAny<IncidentDto>()))
                        .Returns(mockIncident as Incident);

            IncidentDto entryData = mockIncident as IncidentDto;
            Incident response = incidentService.Object.Add(entryData);

            Assert.Equal(response.DepartmentId, entryData.DepartmentId);
            Assert.Equal(response.AssignedUserId, entryData.AssignedUserId);
            Assert.Equal(response.ReportedUserId, entryData.ReportedUserId);
            Assert.Equal(response.PriorityId, entryData.PriorityId);
            Assert.Equal(response.Description, entryData.Description);
            Assert.Equal(response.Title, entryData.Title);            
        }

        [Fact]
        public void CreateIncidentWithMissingData()
        {
            incidentService.Setup(service => service.Add(It.IsAny<IncidentDto>()))
                        .Returns(mockIncident as Incident);

            IncidentDto entryData = mockIncident as IncidentDto;
            Incident response = incidentService.Object.Add(entryData);

            Assert.Equal(response.DepartmentId, entryData.DepartmentId);
            Assert.Equal(response.AssignedUserId, entryData.AssignedUserId);
            Assert.Equal(response.ReportedUserId, entryData.ReportedUserId);
            Assert.Equal(response.PriorityId, entryData.PriorityId);
            Assert.Equal(response.Description, entryData.Description);
            Assert.Equal(response.Title, entryData.Title);
        }
    }
}
