using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace {{ project }}.Domain.{{ model }}s
{
    [Table("{{ model }}s")]
    public class {{ model }} : FullAuditedEntity<long>
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