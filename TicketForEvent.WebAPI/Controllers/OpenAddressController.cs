using Microsoft.AspNetCore.Mvc;
using TicketForEvent.Business.Abstract;
using TicketForEvent.Business.Validation.OpenAddress;
using TicketForEvent.DAL.Dtos.OpenAddress;

namespace TicketForEvent.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAddressController : ControllerBase
    {
        private readonly IOpenAddressService _openAddressService;
        public OpenAddressController(IOpenAddressService openAddressService)
        {
            _openAddressService = openAddressService;
        }
        [HttpGet("GetOpenAddressList")]
        public async Task<ActionResult<List<GetListOpenAddressDto>>> GetOpenAddressList()
        {
            try
            {
                return Ok(await _openAddressService.GetOpenAddressList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetOpenAddressById/{id}")]
        public async Task<ActionResult<GetOpenAddressDto>> GetOpenAddressById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz ID!");
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var currentCountry = await _openAddressService.GetOpenAddressById(id);
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
        [HttpPost("AddOpenAddress")]
        public async Task<ActionResult<string>> AddOpenAddress(AddOpenAddressDto addOpenAddressDto)
        {
            var list = new List<string>();
            var validator = new OpenAddressAddValidator();
            var validationResults = validator.Validate(addOpenAddressDto);
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
                var result = await _openAddressService.AddOpenAddress(addOpenAddressDto);
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
        [HttpPut("UpdateOpenAddress/{id}")]
        public async Task<ActionResult<string>> UpdateOpenAddress(int id, UpdateOpenAddressDto updateOpenAddressDto)
        {
            var list = new List<string>();
            var validator = new OpenAddressUpdateValidator();
            var validationResults = validator.Validate(updateOpenAddressDto);
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
                var result = await _openAddressService.UpdateOpenAddress(id, updateOpenAddressDto);
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
        [HttpDelete("DeleteOpenAddress/{id}")]
        public async Task<ActionResult<string>> DeleteOpenAddress(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _openAddressService.DeleteOpenAddress(id);
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
