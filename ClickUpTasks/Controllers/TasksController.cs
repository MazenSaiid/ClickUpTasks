using ClassLibary.ClickUp.Webhook;
using ClassLibrary.ClickUp.DTO;
using ClassLibrary.ClickUp.Functions;
using DocuSign.eSign.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.X9;
using System.Text;

namespace ClickUpTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly string ClickUpApiKey = "pk_75493887_QE5PY69FYQQ0WUJZY7HQZ096AKGVOV37";

        [HttpPut]
        [Route("DeleteCustomField")]
        public async Task<IActionResult> DeleteTask([FromQuery] string fieldId, [FromBody] ClickUpPayload payload)
        {
            try
            {
                if (payload is null || payload.payload is null || fieldId is null)
                {
                    return BadRequest("Payload and fieldId are required");

                }
                // Check if payload status is deleted
                if (payload.payload.status.status == "deleted")
                {
                    var taskId = payload.payload.id;
                    var customField = payload.payload.custom_fields.FirstOrDefault(f => f.id == fieldId);

                    if (customField != null)
                    {
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri("https://api.clickup.com/api/v2/");
                            client.DefaultRequestHeaders.Add("Authorization", ClickUpApiKey);

                            var updateData = new
                            {
                                value = (object)null
                            };

                            var jsonContent = new StringContent(JsonConvert.SerializeObject(updateData), Encoding.UTF8, "application/json");

                            // PUT request to ClickUp API to update the custom field value
                            HttpResponseMessage response = await client.PutAsync($"task/{taskId}/field/{fieldId}", jsonContent);

                            if (response.IsSuccessStatusCode)
                            {
                                // Custom field value deleted successfully
                                Console.WriteLine("Custom field value deleted successfully.");
                                return Ok("Custom field value deleted successfully.");
                            }
                            else
                            {
                                // Handle error response from ClickUp API
                                Console.WriteLine("Failed to delete custom field value: " + response.ReasonPhrase);
                                return StatusCode((int)response.StatusCode, "Failed to delete custom field value: " + response.ReasonPhrase);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Custom field with ID {fieldId} is not found.");
                        return NoContent();
                    }
                }
                else
                {
                    return BadRequest("Payload status is not 'deleted'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing webhook: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

    }   }
}
