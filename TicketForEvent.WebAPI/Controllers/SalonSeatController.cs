using Microsoft.AspNetCore.Mvc;
using TicketForEvent.Business.Abstract;
using TicketForEvent.Business.Validation.SalonSeat;
using TicketForEvent.DAL.Dtos.SalonSeat;

namespace TicketForEvent.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonSeatController : ControllerBase
    {
        private readonly ISalonSeatService _salonSeatService;
        public SalonSeatController(ISalonSeatService salonSeatService)
        {
            _salonSeatService = salonSeatService;
        }
        [HttpGet("GetSalonSeatList")]
        public async Task<ActionResult<List<GetListSalonSeatDto>>> GetSalonSeatList()
        {
            try
            {
                return Ok(await _salonSeatService.GetSalonSeatList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetSalonSeatById/{id}")]
        public async Task<ActionResult<GetSalonSeatDto>> GetSalonSeatById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz ID!");
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var currentCountry = await _salonSeatService.GetSalonSeatById(id);
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
        [HttpPost("AddSalonSeat")]
        public async Task<ActionResult<string>> AddSalonSeat(AddSalonSeatDto addSalonSeatDto)
        {
            var list = new List<string>();
            var validator = new SalonSeatAddValidator();
            var validationResults = validator.Validate(addSalonSeatDto);
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
                var result = await _salonSeatService.AddSalonSeat(addSalonSeatDto);
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
        [HttpPut("UpdateSalonSeat/{id}")]
        public async Task<ActionResult<string>> UpdateSalonSeat(int id, UpdateSalonSeatDto updateSalonSeatDto)
        {
            var list = new List<string>();
            var validator = new SalonSeatUpdateValidator();
            var validationResults = validator.Validate(updateSalonSeatDto);
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
                var result = await _salonSeatService.UpdateSalonSeat(id, updateSalonSeatDto);
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
        [HttpDelete("DeleteSalonSeat/{id}")]
        public async Task<ActionResult<string>> DeleteSalonSeat(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _salonSeatService.DeleteSalonSeat(id);
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
