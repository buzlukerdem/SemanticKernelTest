using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder().AddOllamaChatCompletion("deepseek-r1:7b",
    "http://localhost:11434");

//var builder = Kernel.CreateBuilder().AddOllamaChatCompletion("deepseek-r1:latest",
//    "http://localhost:11434");

// HttpClient added ioc
builder.Services.AddScoped<HttpClient>();

var kernel = builder.Build();


while (true)
{
    Console.WriteLine("Ask Something...");
    string input = Console.ReadLine();
    var res = await kernel.InvokePromptAsync(input);
    Console.WriteLine($"Response: \n--------------\n{res}");
}