# MyFinance - 💰 Personal Finance Manager

A full-stack web application to help users manage their personal finances by tracking income and expenses, analyzing spending patterns, and setting monthly budgets. Built with ASP.NET Core Web API (backend) and React (frontend), and integrated with PostgreSQL for persistent storage.

## 🚀 Features 
### 🧑‍💻 Role-Based Access Control

#### 👤 Regular User (`User` Role)

- OAuth 2.0 Google login
- View & manage personal income and expense records
- Set monthly budgets by category
- Receive budget alerts when spending exceeds limits
- View personalized analytics (income vs expense, category-wise breakdown)
- Filter and search transactions by date, category, or keyword

#### 🧑‍💼 Admin (`Admin` Role)

- View all users in the system
- Promote other users to Admin
- Delete or reset user data (transactions & budgets)
- Register system-wide announcements
- Send targeted notifications to individual users
- View system-wide transaction summaries (total income/expense)
- Analyze platform-wide user activity:
  - Total user count
  - Per-user transaction and budget stats
  - Average session duration (requires session tracking)
  - Daily activity logs (login, transaction, budget events)

> 🔐 All admin routes are protected via `[Authorize(Roles = "Admin")]`.



## 💻 Tech Stack

- **Frontend**: React (Vite, JSX)
- **Backend**: ASP.NET Core Web API (C#)
- **Database**: PostgreSQL 
- **ORM**: Entity Framework Core
- **Authentication**: OAuth 2.0 (Google), JWT
- **Dev Tools**: Swagger (Open API), Visual Studio Code
- **Deployment (Optional)**: Docker, GitHub Actions


## 🛠 Development Approach

- **Backend (ASP.NET Core Web API)**
  - Built using MVC architecture (Controller → Service → Repository)
  - Code-first database design with Entity Framework Core
  - Google OAuth 2.0 login with JWT-based authentication
  - Role-based access control (User / Admin)

- **Frontend (React + Vite)**
  - Component-based structure (`components/`, `pages/`)
  - JWT stored after login, used for user session and role-based rendering
  - Separate dashboards and features for Admin and User roles

- **Database (PostgreSQL)**
  - Core tables: `users`, `transactions`, `budgets`
  - Supports role management, activity logging, and admin features

- **Dev Tools**
  - API documentation with Swagger (OpenAPI)
  - Version control using Git & GitHub


## 📦 DB ERD

<img width="240" alt="Screenshot 2025-05-07 at 4 01 20 PM" src="https://github.com/user-attachments/assets/4b007af6-534b-48a2-afe5-afba55068e65" />


## ⚙️ Setup Instructions

#### Backend

```bash
cd backend
dotnet restore
dotnet ef database update
dotnet run
```


#### Frontend

```bash
cd frontend
npm install
npm run dev
```

#### SQL

```bash
brew services start postgresql@14
psql postgres
\c myfinance_db
```

## 📌 Future Plans

- Integrate Open Banking API for automatic transaction imports
- Email notifications for budget thresholds
- Multi-user support with advanced permissions
- Mobile app version deploy

© 2025 Sojung Kim
