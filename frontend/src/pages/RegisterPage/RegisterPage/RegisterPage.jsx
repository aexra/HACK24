import React from 'react';
import AuthBackground from '../../../components/AuthBackGround/AuthBackground';
import RegisterLanding from '../RegisterLanding/RegisterLanding';

const LoginPage = () => {
    return (
        <AuthBackground>
            <RegisterLanding/>
        </AuthBackground>
    );
};

export default LoginPage;