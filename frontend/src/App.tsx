// eslint-disable-next-line @typescript-eslint/no-unused-vars
//import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import MainPage from './pages/MainPage';
import DashboardPage from './pages/DashboardPage';
import TransactionsPage from './pages/TransactionsPage';
import BudgetPage from './pages/BudgetPage';
import LoginSuccessPage from '../login/LoginSuccess';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/login/success" element={<LoginSuccessPage />} />

        <Route path="/" element={<MainPage />} />
        <Route path="/dashboard" element={<DashboardPage />} />
        <Route path="/transactions" element={<TransactionsPage />} />
        <Route path="/budget" element={<BudgetPage />} />
      </Routes>
    </Router>
  );
}

export default App;
