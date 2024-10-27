import React from 'react';
import AuthBackground from '../../../components/AuthBackGround/AuthBackground';
import LoginLanding from '../LoginLanding/LoginLanding';

const LoginPage = () => {
    return (
        <AuthBackground>
            <LoginLanding />
        </AuthBackground>
    );
};

export default LoginPage;