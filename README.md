# MyFinance - 💰 Personal Finance Manager

A full-stack web application to help users manage their personal finances by tracking income and expenses, analyzing spending patterns, and setting monthly budgets. Built with ASP.NET Core Web API (backend) and React (frontend), and integrated with PostgreSQL for persistent storage.



## 🚀 Features

#### 🔐 User Authentication
- OAuth 2.0 login (Google, Microsoft)
- JWT-based token authentication
- User-specific data separation

#### 💸 Transaction Management
- Create, update, delete income and expense records
- Categorize transactions (e.g., Food, Transport, Rent)
- Optional memo and date for each transaction

#### 📊 Spending Analysis
- Monthly income vs expense summary
- Category-wise breakdown with charts (bar, donut)
- Visual data insights to identify spending patterns

#### 🔔 Budget Alerts
- Set monthly budget per category
- Alert when budget is exceeded (e.g., "You exceeded your food budget this month!")

#### 🔍 Filtering & Search
- Filter transactions by date or category
- Keyword search support




## 🛠 Tech Stack

| Layer      | Technology                           |
|------------|---------------------------------------|
| Frontend   | React, Vite, Axios                    |
| Backend    | ASP.NET Core Web API, Entity Framework Core |
| Database   | PostgreSQL (or SQLite alternative)    |
| Auth       | OAuth 2.0, JWT                        |
| API Tools  | Swagger / OpenAPI                     |


## 📦 Folder Structure

```
myfinance-project/
├── backend/
│   ├── Controllers/
│   ├── Models/
│   │   ├── DTOs/
│   │   └── Entities (optional)
│   ├── Repositories/
│   │   ├── Interfaces/
│   ├── Data/ (DbContext)
│   └── Program.cs
├── frontend/
│   ├── src/
│   │   ├── components/
│   │   ├── pages/
│   │   └── App.jsx
```


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



## 📌 Future Plans

- Integrate Open Banking API for automatic transaction imports
- Email notifications for budget thresholds
- Multi-user support with advanced permissions
- Mobile-friendly responsive design


© 2025 Sojung Kim
