﻿using System.Collections.Generic;

namespace TiLi.Core.Dto.GatewayResponses
{
  public abstract class BaseGatewayResponseDTO
  {
    public bool Success { get; }
    public IEnumerable<Error> Errors { get; }

    protected BaseGatewayResponseDTO(bool success=false, IEnumerable<Error> errors=null)
    {
      Success = success;
      Errors = errors;
    }
  }
}

