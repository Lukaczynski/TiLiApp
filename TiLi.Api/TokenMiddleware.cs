using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiLi.Api
{
    public class TokenMiddleware : IMiddleware
    {
        private readonly ICheckTokenUseCase _tokenManager;
        private readonly TokenPresenter _tokenPresenter;
        public TokenManagerMiddleware(ICheckTokenUseCase tokenManager, TokenPresenter tokenPresenter)
        {
            _tokenManager = tokenManager;
            _tokenPresenter = tokenPresenter;
        }
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            if (await _tokenManager.IsCurrentActiveToken())
            {
                await next(context);

                return;
            }
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
