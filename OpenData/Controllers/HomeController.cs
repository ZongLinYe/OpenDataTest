using Microsoft.AspNetCore.Mvc;
using OpenData.Models;
using System.Diagnostics;
using System.Text.Json;

namespace OpenData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public async Task<IActionResult> Index()
        {


            return View();
        }

        public async Task<IActionResult> DisplayParkInTaipei()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://tppkl.blob.core.windows.net/blobfs/TaipeiParkFacility_Arcade.json"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject<List<OpenData.Models.ViewModel>>(apiResponse);
                    var parkList = JsonSerializer.Deserialize<List<Park>>(apiResponse);

                    var result = parkList.Select((x,index) =>
                    {
                        x.Index = index;
                        x.JSON = JsonSerializer.Serialize(x);
                        return x;
                    });

                    return View(result);
                }
            }
        }

        /*DeleteParkInTaipei?jsonData=${jsonDataString}&id=${id}*/
        [HttpDelete]
        public ActionResult DeleteParkInTaipei(string jsonData,int id)
        {
            var a = JsonSerializer.Deserialize<Park>(jsonData);
            var idIndex = id;
            return NoContent();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}