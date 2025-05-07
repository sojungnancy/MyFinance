import React from 'react';
import NavigationBar from '../components/navbar/NavBar';
const MainPage: React.FC = () => {
  return (
    <div>
      <NavigationBar />
      <div style={{ padding: '2rem' }}>
        🏠 Welcome to MyFinance - This is main page
      </div>
    </div>
  );
};

export default MainPage;
