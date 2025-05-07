// src/pages/LoginSuccessPage.tsx
//import React from 'react';
import { useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';

const LoginSuccessPage = () => {
  const navigate = useNavigate();
  const location = useLocation();

  useEffect(() => {
    const params = new URLSearchParams(location.search);
    const token = params.get('token');
    const email = params.get('email');
    const name = params.get('name');

    if (token && email && name) {
      localStorage.setItem('jwt', token);
      localStorage.setItem('userEmail', email);
      localStorage.setItem('userName', name);

      navigate('/dashboard');
    } else {
      navigate('/');
    }
  }, [location, navigate]);

  return <p>Loading..</p>;
};

export default LoginSuccessPage;
