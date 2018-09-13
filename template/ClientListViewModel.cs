using {{ project }}.{{ model }}s.Dtos;
using System.Collections.Generic;


namespace {{ project }}.Web.Models.{{ model }}s
{
    public class {{ model }}ListViewModel
    {
        public IReadOnlyList<GetAll{{ model }}sItem> {{ model }}s { get; set; }
    }
}
