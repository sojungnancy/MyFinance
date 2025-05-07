import React from 'react';
import NavigationBar from '../components/navbar/NavBar';

const BudgetPage: React.FC = () => {
  return (
    <div>
      <NavigationBar />
      <div style={{ padding: '2rem' }}>
        🏠 Welcome to MyFinance - This is BudgetPage page
      </div>
    </div>
  );
};

export default BudgetPage;
