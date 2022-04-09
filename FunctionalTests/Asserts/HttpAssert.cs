using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTests.Asserts;

public static class HttpAssert //: Xunit.Assert
{
    // public static async Task ModelStateErrors(HttpResponseMessage response)
    // {
    //     if (response.StatusCode == HttpStatusCode.NotAcceptable)
    //     {
    //         var message = await response.Content.ReadFromJsonAsync<BadRequestResponse>();
    //         Assert.True(response.IsSuccessStatusCode, JsonConvert.SerializeObject(message.Errors));
    //     }
    // }
    //
    // public static async Task BadRequestError(HttpResponseMessage response)
    // {
    //     if (response.StatusCode == HttpStatusCode.BadRequest)
    //     {
    //         var msg = await response.Content.ReadAsStringAsync();
    //         Assert.True(response.IsSuccessStatusCode, JsonConvert.SerializeObject(msg));
    //     }
    // }

    public static async Task ShouldBeSuccessful(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode) return;

        var errorMsg = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
        {
            errorMsg = "Validation "+ errorMsg;
        }

        Assert.True(response.IsSuccessStatusCode, errorMsg);
    }
}