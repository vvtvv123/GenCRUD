using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.AutoMapper;
using {{ project }}.{{ model }}s.Dtos;
using {{ project }}.Domain.{{ model }}s;

namespace {{ project }}.{{ model }}s
{
    public class {{ model }}AppService : I{{ model }}AppService
    {
        private I{{ model }}Manager _{{ model }}Manager;

        public {{ model }}AppService(I{{ model }}Manager {{ model }}Manager)
        {
            _{{ model }}Manager = {{ model }}Manager;
        }

        //[HttpPost]
        public async Task<Create{{ model }}Output> Create{{ model }}(Create{{ model }}Input input)
        {
            var {{ model }} = input.MapTo<{{ model }}>();
            var created{{ model }}Id = await _{{ model }}Manager.Create({{ model }});
            return new Create{{ model }}Output { Id = created{{ model }}Id };
        }

        public async Task Delete{{ model }}(long id)
        {
            await _{{ model }}Manager.Delete(id);
        }

        public async Task<GetAll{{ model }}sOutput> GetAll{{ model }}s()
        {
            var {{ model }}s = await _{{ model }}Manager.GetAll();
            return new GetAll{{ model }}sOutput
            {
                {{ model }}s = {{ model }}s.MapTo<List<GetAll{{ model }}sItem>>()
            };
        }

        public async Task<Get{{ model }}ByIdOutput> GetById(long id)
        {
            var {{ model }} = await _{{ model }}Manager.GetById(id);
            return {{ model }}.MapTo<Get{{ model }}ByIdOutput>();
        }

        public async Task<Update{{ model }}Output> Update{{ model }}(Update{{ model }}Input input)
        {
            var {{ model }} = input.MapTo<{{ model }}>();
            var {{ model }}Updated = await _{{ model }}Manager.Update({{ model }});
            return {{ model }}Updated.MapTo<Update{{ model }}Output>();
        }
    }
}
