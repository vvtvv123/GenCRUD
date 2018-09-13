using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace {{ project }}.{{ model }}s
{
    public interface I{{ model }}Manager
    {
        Task<long> Create({{ model }} instance);
        Task<{{ model }}> Update({{ model }} instance);
        Task Delete(long id);
        Task<{{ model }}> GetById(long id);
        Task<List<{{ model }}>> GetAll();
    }
}
