using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiLi.Api.Models.Request;

namespace TiLi.Api.Models.Validation
{
    public class AddRoleToUserRequestValidation : AbstractValidator<AddRoleToUserRequest>
    {
        public AddRoleToUserRequestValidation()
        {
            RuleFor(x => x.IdRole).Length(2, 30);
         
        }
    
    }
}
