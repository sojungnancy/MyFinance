// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import './NavBar.css';
import UserSection from './User';

const NavigationBar = () => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [userName, setUserName] = useState('');

  useEffect(() => {
    const token = localStorage.getItem('jwt');
    const name = localStorage.getItem('userName');
    if (token && name) {
      setIsAuthenticated(true);
      setUserName(name);
    }
  }, []);

  const handleLogout = () => {
    localStorage.removeItem('jwt');
    localStorage.removeItem('userName');
    localStorage.removeItem('userEmail');
    setIsAuthenticated(false);
    setUserName('');
  };
  const handleLoginSuccess = (name: string, token: string) => {
    setUserName(name);
    setIsAuthenticated(true);
    localStorage.setItem('userName', name);
    localStorage.setItem('jwt', token);
  };

  return (
    <nav className="navbar">
      <div className="nav-left">
        <Link to="/" className="logo">
          💼 MyFinance
        </Link>
      </div>

      <ul className="nav-center">
        <li>
          <Link to="/">🏠 Home</Link>
        </li>
        <li>
          <Link to="/dashboard">📊 Dashboard</Link>
        </li>
        <li>
          <Link to="/transactions">💸 Transactions</Link>
        </li>
        <li>
          <Link to="/budget">💰 Budget</Link>
        </li>
      </ul>

      <UserSection
        isAuthenticated={isAuthenticated}
        userName={userName}
        onLoginSuccess={handleLoginSuccess}
        onLogout={handleLogout}
      />
    </nav>
  );
};

export default NavigationBar;
