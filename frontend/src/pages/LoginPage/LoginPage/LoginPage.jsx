import React from 'react';
import classes from './Login.module.css'
import LoginLayout from '../LoginLanding/LoginLanding';

const LoginPage = () => {
    return (
        <div className={classes.LoginPage}>
            <LoginLayout className={classes.LoginLayout}/>
        </div>
    );
};

export default LoginPage;