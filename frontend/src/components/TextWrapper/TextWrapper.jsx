import React from 'react';
import TextMain from '../../UI/TextMain/TextMain';
import classes from './TextWrapper.module.css';
import Filter from '../../UI/Filter/Filter';

const TextWrapper = ({ title, data, filterValue, onFilter, buttonText, showButton = false, className, listClassName }) => {
    return (
        <div className={`${classes.TextWrapper} ${className}`}>
            <div className={classes.Header}>
                <TextMain className={classes.TextMain}>{title}</TextMain>
                {showButton && <Filter onFilter={onFilter} buttonText={buttonText} />}
            </div>
            <ul className={`${classes.TextWrapperList} ${listClassName}`}>
                {data.map(item => (
                    (!filterValue || item.value === filterValue) && (
                        <li className={classes.ListItem} key={item.id}>
                            {item.desc} {item.value} {item.label}
                        </li>
                    )
                ))}
            </ul>
        </div>
    );
};

export default TextWrapper;