using System.Threading.Tasks;
using TiLi.Core.Dto;

namespace TiLi.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id, string userName);
    }
}
