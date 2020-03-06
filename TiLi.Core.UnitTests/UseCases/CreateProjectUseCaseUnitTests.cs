using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.GatewayResponses.Repositories;
using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Core.UseCases;
using Xunit;

namespace TiLi.Core.UnitTests.UseCases
{
    public class CreateProjectUseCaseUnitTests
    {
        [Fact]
        public async void Can_Add_Project()
        {
            // arrange

            // 1. We need to store the user data somehow
            var mockProjectRepository = new Mock<IProjectRepository>();
            mockProjectRepository
              .Setup(repo => repo.Create(It.IsAny<Project>()))
              .Returns(Task.FromResult(new Dto.GatewayResponses.CreateBaseResponseDTO("", true)));
            // 2. The use case and star of this test
            var useCase = new CreateProjectUseCase(mockProjectRepository.Object);

            // 3. The output port is the mechanism to pass response data from the use case to a Presenter 
            // for final preparation to deliver back to the UI/web page/api response etc.
            var mockOutputPort = new Mock<IOutputPort<CreateProjectResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CreateProjectResponse>()));

            // act

            // 4. We need a request model to carry data into the use case from the upper layer (UI, Controller etc.)
            var response = await useCase.Handle(new CreateProjectRequest("firstName", "lastName"), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }
    }
}
