﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TiLi.Api.Presenters;
using TiLi.Core.Dto.UseCaseResponses;
using Xunit;

namespace TiLi.Api.UnitTests.Presenters
{
    public class RegisterUserPresenterUnitTests
    {
        [Fact]
        public void Contains_Ok_Status_Code_When_Use_Case_Succeeds()
        {
            // arrange
            var presenter = new RegisterUserPresenter();

            // act
            presenter.Handle(new RegisterUserResponse("", true));

            // assert
            Assert.Equal((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
        }

        [Fact]
        public void Contains_Id_When_Use_Case_Succeeds()
        {
            // arrange
            var presenter = new RegisterUserPresenter();

            // act
            presenter.Handle(new RegisterUserResponse("1234", true));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.True(data.success.Value);
            Assert.Equal("1234", data.id.Value);
        }

        [Fact]
        public void Contains_Errors_When_Use_Case_Fails()
        {
            // arrange
            var presenter = new RegisterUserPresenter();

            // act
            presenter.Handle(new RegisterUserResponse(new[] { "missing first name" }));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.False(data.success.Value);
            Assert.Equal("missing first name", data.errors.First.Value);
        }
    }
}