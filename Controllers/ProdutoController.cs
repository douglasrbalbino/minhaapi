using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;

namespace MinhaAPI.Controllers
{
    [Route("api/[controller]")] // Desta forma vira api/Produto - utiliza o nome usado antes de controller (ProdutoController)
    [ApiController] // Define a rota como Controller de API
    public class ProdutoController : ControllerBase
    {
         private readonly AppDbContext _contextDb;

        public ProdutoController(AppDbContext contextDb)
        {
            _contextDb = contextDb;
            // Construtor vazio, se necessário, pode ser usado para injeção de dependências
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            // Método para obter todos os produtos do banco de dados
            var produtos = await _contextDb.Produtos.ToListAsync();
            return Ok(produtos);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Produto produto) { 
        
            if(!ModelState.IsValid) { //ModelState.IsValid confere se as anotations na entidade "Produto" estão corretas
                return BadRequest(ModelState); // Retorna um erro 400 se o modelo não for válido
            }

            _contextDb.Produtos.Add(produto); // Adiciona o produto ao contexto do banco de dados
            await _contextDb.SaveChangesAsync(); // Salva as mudanças no banco de dados de forma assíncrona

            
            return Ok("Produto criado com sucesso");
            // return Create(produto); = alternativa para retornar o produto criado com o status 201 (Created)

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var produto = await _contextDb.Produtos.FindAsync(id); // Busca o produto pelo ID
            
            if(produto == null) {

                return NotFound($"Produto com ID {id} não encontrado."); // Retorna 404 se o produto não for encontrado

            }

            _contextDb.Produtos.Remove(produto); // Remove o produto do contexto do banco de dados
            await _contextDb.SaveChangesAsync(); // Salva as mudanças no banco de dados de forma assíncrona
            return Ok($"Produto com ID {id} removido com sucesso."); // Retorna 200 OK com uma mensagem de sucesso

        }
    }
}
