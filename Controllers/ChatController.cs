using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public ChatController(IOptions<OpenAISettings> options)
    {
        if (options == null || options.Value.ApiKey == null)
        {
            throw new ArgumentNullException(nameof(options), "API key must be provided.");
        }

        _apiKey = options.Value.ApiKey;

        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
    }

    [HttpPost]
    public async Task<IActionResult> Chat([FromBody] ChatRequest request)
    {
        var openAiRequest = new
        {
            model = "gpt-3.5-turbo",
            messages = new[] {
                new { role = "user", content = request.Message }
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(openAiRequest), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
        var responseString = await response.Content.ReadAsStringAsync();

        return Content(responseString, "application/json");
    }
}

public class ChatRequest
{
    public string? Message { get; set; }
}
