import React from 'react';
import classes from './UnknownStatusButton.module.css'

const UnknownStatusButton = ({className}) => {
    return (
        <button className={`${classes.UnknownStatusButton} ${className}`}>В обработке</button>
    );
};

export default UnknownStatusButton;