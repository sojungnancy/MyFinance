// src/pages/LoginPage.tsx

import axios from 'axios';

const handleGoogleLogin = async () => {
  try {
    const response = await axios.get('http://localhost:5024/auth/login', {
      withCredentials: true,
    });

    const token = response.data.token;
    const user = response.data.user;

    // ✅ localStorage에 저장
    localStorage.setItem('token', token);
    localStorage.setItem('user', JSON.stringify(user));

    alert('로그인 성공!');
  } catch (error) {
    console.error('로그인 실패', error);
  }
};
