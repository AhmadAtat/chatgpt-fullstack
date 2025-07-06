## AI Chat Application

A full-stack AI chatbot demonstrating integration of a Vue 3 frontend with an ASP.NET Core backend using the OpenAI GPT-3.5 API.

---

### 🚀 Project Title & Summary

**AI Chat Application**: A responsive web chat interface powered by OpenAI's GPT-3.5 model, built with Vue 3 and Vite for the frontend and ASP.NET Core Web API for the backend.

---

### 🛠️ Tech Stack

* **Frontend**: Vue 3, Vite
* **Backend**: ASP.NET Core 7 Web API, C#
* **AI Integration**: OpenAI GPT-3.5 API (GPT-3.5-turbo)
* **Configurations**: Environment variables (.env, appsettings.json)

---

### 📦 Setup Instructions

1. **Clone the repository**

   ```bash
   git clone https://github.com/YourUsername/chatgpt-fullstack.git
   cd chatgpt-fullstack
   ```

2. **Backend Setup (ASP.NET Core)**

   * Copy and rename the template:

     ```bash
     cp appsettings.Development.template.json appsettings.Development.json
     ```
   * Edit `appsettings.Development.json`:

     ```json
     {
       "OpenAI": { "ApiKey": "sk-your-openai-key" }
     }
     ```
   * Restore and run:

     ```bash
     dotnet restore
     dotnet run --launch-profile http
     ```
   * The API will be available at: `http://localhost:5055`

3. \*\*Frontend Setup (Vue 3 + Vite)\*\*n   - Navigate to the Vue project:

   ```bash
   cd ai-chat-vue
   ```

   * Create environment file:

     ```bash
     echo "VITE_API_BASE_URL=http://localhost:5055/api" > .env
     ```
   * Install dependencies and start dev server:

     ```bash
     npm install
     npm run dev
     ```
   * The chat UI will be available at: `http://localhost:5173`

---

### 📸 Screenshots / Live Demo

> *Optional: Add screenshots here or link to a live demo deployment.*

---

### 🌟 Key Features

* **Interactive Chat UI**: Real-time chat interface built with Vue 3 and Vite.
* **AI-Powered Responses**: Utilizes OpenAI GPT-3.5-turbo for intelligent chat replies.
* **Secure Key Handling**: API keys stored in `appsettings.Development.json` and `.env`, both ignored by Git.
* **Environment-Based Config**: Easily switch between development and production settings via environment variables.
* **Single-Port Production Build**: Static Vue build served by ASP.NET Core for simplified deployment.

---

### 📄 License

MIT © Ahmad Al Atat
