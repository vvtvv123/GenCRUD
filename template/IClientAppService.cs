using Abp.Application.Services;
using {{ project }}.{{ model }}s.Dtos;
using System.Threading.Tasks;

namespace {{ project }}.{{ model }}s
{
    public interface I{{ model }}AppService : IApplicationService
    {
        Task<Create{{ model }}Output> Create{{ model }}(Create{{ model }}Input input);
        Task<Update{{ model }}Output> Update{{ model }}(Update{{ model }}Input input);
        Task Delete{{ model }}(long id);
        Task<Get{{ model }}ByIdOutput> GetById(long id);
        Task<GetAll{{ model }}sOutput> GetAll{{ model }}s();
    }
}
