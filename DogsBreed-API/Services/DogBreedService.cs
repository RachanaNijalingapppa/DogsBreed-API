using DogBreeds.Models;
using System.Text.Json;

namespace DogBreeds.Services
{
    public class DogBreedService
    {
        private readonly string _dataPath;
        private Dictionary<string, List<string>> _breeds;

        public DogBreedService(IWebHostEnvironment env)
        {
            _dataPath = Path.Combine(env.ContentRootPath, "Data", "dogs.json");
            LoadBreeds();
        }

        private void LoadBreeds()
        {
            if (File.Exists(_dataPath))
            {
                var json = File.ReadAllText(_dataPath);
                _breeds = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json)
                         ?? new Dictionary<string, List<string>>();
            }
            else
            {
                _breeds = new Dictionary<string, List<string>>();
            }
        }

        private void SaveBreeds()
        {
            var json = JsonSerializer.Serialize(_breeds, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_dataPath, json);
        }

        // CRUD Operations
        public List<DogBreed> GetAllBreeds()
        {
            return _breeds.Select(b => new DogBreed
            {
                Name = b.Key,
                SubBreeds = b.Value
            }).OrderBy(b => b.Name).ToList();
        }

        public DogBreed? GetBreed(string name)
        {
            if (_breeds.TryGetValue(name, out var subBreeds))
            {
                return new DogBreed { Name = name, SubBreeds = subBreeds };
            }
            return null;
        }

        public void AddBreed(DogBreed breed)
        {
            if (breed == null) throw new ArgumentNullException(nameof(breed));
            if (string.IsNullOrWhiteSpace(breed.Name)) throw new ArgumentException("Breed name cannot be empty");

            // Clean sub-breeds - remove empty/null entries
            var cleanSubBreeds = breed.SubBreeds?
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList() ?? new List<string>();

            if (_breeds.ContainsKey(breed.Name))
            {
                throw new InvalidOperationException($"Breed '{breed.Name}' already exists");
            }

            _breeds[breed.Name] = cleanSubBreeds;
            SaveBreeds();
        }


        public void UpdateBreed(string originalName, DogBreed breed)
        {
            if (originalName != breed.Name)
            {
                DeleteBreed(originalName);
            }
            _breeds[breed.Name] = breed.SubBreeds;
            SaveBreeds();
        }

        public bool DeleteBreed(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return false;

                if (!_breeds.ContainsKey(name))
                    return false;

                _breeds.Remove(name);
                SaveBreeds();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool BreedExists(string name)
        {
            return _breeds.ContainsKey(name);
        }
    }
}