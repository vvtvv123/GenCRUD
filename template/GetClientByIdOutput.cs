using Abp.Application.Services.Dto;
using System;

namespace {{ project }}.{{ model }}s.Dtos
{
    public class Get{{ model }}ByIdOutput : EntityDto<long>
    {
        {% for k,v in vars.items() %}
        public {{ v }} {{ k }} { get; set;}
        {% endfor %}
    }
}
