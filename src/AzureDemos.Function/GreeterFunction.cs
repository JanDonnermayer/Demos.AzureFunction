using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace AzureDemos.Function
{
    public static class GreeterFunction
    {
        [FunctionName("GreeterFunction")]
        public static async Task<IActionResult> ExecuteAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger logger)
        {
            logger.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                using var reader = new StreamReader(req.Body);
                string requestBody = await reader.ReadToEndAsync().ConfigureAwait(false);
                dynamic data = JsonConvert.DeserializeObject(requestBody);

                string name = data?.name;

                var config = new ConfigurationBuilder()
                    .AddObject(new {
                        name,
                        message = "Hello $(name)!"
                    })
                    .Build();

                return name != null
                    ? (ActionResult)new OkObjectResult(config.ResolveValue("message"))
                    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, "Request failed!");
                return new BadRequestObjectResult(ex.ToString());
            }
        }
    }
}
