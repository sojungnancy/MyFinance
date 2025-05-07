import React from 'react';
import {} from 'react-router-dom';
import GoogleLoginButton from './GoogleLogin';

interface UserSectionProps {
  isAuthenticated: boolean;
  userName?: string;
    onLogout: () => void;
  onLoginSuccess: (userName: string, jwt: string) => void;
}

const UserSection: React.FC<UserSectionProps> = ({
  isAuthenticated,
  userName,
  onLogout,
}) => {
  return (
    <div className="nav-right">
      {isAuthenticated ? (
        <>
          <span className="user-info">👤 {userName}</span>
          <button onClick={onLogout} style={{ marginLeft: '10px' }}>
            🚪 Logout
          </button>
        </>
      ) : (
        !isAuthenticated && <GoogleLoginButton />
      )}
    </div>
  );
};

export default UserSection;
