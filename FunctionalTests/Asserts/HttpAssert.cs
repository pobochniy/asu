using System.Net;
using System.Net.Http;
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
}