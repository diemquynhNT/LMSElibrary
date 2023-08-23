using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalfilesService.Model;
using PersonalfilesService.Service;
using System;

namespace PersonalfilesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _uploadService;

        public FilesController(IFileService uploadService)
        {
            _uploadService = uploadService;
        }
        [HttpGet]
        public List<FileDetails> Get()
        {
            try
            {
                List<FileDetails> fls = _uploadService.GetAlFile();
                return fls; 
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile(string IdUser,IFormFile fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                await _uploadService.PostFileAsync(IdUser,fileDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("download")]
        public async Task<IActionResult> DownloadAttachment(int id)
        {
            var i = await _uploadService.GetFileById(id);
            var path = Path.Combine(
               Directory.GetCurrentDirectory(), "wwwroot\\uploads\\",i.FileName );
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "application/x-msdownload", i.FileName);
        }
        //[HttpGet("DownloadFile")]
        //public async Task<ActionResult> DownloadFile(int id)
        //{
        //    if (id < 1)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _uploadService.DownloadFileById(id);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpDelete("DeleteFile")]
        public async Task<ActionResult> DeleteFile(int id)
        {
            try
            {
                var check=await _uploadService.DeleteFileById(id);
                if (!check)
                    return BadRequest();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
