import React from 'react';
import List from '../../components/List/List';
import classes from "./CardList.module.css"

const CardList = ({children, className}) => {
    return (
        <List className={`${classes.List} ${className}`}>{children}</List>
    );
};

export default CardList;