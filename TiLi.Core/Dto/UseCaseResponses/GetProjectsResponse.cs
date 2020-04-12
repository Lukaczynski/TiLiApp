using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Interfaces;

namespace TiLi.Core.Dto.UseCaseResponses
{
    public class GetProjectsResponse : UseCaseResponseMessage
    {
        public IEnumerable<Project> Projects { get; }
        public IEnumerable<Error> Errors { get; }

        public GetProjectsResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetProjectsResponse(IEnumerable<Project> projects, bool success = false, string message = null) : base(success, message)
        {
            this.Projects = projects;
        }
    }
}
