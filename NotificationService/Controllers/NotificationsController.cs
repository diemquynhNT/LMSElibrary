using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Dto;
using NotificationService.Model;
using NotificationService.Service;

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationServices _context;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationServices context, IMapper mapper)
        {
            _context = context;
           
            _mapper = mapper;
        }


        [HttpGet("ListNotification")]
        public List<Notifications> ListNotification(string idUser)
        {
            var listnoti = _context.GetAllNotificationForUser(idUser);
            return listnoti;
        }

        [HttpPost("AddNotification")]
        public async Task<ActionResult> AddNotification([FromForm] NotificationModel notificationModel,
            string idSubject,string idClass, string idSender)
        {

            try
            {
                var noti = _mapper.Map<Notifications>(notificationModel);
                foreach(var notification in notificationModel.Idreceiver)
                {
                    await _context.AddNotification(noti, idSubject, idClass, idSender,notification);
                }
                
                return Ok("da them thong bao");
            }
            catch (Exception)
            {
                throw;
            }
        }

    
        
        [HttpDelete("deleteNotification")]
        public async Task<IActionResult> deleteNotification(string idNotification)
        {
            var result = await _context.DeleteNotification(idNotification);
            if (!result)
                return NotFound();
            return Ok("xoa thanh cong");
        }





    }
}
