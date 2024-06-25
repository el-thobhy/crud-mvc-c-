using Aplikasi_Kota.Data_Model;
using Aplikasi_Kota.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aplikasi_Kota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KecamatanController : ControllerBase
    {
        private RepositoryKecamatan _repo;
        public KecamatanController(IConfiguration config)
        {
            _repo = new RepositoryKecamatan(config["ConnectionStrings:DB_Conn"]);
        }
        [HttpGet("GetKecamatanNative")]
        public async Task<List<MasterKecamatan>> GetKecamatanNative()
        {
            return _repo.GetKecamatanNative();
        }

        [HttpPost("CreateKecamatanNative")]
        public async Task<MasterKecamatan> CreateKecamatanNative(MasterKecamatan  data)
        {
            return _repo.CreateData(data);
        }
        [HttpPut("UpdateKecamatanNative")]
        public async Task<MasterKecamatan> UpdateKecamatanNative(MasterKecamatan data)
        {
            return _repo.UpdateData(data);
        }
        [HttpDelete("DeleteKecamatanNative/{id}/{isDeleted}")]
        public async Task<MasterKecamatan> DeleteKecamatanNative(int id, bool isDeleted)
        {
            return _repo.SoftDeletedFlag(id, isDeleted);
        }

        [HttpGet("GetById/{id}")]
        public async Task<MasterKecamatan> GetByIdKecamatanNative(int id)
        {
            return _repo.GetKecamatanByIdNative(id);
        }
    }
}
