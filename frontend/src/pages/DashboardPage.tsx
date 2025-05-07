import React from 'react';
import NavigationBar from '../components/navbar/NavBar';

const DashboardPage: React.FC = () => {
  return (
    <div>
      <NavigationBar />
      <div style={{ padding: '2rem' }}>
        🏠 Welcome to MyFinance - This is DashboardPage page
      </div>
    </div>
  );
};

export default DashboardPage;
