﻿using Abp.Application.Services.Dto;
using System;

namespace {{ project }}.{{ model }}s.Dtos
{
    public class Update{{ model }}Input : EntityDto<long>
    {
        {% for k,v in vars.items() %}
        public {{ v }} {{ k }} { get; set;}
        {% endfor %}
    }
}
