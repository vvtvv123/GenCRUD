using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System;

namespace {{ project }}.Web.Models.{{ model }}s
{
    public class {{ model }}ViewModel : EntityDto<long>
    {
        {% for k, v in maxlen.items() %}
        public const int Max{{ k }}Length = {{ v }};
        {% endfor %}

        {% for k,v in vars.items() %}
        {% if k in required %}[Required]
        {% endif %}
        {% if k in maxlen %}[StringLength(Max{{ k }}Length)]
        {% endif %}
        public {{ v }} {{ k }} { get; set;}

        {% endfor %}
    }
}
