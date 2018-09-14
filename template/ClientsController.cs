using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using {{ project }}.{{ model }}s;
using {{ project }}.{{ model }}s.Dtos;
using {{ project }}.Web.Models.{{ model }}s;
using Microsoft.AspNetCore.Mvc;

namespace {{ project }}.Web.Mvc.Controllers
{
    public class {{ model }}sController : AbpController
    {
        private readonly I{{ model }}AppService _{{ model_lower }}AppService;

        public {{ model }}sController(I{{ model }}AppService {{ model_lower }}AppService)
        {
            _{{ model_lower }}AppService = {{ model_lower }}AppService;
        }

        public async Task<IActionResult> Index()
        {
            var {{ model_lower }}s = await _{{ model_lower }}AppService.GetAll{{ model }}s();
            var model = new {{ model }}ListViewModel
            {
                {{ model }}s = {{ model_lower }}s.{{ model }}s
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create({{ model }}ViewModel {{ model }})
        {
            var {{ model_lower }}Input = ObjectMapper.Map<Create{{ model }}Input>({{ model }});
            var result = await _{{ model_lower }}AppService.Create{{ model }}({{ model_lower }}Input);
            return Redirect(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var {{ model }} = await _{{ model_lower }}AppService.GetById(id);
            var {{ model_lower }}ToEdit = ObjectMapper.Map<{{ model }}ViewModel>({{ model }});
            return View({{ model_lower }}ToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit({{ model }}ViewModel {{ model }})
        {
            var {{ model_lower }}ToUpdate = ObjectMapper.Map<Update{{ model }}Input>({{ model }});
            var result = await _{{ model_lower }}AppService.Update{{ model }}({{ model_lower }}ToUpdate);
            var {{ model_lower }}Updated = ObjectMapper.Map<{{ model }}ViewModel>(result);
            return View({{ model_lower }}Updated);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var {{ model }} = await _{{ model_lower }}AppService.GetById(id);
            if ({{ model }} == null)
            {
                return NotFound();
            }
            var {{ model_lower }}ViewModel = ObjectMapper.Map<{{ model }}ViewModel>({{ model }});
            return View({{ model_lower }}ViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _{{ model_lower }}AppService.Delete{{ model }}(id);
            return RedirectToAction("Index");
        }
    }
}