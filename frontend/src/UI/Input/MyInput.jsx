import React, { useState } from 'react';
import './Input.css';
import Desc from './Desc';
import ErrorMessage from '../ErrorMessage/ErrorMessage';

const MyInput = ({ label, rightAddon, onChange, errorMessage }) => {
    const [isPasswordVisible, setIsPasswordVisible] = useState(false);

    const togglePasswordVisibility = () => {
        setIsPasswordVisible(!isPasswordVisible);
    };

    return (
        <div className="full_input">
            <Desc
                label={label}
                rightAddon={rightAddon}
                onToggle={togglePasswordVisibility}
            />
            <div className="input_wrapper">
                <input
                    className="myinput"
                    type={rightAddon ? (isPasswordVisible ? "text" : "password") : "text"}
                    onChange={onChange}
                />
                {errorMessage && <ErrorMessage message={errorMessage} />}
            </div>
        </div>
    );
};

export default MyInput;
