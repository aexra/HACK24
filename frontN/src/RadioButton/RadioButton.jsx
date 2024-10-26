import React, { useState } from 'react';
import classes from './RadioButton.module.css'

export const RadioButton = ({ buttons }) => {
  const [activeButton, setActiveButton] = useState(null); 


  const handleClick = (buttonNumber) => {
    setActiveButton(buttonNumber);
  };
    return (
      <div>
        {buttons.map((button, index) => (
          <button 
          className={`${classes.RadioButton}`}
          key={button} 
          onClick={() => handleClick(index + 1)} 
          style={{
          backgroundColor: activeButton === index + 1 ? 'rgb(253, 238, 184)' : 'rgb(228, 228, 228)'
        }}>
          {button}
        </button>
        ))}
      </div>
    );
};

