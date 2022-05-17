using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTests.Asserts;

public static class HttpAssert
{
    public static async Task ShouldBeSuccessful(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode) return;

        var errorMsg = await response.Content.ReadAsStringAsync();
        switch (response.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
                errorMsg = "Unauthorized";
                break;
            case HttpStatusCode.Forbidden:
                errorMsg = "Forbidden";
                break;
            case HttpStatusCode.UnprocessableEntity:
                errorMsg = "Validation " + errorMsg;
                break;
        }

        if (string.IsNullOrWhiteSpace(errorMsg)) errorMsg = response.ReasonPhrase;

        Assert.True(response.IsSuccessStatusCode, "(http) " + errorMsg);
    }

    public static async Task ShouldBeValidation(this HttpResponseMessage response, IEnumerable<string> requredFields)
    {
        Assert.True(response.StatusCode == HttpStatusCode.UnprocessableEntity, "Validation status code");
        var result = await response.Content.ReadFromJsonAsync<Dictionary<string, List<string>>>();
        foreach (var field in requredFields)
        {
            Assert.True(result.ContainsKey(field), $"validation [{field}] field");
        }
    }
}