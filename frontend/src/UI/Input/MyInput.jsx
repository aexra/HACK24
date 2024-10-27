import React, { useState } from 'react';
import { ReactComponent as HideIcon } from '../../resources/HideIcon.svg';
import classes from './MyInput.module.css'

const MyInput = ({ label, hidable, onChange, errorMessage, className }) => {
    const [isPasswordVisible, setIsPasswordVisible] = useState(false);

    const togglePasswordVisibility = () => {
        setIsPasswordVisible(!isPasswordVisible);
    };

    return (
        <div className={`${classes.FullInput} ${className}`}>
                <div className={classes.LabelAndAddon}>
                <label className={classes.InputLabel}>{label}</label>
                {hidable && (
                    <div className={classes.RightAddon} onClick={togglePasswordVisibility}>
                        <HideIcon/>
                    </div>
                )}
            </div>
                <div className={classes.InputLabel}>
                    <input
                        className={classes.MyInput}
                        type={hidable ? (isPasswordVisible ? "text" : "password") : "text"}
                        onChange={onChange}
                    />
                    {errorMessage && <p className={classes.ErrorMessage}>{errorMessage}</p>}
                </div>
        </div>
    );
};

export default MyInput;
