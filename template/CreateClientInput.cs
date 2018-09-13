using System;

namespace  {{ project }}.{{ model }}s.Dtos
{
    public class Create{{ model }}Input
    {
        {% for k,v in vars.items() %}
        public {{ v }} {{ k }} { get; set;}
        {% endfor %}
    }
}
