import React from 'react';
import classes from './Filter.module.css';

const Filter = ({ onFilter, buttonText }) => {
    return (
        <button className={classes.FilterButton} onClick={onFilter}>
            {buttonText}
        </button>
    );
};

export default Filter;