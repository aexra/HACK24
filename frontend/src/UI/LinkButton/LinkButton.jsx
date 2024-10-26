import React from 'react';
import { useNavigate } from 'react-router-dom';
import classes from './LinkButton.module.css'

const LinkButton = ({ pageName, children }) => {
    const navigate = useNavigate();

    const handleClick = () => {
        navigate(pageName);
    };

    return (
        <button onClick={handleClick} className={`${classes.LinkButton}`}>
            {children}
        </button>
    );
};

export default LinkButton;