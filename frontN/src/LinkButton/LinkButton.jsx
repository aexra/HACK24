//import { BrowserRouter, Link, useNavigate } from "react-router-dom";

// LinkButton.js
import React from 'react';
import { useNavigate } from 'react-router-dom';
import classes from './LinkButton.module.css'

const LinkButton = ({ pageName, label, children }) => {
    const navigate = useNavigate();

    const handleClick = () => {
        navigate(pageName);
    };

    return (
        <button onClick={handleClick} className={`${classes.LinkButton}`}>
            {label}
            {children}
        </button>
    );
};

export default LinkButton;
