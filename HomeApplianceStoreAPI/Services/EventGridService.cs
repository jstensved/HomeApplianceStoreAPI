using HomeApplianceStoreAPI.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceStoreAPI.Services
{
    public class EventGridService
    {

        private readonly IOptions<EventGridOptions> options;

        public EventGridService(IOptions<EventGridOptions> options)
        {
            this.options = options;
        }

        public async Task PublishEvent<T>(string subject, string type, T data)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("aeg-sas-key", this.options.Value.Key);
            //client.DefaultRequestHeaders.UserAgent.ParseAdd("democlient");

            var gridEvents = new object[]{ new
                {
                    Subject = subject,
                    EventType = type,
                    EventTime = DateTime.UtcNow,
                    Id = Guid.NewGuid().ToString(),
                    data = data
                }
            };

            string json = JsonConvert.SerializeObject(gridEvents);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, options.Value.Url)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request);

        }
    }
}
