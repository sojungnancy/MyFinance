import React from 'react';

const GoogleLoginButton: React.FC = () => {
  const handleLogin = () => {
    window.location.href = 'https://localhost:5050/auth/login';
  };

  return <button onClick={handleLogin}>🔐 Log in with Google</button>;
};

export default GoogleLoginButton;
