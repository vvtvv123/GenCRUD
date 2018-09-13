using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace {{ project }}.{{ model }}s
{
    public class {{ model }}Manager : IDomainService, I{{ model }}Manager
    {
        private IRepository<{{ model }}, long> _{{ model }}Repository;

        public {{ model }}Manager(IRepository<{{ model }}, long> {{ model }}Repository)
        {
            _{{ model }}Repository = {{ model }}Repository;
        }

        public async Task<long> Create({{ model }} instance)
        {
            return await _{{ model }}Repository.InsertAndGetIdAsync(instance);
        }

        public async Task<{{ model }}> Update({{ model }} instance)
        {
            return await _{{ model }}Repository.UpdateAsync(instance);
        }

        public async Task Delete(long id)
        {
            await _{{ model }}Repository.DeleteAsync(id);
        }

        public async Task<{{ model }}> GetById(long id)
        {
            return await _{{ model }}Repository.GetAsync(id);
        }

        public async Task<List<{{ model }}>> GetAll()
        {
            return await _{{ model }}Repository.GetAllListAsync();
        }
    }
}
