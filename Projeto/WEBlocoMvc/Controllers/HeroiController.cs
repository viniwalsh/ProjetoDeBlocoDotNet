using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WEBloco.Domain.Model.Entities;
using WEBloco.Infrastructure.Services;

namespace WEBlocoMvc.Controllers
{
    public class HeroiController : Controller
    {
        private readonly HttpClient _client;
        private const string RESOURCE = @"/api/heroi";

        public HeroiController(IHttpClientFactory service)
        {
            _client = service.CreateClient("backend");
        }

        // GET: Heroi
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, RESOURCE);

            var httpResponse = await _client.SendAsync(request);

            httpResponse.EnsureSuccessStatusCode();

            var responseJsonString = await httpResponse.Content.ReadAsStringAsync();

            var herois = JsonConvert.DeserializeObject<IEnumerable<Heroi>>(responseJsonString);

            return View(herois);
        }

        // GET: Heroi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heroi = await GetById(id.Value);

            return View(heroi);
        }

        // GET: Heroi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Heroi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Heroi heroi)
        {
            if (ModelState.IsValid)
            {
                //RECUPERANDO VÁRIAS IMAGENS DE UMA UNICA VEZ E CONVERTENDO BYTES DA IMAGEM EM STRING BASE64
                //CENÁRIO PARA PERSISTIR BLOB A PARTIR DA WEBAPI
                foreach (var inputFile in Request.Form.Files)
                {
                    string imageBase64 = inputFile.OpenReadStream().ConvertToBase64();
                    heroi.ImagensBase64.Add(imageBase64);
                }

                var serialized = JsonConvert.SerializeObject(heroi);
                HttpContent jsonContent = new StringContent(serialized, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync($"{RESOURCE}", jsonContent);

                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }
            return View(heroi);
        }

        private async Task<Heroi> GetById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{RESOURCE}/{id}");

            var httpResponse = await _client.SendAsync(request);

            httpResponse.EnsureSuccessStatusCode();

            var responseJsonString = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Heroi>(responseJsonString);
        }

    }
}
