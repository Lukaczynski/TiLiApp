using System;
using System.Collections.Generic;
using System.Text;

namespace TiLi.Core.Domain.Entities
{
    public class UserProject
    {
        public int? Id { get; }
        public string UserId { get; set; }
        public int ProjectId { get; set; }
        public int AccesLevel { get; set; }

        public UserProject(string userId, int projectId, int accesLevel=0, int? id = null)
        {
            Id = id;
            UserId = userId;
            ProjectId = projectId;
            AccesLevel = accesLevel;
        }
    }
}
