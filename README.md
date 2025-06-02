# DogBreeds - ASP.NET Core MVC App 🐶

This is a .NET 6 MVC application that manages dog breeds and sub-breeds using JSON for data storage. It provides full CRUD operations with Razor views.

---

## 🚀 Features

- ASP.NET Core MVC (.NET 6)
- JSON file-based persistence (no external DB)
- Full CRUD UI for dog breeds and sub-breeds
- Dockerized for easy deployment
- Compatible with Railway.app and Render

---

## 🛠 Project Setup

1. Clone the repository:
```bash
git clone https://github.com/yourusername/DogBreeds.git
cd DogBreeds
```

2. Run the app locally:
```bash
dotnet run
```

3. Browse to:
```
https://localhost:5001/DogBreeds
```

---

## 🐳 Docker Deployment

To run with Docker (e.g., for Railway):

### Build and Run Locally:
```bash
docker build -t dogbreeds .
docker run -p 3000:3000 dogbreeds
```

Then visit: [http://localhost:3000](http://localhost:3000)

---

## 🌍 Live Deployment on Railway

1. Add this repo to GitHub
2. Go to [https://railway.app](https://railway.app)
3. New Project > Deploy from GitHub
4. Select your DogBreeds repo
5. Done! App will be live on Railway URL

---

## 📂 Project Structure

```
DogBreeds/
├── Controllers/
├── Models/
├── Services/
├── Views/
├── Data/dogs.json
├── Program.cs
├── DogBreeds.csproj
├── Dockerfile
└── README.md
```

---

## 👩‍💻 Built By

Rachana