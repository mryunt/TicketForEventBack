using Microsoft.AspNetCore.Mvc;
using TicketForEvent.Business.Abstract;
using TicketForEvent.Business.Validation.Township;
using TicketForEvent.DAL.Dtos.Township;

namespace TicketForEvent.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownshipController : ControllerBase
    {
        private readonly ITownshipService _townshipService;
        public TownshipController(ITownshipService townshipService)
        {
            _townshipService = townshipService;
        }
        [HttpGet("GetTownshipList")]
        public async Task<ActionResult<List<GetListTownshipDto>>> GetTownshipList()
        {
            try
            {
                return Ok(await _townshipService.GetTownshipList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTownshipById/{id}")]
        public async Task<ActionResult<GetTownshipDto>> GetTownshipById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz ID!");
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var currentCountry = await _townshipService.GetTownshipById(id);
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
        [HttpPost("AddTownship")]
        public async Task<ActionResult<string>> AddTownship(AddTownshipDto addTownshipDto)
        {
            var list = new List<string>();
            var validator = new TownshipAddValidator();
            var validationResults = validator.Validate(addTownshipDto);
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
                var result = await _townshipService.AddTownship(addTownshipDto);
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
        [HttpPut("UpdateTownship/{id}")]
        public async Task<ActionResult<string>> UpdateTownship(int id, UpdateTownshipDto updateTownshipDto)
        {
            var list = new List<string>();
            var validator = new TownshipUpdateValidator();
            var validationResults = validator.Validate(updateTownshipDto);
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
                var result = await _townshipService.UpdateTownship(id, updateTownshipDto);
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
        [HttpDelete("DeleteTownship/{id}")]
        public async Task<ActionResult<string>> DeleteTownship(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _townshipService.DeleteTownship(id);
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