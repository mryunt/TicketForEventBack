using Microsoft.AspNetCore.Mvc;
using TicketForEvent.Business.Abstract;
using TicketForEvent.Business.Validation.Seat;
using TicketForEvent.DAL.Dtos.Seat;

namespace TicketForEvent.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;
        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }
        [HttpGet("GetSeatList")]
        public async Task<ActionResult<List<GetListSeatDto>>> GetSeatList()
        {
            try
            {
                return Ok(await _seatService.GetSeatList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetSeatById/{id}")]
        public async Task<ActionResult<GetSeatDto>> GetSeatById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz ID!");
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var currentCountry = await _seatService.GetSeatById(id);
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
        [HttpPost("AddSeat")]
        public async Task<ActionResult<string>> AddSeat(AddSeatDto addSeatDto)
        {
            var list = new List<string>();
            var validator = new SeatAddValidator();
            var validationResults = validator.Validate(addSeatDto);
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
                var result = await _seatService.AddSeat(addSeatDto);
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
        [HttpPut("UpdateSeat/{id}")]
        public async Task<ActionResult<string>> UpdateSeat(int id, UpdateSeatDto updateSeatDto)
        {
            var list = new List<string>();
            var validator = new SeatUpdateValidator();
            var validationResults = validator.Validate(updateSeatDto);
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
                var result = await _seatService.UpdateSeat(id, updateSeatDto);
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
        [HttpDelete("DeleteSeat/{id}")]
        public async Task<ActionResult<string>> DeleteSeat(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _seatService.DeleteSeat(id);
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