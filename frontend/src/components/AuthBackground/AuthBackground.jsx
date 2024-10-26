import React from 'react';
import classes from "./AuthBackground.module.css"

const AuthBackground = ({ children }) => {
    return (
        <div className={classes.AuthBackground}>
            {children}
        </div>
    );
};

export default AuthBackground;