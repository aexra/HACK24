import React from 'react';
import classes from './ImgContainer.module.css';

const ImgContainer = ({ src, alt }) => {
    return (
        <div className={classes.ImgContainer}>
            <img src={src} alt={alt} className={classes.Image} />
        </div>
    );
};

export default ImgContainer;
