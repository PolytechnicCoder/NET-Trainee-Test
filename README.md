🚀 .NET Trainee Test Application

🌍 Overview

This is an ASP.NET Core MVC application designed as a trainee test project. It includes database interaction via Entity Framework Core and follows the MVC architectural pattern.

📌 Features

🛠 MVC Architecture (Model-View-Controller pattern)

💾 Database Integration with SQL Server

🔄 RESTful API Controllers for data handling

🎨 Razor Views for front-end rendering

📂 Static file serving via wwwroot

🛠 Technologies Used

ASP.NET Core MVC

Entity Framework Core

SQL Server (Database)

C#

Razor Views


🚀 Installation & Setup

1️⃣ Clone the Repository:

git clone [CLICK](https://github.com/PolytechnicCoder/NET-Trainee-Test/tree/master)

2️⃣ Install Dependencies:

dotnet restore

3️⃣ Set Up Database:

Update the connection string in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;"
}

Apply migrations:

dotnet ef database update

4️⃣ Run the Application:

dotnet run

By default, the app runs on https://localhost:5001/.

📂 Project Structure

NET-Trainee-Test/
│── Controllers/       # MVC Controllers
│── Data/              # Database context & migrations
│── Models/            # Data models
│── Views/             # Razor views for UI
│── wwwroot/           # Static files (CSS, JS, images)
│── Program.cs         # Main entry point
│── appsettings.json   # Configuration file
│── PersonDb.bak       # Database backup file

💡 .NET Trainee Test - Built with ASP.NET Core & EF Core
