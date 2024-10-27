import React from 'react';
import classes from './CompleteButton.module.css'

const CompleteButton = ({className}) => {
    return (
        <button className={`${classes.CompleteButton} ${className}`}>Подтвердить выполнение</button>
    );
};

export default CompleteButton;