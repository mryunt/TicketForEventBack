using Microsoft.AspNetCore.Mvc;
using TicketForEvent.Business.Abstract;
using TicketForEvent.Business.Validation.Event;
using TicketForEvent.DAL.Dtos.Event;

namespace TicketForEvent.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet("GetEventList")]
        public async Task<ActionResult<List<GetListEventDto>>> GetEvenList()
        {
            try
            {
                return Ok(await _eventService.GetEvenList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetEventById/{id}")]
        public async Task<ActionResult<GetEventDto>> GetEventById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz ID!");
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var currentCountry = await _eventService.GetEventById(id);
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
        [HttpPost("AddEvent")]
        public async Task<ActionResult<string>> AddEvent(AddEventDto addEventDto)
        {
            var list = new List<string>();
            var validator = new EventAddValidator();
            var validationResults = validator.Validate(addEventDto);
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
                var result = await _eventService.AddEvent(addEventDto);
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
        [HttpPut("UpdateEvent/{id}")]
        public async Task<ActionResult<string>> UpdateEvent(int id, UpdateEventDto updateEventDto)
        {
            var list = new List<string>();
            var validator = new EventUpdateValidator();
            var validationResults = validator.Validate(updateEventDto);
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
                var result = await _eventService.UpdateEvent(id, updateEventDto);
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
        [HttpDelete("DeleteEvent/{id}")]
        public async Task<ActionResult<string>> DeleteEvent(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _eventService.DeleteEvent(id);
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