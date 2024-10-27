import React from 'react';
import classes from './Landing.module.css'

const Landing = ({ children, className }) => {
    return (
        <div className={`${classes.Landing} ${className}`}>
            {children}
        </div>
    );
};

export default Landing;