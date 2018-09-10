using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using AbpSimpleCRUD.Clients;
using AbpSimpleCRUD.Clients.Dtos;
using AbpSimpleCRUD.Web.Models.Clients;
using Microsoft.AspNetCore.Mvc;

namespace AbpSimpleCRUD.Web.Mvc.Controllers
{
    public class ClientsController : AbpController
    {
        private readonly IClientAppService _clientAppService;

        public ClientsController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _clientAppService.GetAllClients();
            var model = new ClientListViewModel
            {
                Clients = clients.Clients
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientViewModel client)
        {
            var clientInput = ObjectMapper.Map<CreateClientInput>(client);
            var result = await _clientAppService.CreateClient(clientInput);
            return Redirect(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var client = await _clientAppService.GetById(id);
            var clientToEdit = ObjectMapper.Map<ClientViewModel>(client);
            return View(clientToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientViewModel client)
        {
            var clientToUpdate = ObjectMapper.Map<UpdateClientInput>(client);
            var result = await _clientAppService.UpdateClient(clientToUpdate);
            var clientUpdated = ObjectMapper.Map<ClientViewModel>(result);
            return View(clientUpdated);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var client = await _clientAppService.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            var clientViewModel = ObjectMapper.Map<ClientViewModel>(client);
            return View(clientViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _clientAppService.DeleteClient(id);
            return RedirectToAction("Index");
        }
    }
}