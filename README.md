# Oslo Orbit 🌐

## 🛠 Tech Stack

### Backend

-   ✅ ASP.NET Core 9 (C#)
-   ✅ Clean Architecture (Domain, Application, Infrastructure, Presentation)
-   ✅ Entity Framework Core (PostgreSQL)
-   ✅ RESTful API

### Frontend

-   ⚡ Vite + React
-   🎨 Tailwind CSS (optional)

### DevOps

-   🐳 Docker & Docker Compose
-   📦 GitHub Packages (optional)
-   🔐 User authentication planned (JWT or IdentityServer)

---

## 🚀 Features

-   🧵 Topic-based discussion forum
-   📊 Focus on **Tech + Finance**
-   🔍 Search and filter threads
-   🧠 Tag-based categorization
-   🧑‍💼 User profiles (planned)
-   📈 Analytics or insights panel (future roadmap)

---

## 🗂 Folder Structure

```
/client/ → Vite + React frontend
/server/ → .NET Clean Architecture backend
├── Core/ Domain models & interfaces
├── Application/ Use cases & business logic
├── Infrastructure/ Persistence, external services
├── WebApi/ API controllers & middleware
docker-compose.yml → Dev environment setup
```

---

## 🧪 Running Locally (Dev)

```bash
# Clone the repo
git clone https://github.com/SebastianGronbech/oslo-orbit.git
cd oslo-orbit

# Start full stack (client + API + db)
docker-compose up --build

```
