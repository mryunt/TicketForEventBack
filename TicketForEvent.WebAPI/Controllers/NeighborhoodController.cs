using Microsoft.AspNetCore.Mvc;
using TicketForEvent.Business.Abstract;
using TicketForEvent.Business.Validation.Neighborhood;
using TicketForEvent.DAL.Dtos.Neighborhood;

namespace TicketForEvent.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighborhoodController : ControllerBase
    {
        private readonly INeighborhoodService _neighborhoodService;
        public NeighborhoodController(INeighborhoodService neighborhoodService)
        {
            _neighborhoodService = neighborhoodService;
        }
        [HttpGet("GetNeighborhoodList")]
        public async Task<ActionResult<List<GetListNeighborhoodDto>>> GetNeighborhoodList()
        {
            try
            {
                return Ok(await _neighborhoodService.GetNeighborhoodList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetNeighborhoodById/{id}")]
        public async Task<ActionResult<GetNeighborhoodDto>> GetNeighborhoodById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz ID!");
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var currentCountry = await _neighborhoodService.GetNeighborhoodById(id);
                if (currentCountry == null)
                {
                    list.Add("Kayıt Bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });

                }
                else
                {
                    return currentCountry;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddNeighborhood")]
        public async Task<ActionResult<string>> AddNeighborhood(AddNeighborhoodDto addNeighborhoodDto)
        {
            var list = new List<string>();
            var validator = new NeighborhoodAddValidator();
            var validationResults = validator.Validate(addNeighborhoodDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            try
            {
                var result = await _neighborhoodService.AddNeighborhood(addNeighborhoodDto);
                if (result > 0)
                {
                    list.Add("Kayıt Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else
                {
                    list.Add("Kayıt Başarısız!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateNeighborhood/{id}")]
        public async Task<ActionResult<string>> UpdateNeighborhood(int id, UpdateNeighborhoodDto updateNeighborhoodDto)
        {
            var list = new List<string>();
            var validator = new NeighborhoodUpdateValidator();
            var validationResults = validator.Validate(updateNeighborhoodDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            try
            {
                var result = await _neighborhoodService.UpdateNeighborhood(id, updateNeighborhoodDto);
                if (result > 0)
                {
                    list.Add("Güncelleme Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Kayıt Bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Güncelleme Başarısız!");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteNeighborhood/{id}")]
        public async Task<ActionResult<string>> DeleteNeighborhood(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _neighborhoodService.DeleteNeighborhood(id);
                if (result > 0)
                {
                    list.Add("Silme işlemi başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Kayıt bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Silme işlemi Başarısız!");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
