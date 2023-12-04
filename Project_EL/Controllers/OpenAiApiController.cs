using Microsoft.AspNetCore.Mvc;
using System.IO;
using OpenAI_API;
using System.Threading.Tasks;

namespace Project_EL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAiApiController : ControllerBase
    {
        OpenAIAPI api;
        public OpenAiApiController()
        {
            using (var sr = new StreamReader("apikey.txt"))
            {
                api = new OpenAIAPI(sr.ReadLine());
                sr.Close();
            }
        }

        public async Task<string> GetQueryResult(string query)
        {
            var chat = api.Chat.CreateConversation();
            chat.AppendUserInput(query);
            return await chat.GetResponseFromChatbotAsync();
        }
    }
}
