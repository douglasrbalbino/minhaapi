using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Data;

namespace MinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly AppDbContext _livroDb;


        public LivroController(AppDbContext livroDb)
        {
            _livroDb = livroDb; // Injeção de dependência do contexto do banco de dados
        }




    }
}
