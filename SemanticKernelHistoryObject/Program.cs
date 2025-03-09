using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = Kernel.CreateBuilder().AddOllamaChatCompletion("deepseek-r1:latest",
    "http://localhost:11434");

// HttpClient added ioc
builder.Services.AddScoped<HttpClient>();

var kernel = builder.Build();

var history = new ChatHistory();

Console.WriteLine("Ask Something: ");
string input = Console.ReadLine();
history.AddUserMessage(input);

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
var response = await chatCompletionService.GetChatMessageContentAsync(history);

history.AddAssistantMessage(response.ToString());
Console.WriteLine(response.ToString());
