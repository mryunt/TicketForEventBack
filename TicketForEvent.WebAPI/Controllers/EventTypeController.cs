using Microsoft.AspNetCore.Mvc;
using TicketForEvent.Business.Abstract;
using TicketForEvent.Business.Validation.EventType;
using TicketForEvent.DAL.Dtos.EventType;

namespace TicketForEvent.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IEventTypeService _eventTypeService;
        public EventTypeController(IEventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }
        [HttpGet("GetEventTypeList")]
        public async Task<ActionResult<List<GetListEventTypeDto>>> GetEventTypeList()
        {
            try
            {
                return Ok(await _eventTypeService.GetEventTypeList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetEventTypeById/{id}")]
        public async Task<ActionResult<GetEventTypeDto>> GetEventTypeById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz ID!");
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var currentCountry = await _eventTypeService.GetEventTypeById(id);
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
        [HttpPost("AddEventType")]
        public async Task<ActionResult<string>> AddEventType(AddEventTypeDto addEventTypeDto)
        {
            var list = new List<string>();
            var validator = new EventTyeAddValidator();
            var validationResults = validator.Validate(addEventTypeDto);
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
                var result = await _eventTypeService.AddEventType(addEventTypeDto);
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
        [HttpPut("UpdateEventType/{id}")]
        public async Task<ActionResult<string>> UpdateEventType(int id, UpdateEventTypeDto updateEventTypeDto)
        {
            var list = new List<string>();
            var validator = new EventTypeUpdateValidator();
            var validationResults = validator.Validate(updateEventTypeDto);
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
                var result = await _eventTypeService.UpdateEventType(id, updateEventTypeDto);
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
        [HttpDelete("DeleteEventType/{id}")]
        public async Task<ActionResult<string>> DeleteEventType(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _eventTypeService.DeleteEventType(id);
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