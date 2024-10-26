import { useState } from 'react';
import './App.css';
import React from 'react';
import { RadioButton } from './RadioButton/RadioButton';

const App = () => {
    const buttonsArray = ['button1', 'button2', 'button3', 'говно'];
    return (
      <RadioButton buttons={buttonsArray}></RadioButton>
    );
};

export default App;