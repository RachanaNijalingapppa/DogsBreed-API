using DogBreeds.Models;
using DogBreeds.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogBreeds.Controllers
{
    public class DogBreedsController : Controller
    {
        private readonly DogBreedService _service;

        public DogBreedsController(DogBreedService service)
        {
            _service = service;
        }

        // GET: DogBreeds
        public IActionResult Index()
        {
            return View(_service.GetAllBreeds());
        }

        // GET: DogBreeds/Details/name
        public IActionResult Details(string id)
        {
            var breed = _service.GetBreed(id);
            if (breed == null)
            {
                return NotFound();
            }
            return View(breed);
        }

        // GET: DogBreeds/Create
        public IActionResult Create()
        {
            return View(new DogBreed { SubBreeds = new List<string>() });
        }


        // POST: DogBreeds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DogBreed breed)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Ensure SubBreeds list exists
                    breed.SubBreeds = breed.SubBreeds ?? new List<string>();

                    // Clean empty sub-breeds
                    breed.SubBreeds = breed.SubBreeds
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .ToList();

                    _service.AddBreed(breed);
                    TempData["SuccessMessage"] = $"Breed '{breed.Name}' added successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            // If we get here, something went wrong
            return View(breed);
        }

        // GET: DogBreeds/Edit/name
        public IActionResult Edit(string id)
        {
            var breed = _service.GetBreed(id);
            if (breed == null)
            {
                return NotFound();
            }
            return View(breed);
        }

        // POST: DogBreeds/Edit/name
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Name,SubBreeds")] DogBreed breed)
        {
            if (id != breed.Name)
            {
                if (_service.BreedExists(breed.Name))
                {
                    ModelState.AddModelError("Name", "Breed with this name already exists");
                    return View(breed);
                }
            }

            if (ModelState.IsValid)
            {
                _service.UpdateBreed(id, breed);
                return RedirectToAction(nameof(Index));
            }
            return View(breed);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var breed = _service.GetBreed(id);
            if (breed == null)
            {
                return NotFound();
            }

            return View(breed);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                TempData["ErrorMessage"] = "Invalid breed name";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                bool deleteResult = _service.DeleteBreed(id);

                if (!deleteResult)
                {
                    TempData["ErrorMessage"] = "Breed not found or could not be deleted";
                    return RedirectToAction(nameof(Index));
                }

                TempData["SuccessMessage"] = "Breed deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting breed: {ex.Message}";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}