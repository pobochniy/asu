using System.Text;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PublisherController : ControllerBase
    {
        public PublisherController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Publish()
        {
            //Connection information
            string user = "publisher";
            string pass = "Qwerty123!";
            string host = "109.196.164.42";

            StringBuilder res = new();
            //Set up the SSH connection
            using (var client = new SshClient(host, user, pass))
            {

                //Accept Host key
                // client.HostKeyReceived += delegate (object sender, HostKeyEventArgs e)
                // {
                //     e.CanTrust = true;
                // };

                //Start the connection
                client.Connect();

                var output = client.RunCommand("sudo docker stop $(sudo docker ps | grep \"pobochniy/asu\" | cut -d \" \" -f 1)");

                res.Append("<h3>stop</h3>");
                res.Append($"<p>{output.Result}</p>");
                res.Append($"<p>{output.Error}</p>");

                output = client.RunCommand(
                    "sudo docker run -it -p 5001:80 -d pobochniy/asu-api:2022_10_03__18_29_31 --name asu-api-hub");

                res.Append("<h3>stop</h3>");
                res.Append($"<p>{output.Result}</p>");
                res.Append($"<p>{output.Error}</p>");
                client.Disconnect();
                
                return Content(res.ToString(), "text/html");
            }
        }
    }
}