using Cooperchip.ADONet.WebAPI.Infra.Repository;
using Cooperchip.ADONet.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Cooperchip.ADONet.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IGenericRepository<Fornecedor> _repository;
        private readonly ILogger _logger;

        public FornecedorController(IGenericRepository<Fornecedor> repository,
                                      ILogger<FornecedorController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fornecedores = await _repository.GetAllAsync();
            foreach(var item in fornecedores)
            {
                _logger.LogInformation($"Id retornado: {item.Id}");
                _logger.LogInformation($"Nome retornado: {item.Nome}");
                _logger.LogInformation($"Cnpj retornado: {item.Cnpj}");
            }
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fornecedor = await _repository.GetByIdAsync(id);
            if (fornecedor == null) return NotFound();

            _logger.LogInformation($"Nome do Fornecedor: {fornecedor.Nome}");
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Fornecedor fornecedor)
        {
            await _repository.AddAsync(fornecedor);
            return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id) return BadRequest();
            await _repository.UpdateAsync(fornecedor);
            _logger.LogInformation($"Nome do Fornecedor alterado: {fornecedor.Nome}");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }

    }
}