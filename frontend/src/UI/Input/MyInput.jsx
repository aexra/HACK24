import React, { useState } from 'react';
import './Input.css';

const MyInput = ({ label, rightAddon, onChange, errorMessage }) => {
    const [isPasswordVisible, setIsPasswordVisible] = useState(false);

    const togglePasswordVisibility = () => {
        setIsPasswordVisible(!isPasswordVisible);
    };

    return (
        <div className="full_input">
            <div className="label_and_addon">
            <label className="input_label">{label}</label>
            {rightAddon && (
                <div className="right_addon" onClick={togglePasswordVisibility}>
                    {rightAddon}
                </div>
            )}
        </div>
            <div className="input_wrapper">
                <input
                    className="myinput"
                    type={rightAddon ? (isPasswordVisible ? "text" : "password") : "text"}
                    onChange={onChange}
                />
                {errorMessage && <p className="error-message">{errorMessage}</p>}
            </div>
        </div>
    );
};

export default MyInput;
