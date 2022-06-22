using Microsoft.AspNetCore.Mvc;
using TicketForEvent.Business.Abstract;
using TicketForEvent.Business.Validation.Street;
using TicketForEvent.DAL.Dtos.Street;

namespace TicketForEvent.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetController : ControllerBase
    {
        private readonly IStreetService _streetService;
        public StreetController(IStreetService streetService)
        {
            _streetService = streetService;
        }
        [HttpGet("GetStreetList")]
        public async Task<ActionResult<List<GetListStreetDto>>> GetStreetList()
        {
            try
            {
                return Ok(await _streetService.GetStreetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetStreetById/{id}")]
        public async Task<ActionResult<GetStreetDto>> GetStreetById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz ID!");
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var currentCountry = await _streetService.GetStreetById(id);
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
        [HttpPost("AddStreet")]
        public async Task<ActionResult<string>> AddStreet(AddStreetDto addStreetDto)
        {
            var list = new List<string>();
            var validator = new StreetAddValidator();
            var validationResults = validator.Validate(addStreetDto);
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
                var result = await _streetService.AddStreet(addStreetDto);
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
        [HttpPut("UpdateStreet/{id}")]
        public async Task<ActionResult<string>> UpdateStreet(int id, UpdateStreetDto updateStreetDto)
        {
            var list = new List<string>();
            var validator = new StreetUpdateValidator();
            var validationResults = validator.Validate(updateStreetDto);
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
                var result = await _streetService.UpdateStreet(id, updateStreetDto);
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
        [HttpDelete("DeleteStreet/{id}")]
        public async Task<ActionResult<string>> DeleteStreet(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _streetService.DeleteStreet(id);
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
