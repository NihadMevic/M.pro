using Microsoft.AspNetCore.Mvc;

namespace MembersPRO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonConverter : ControllerBase
    {
        private readonly ILogger<JsonConverter> _logger;

        public JsonConverter(ILogger<JsonConverter> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Serialize([FromBody] JsonData data)
        {
            string ret = "";
            if(data != null)
            {
                try
                {
                    ret = System.Text.Json.JsonSerializer.Serialize(data);
                    return StatusCode(200, ret);
                }
                catch(Exception e)
                {
                    //log error if needed
                    return StatusCode(500, null);
                }
            }
            return StatusCode(400, null);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Deserialize([FromBody] string data)
        {
            JsonData? ret = new JsonData();
            if (data != null)
            {
                try
                {
                    ret = (JsonData?)System.Text.Json.JsonSerializer.Deserialize(data, typeof(JsonData));
                }
                catch (Exception e)
                {
                    //log error if needed
                    return StatusCode(500, null);
                }
            }
            if(ret != null)
            {
                return StatusCode(200,ret);
            }
            else
            {
                return StatusCode(400,null);
            }
        }
    }
}