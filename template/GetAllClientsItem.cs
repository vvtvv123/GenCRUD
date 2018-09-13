using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace {{ project }}.{{ model }}s.Dtos
{
    public class GetAll{{ model }}sItem : EntityDto<long>
    {
        {% for k,v in vars.items() %}
        public {{ v }} {{ k }} { get; set;}
        {% endfor %}
    }
}
