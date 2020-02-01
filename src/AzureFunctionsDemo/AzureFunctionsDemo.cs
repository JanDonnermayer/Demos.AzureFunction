using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class AzureFunctionsDemo
    {
        [FunctionName("AzureFunctionsDemo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
  

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            int x = data?.x;
            int y = data?.Y;
            var sum = x + y;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}! {x} + {y} = {sum}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
