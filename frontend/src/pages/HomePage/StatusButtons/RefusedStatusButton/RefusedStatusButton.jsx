import React from 'react';
import classes from './RefusedStatusButton.module.css'

const RefusedStatusButton = ({className}) => {
    return (
        <button className={`${classes.RefusedStatusButton} ${className}`}>Отклонен</button>
    );
};

export default RefusedStatusButton;