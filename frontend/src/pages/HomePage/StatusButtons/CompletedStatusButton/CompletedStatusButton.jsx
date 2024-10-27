import React from 'react';
import classes from './CompletedStatusButton.module.css'

const CompletedStatusButton = ({className}) => {
    return (
        <button className={`${classes.CompletedStatusButton} ${className}`}>Выполнен</button>
    );
};

export default CompletedStatusButton;