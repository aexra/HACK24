import React from 'react';
import classes from './Login.module.css'
import LoginLayout from '../LoginLanding/LoginLanding';
import Header from '../../../modules/Header/Header';

const LoginPage = () => {
    return (
        <div className={classes.LoginPage}>
            <Header />
            <LoginLayout className={classes.LoginLayout} />
        </div>
    );
};

export default LoginPage;