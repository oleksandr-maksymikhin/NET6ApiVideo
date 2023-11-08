using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NET6ApiVideo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        // Replace with the actual path to your video file.
        private readonly string videoFilePath = "D:\\Education\\Step\\0_urgent\\20221110_Pictures_ForHolywoodService\\Interstellar.mp4";

        //[HttpGet("{videoFileName}")]
        [HttpGet]
        //[Route("{Id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileStreamResult))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public IActionResult GetVideo(string videoFileName)
        public IActionResult GetVideo()
        {
            try
            {
                //if (videoFileName != "your_video.mp4")
                //{
                //    return NotFound();
                //}

                var stream = new FileStream(videoFilePath, FileMode.Open, FileAccess.Read);
                //var response = File(stream);
                //var response = File(stream, "video/mp4");
                //// !!!!! enableRangeProcessing: true - allow partial transfer video and scroll it in client
                var response = File(stream, "video/mp4", enableRangeProcessing: true);
                //// "application/octet-stream" - is a unified/defaut content-type, but may be it should be processed sonehow on client side.
                //var response = File(stream, "application/octet-stream", enableRangeProcessing: true);
                
                return response;
            }
            catch (Exception ex)
            {
                // Handle exceptions here, e.g., log the error or return a custom error response.
                return StatusCode(500, "Internal Server Error");
            }
        }

        //// not wprking - 500 code
        /*[HttpGet]
        public async Task<IResult> GetVideo()
        {
            try
            {
                var stream = new FileStream(videoFilePath, FileMode.Open, FileAccess.Read);
                var response =  Results.File(stream, contentType: "video/mp4", enableRangeProcessing: true);
                return response;
            }
            catch (Exception ex)
            {
                // Handle exceptions here, e.g., log the error or return a custom error response.
                return null;
            }
        }*/

    }
}
