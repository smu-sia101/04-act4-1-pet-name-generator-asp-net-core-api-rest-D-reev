using Microsoft.AspNetCore.Mvc;
using PetNameGenerator.Controllers;
namespace RandomPetGenerator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetNameGeneratorController : ControllerBase
    {
        private static readonly Dictionary<string, List<string>> PetNames = new()
        {
            { "dog", new List<string> { "Buddy", "Max", "Charlie", "Rocky", "Rex" } },
            { "cat", new List<string> { "Whiskers", "Mittens", "Luna", "Simba", "Tiger" } },
            { "bird", new List<string> { "Tweety", "Sky", "Chirpy", "Raven", "Sunny" } }
        };

        [HttpPost("/generate")]
        public IActionResult GeneratePetName([FromBody] PetNameRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.AnimalType))
            {
                return BadRequest(new { error = "The 'animalType' field is required." });
            }

            string animalType = request.AnimalType.ToLower();
            if (!PetNames.ContainsKey(animalType))
            {
                return BadRequest(new { error = "Invalid animal type. Allowed values: dog, cat, bird." });
            }

            if (request.TwoPart.HasValue && request.TwoPart.Value != true && request.TwoPart.Value != false)
            {
                return BadRequest(new { error = "The 'twoPart' field must be a boolean (true or false)." });
            }

            var names = PetNames[animalType];
            Random random = new Random();
            string generatedName = names[random.Next(names.Count)];

            if (request.TwoPart == true)
            {
                string secondName = names[random.Next(names.Count)];
                generatedName = generatedName + secondName;
            }

            return Ok(new { name = generatedName });
        }
    }
}