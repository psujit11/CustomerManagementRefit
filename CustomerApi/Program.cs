using CustomerApi.Repositories.Interfaces;
using Refit;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRefitClient<ICustomerAdditionalInfoApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7116"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/customers/additionalInfo/{id}", async (string id, ICustomerAdditionalInfoApi additionalInfoApi) =>
{
    try
    {
        var info = await additionalInfoApi.GetCustomerAdditionalInfo(id);
        return Results.Ok(info);
    }
    catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
    {
        return Results.NotFound($"Addditonal information not found for the customer id: {id}");
    }
    catch (ApiException ex)
    {
        // Log the exception details
        Console.Error.WriteLine($"API exception: {ex.Message}");
        return Results.StatusCode((int)ex.StatusCode);
    }
    catch (Exception ex)
    {
        // Log the exception details
        Console.Error.WriteLine($"General exception: {ex.Message}");
        return Results.Problem($"An error occurred: {ex.Message}");
    }
});

app.Run();
