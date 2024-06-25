using Aplikasi_Kota.Data_Model;
using Aplikasi_Kota.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aplikasi_Kota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KotaController : ControllerBase
    {
        private RepositoryKota _repo;
        public KotaController(KotaDbContext dbContext, IConfiguration config)
        {
            _repo = new RepositoryKota(config["ConnectionStrings:DB_Conn"]);
        }
        [HttpGet("GetKotaNative")]
        public async Task<List<MasterKota>> GetKotaNative()
        {
            return _repo.GetKotaNative();
        }


        [HttpPost("CreateKotaNative")]
        public async Task<MasterKota> CreateKotaNative(MasterKota data)
        {
            return _repo.CreateData(data);
        }
        [HttpPut("UpdateKotaNative")]
        public async Task<MasterKota> UpdateKotaNative(MasterKota data)
        {
            return _repo.UpdateData(data);
        }
        [HttpDelete("DeleteKotaNative/{id}/{isDeleted}")]
        public async Task<MasterKota> DeleteKotaNative(int id, bool isDeleted)
        {
            return _repo.SoftDeletedFlag(id, isDeleted);
        }

        [HttpGet("GetById/{id}")]
        public async Task<MasterKota> GetByIdKotaNative(int id)
        {
            return _repo.GetKotaByIdNative(id);
        }
    }
}
