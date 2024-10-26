import React from 'react';
import Landing from '../../components/Landing/Landing';
import classes from './AuthLanding.module.css'

const AuthLanding = ({children}) => {
    return (
        <Landing className={classes.AuthLanding}>
            {children}
        </Landing>
    );
};

export default AuthLanding;