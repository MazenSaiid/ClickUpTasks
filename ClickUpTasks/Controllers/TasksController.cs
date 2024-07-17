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

        [HttpPost]
        [Route("DeleteTask")]
        public async Task<IActionResult> DeleteTask([FromQuery] string fieldId, [FromBody] ClickUpPayload payload)
        {
            try
            { 
                StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);

                var payloadText = reader.ReadToEndAsync();

                payload = (ClickUpPayload)JsonConvert.DeserializeObject<ClickUpPayload>(payloadText.Result);

                var taskId = payload.payload.id;
                var taskName = payload.payload.name;

                var errorDetails = payload.payload.id + " " + payload.payload.name;

                var taskTypeFieldToDelete = payload.payload.custom_fields.FirstOrDefault(f => f.id == fieldId);

                if (taskTypeFieldToDelete.value != null)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://api.clickup.com/api/v2/");
                        client.DefaultRequestHeaders.Add("Authorization", ClickUpApiKey);

                        // DELETE request to ClickUp API to delete the task
                        HttpResponseMessage response = await client.DeleteAsync($"task/{taskTypeFieldToDelete}");

                        if (response.IsSuccessStatusCode)
                        {
                            // Task deleted successfully
                            Console.WriteLine("Task deleted successfully.");
                        }
                        else
                        {
                            // Handle error response from ClickUp API
                            Console.WriteLine("Failed to delete task: " + response.ReasonPhrase);
                        }

                    }
                }
                else
                {
                    Console.WriteLine($"Task with below {fieldId} is not found");
                    return NoContent(); 
                }

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing webhook: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
