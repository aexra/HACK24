import React from 'react';
import classes from './LoginLanding.module.css'
import Landing from '../../../components/Landing/Landing';
import TextMain from '../../../UI/TextMain/TextMain';

const LoginLayout = () => {
    return (
        <Landing className = {classes.Landing}>
            <TextMain>Присоединитесь к сообществу</TextMain>
        </Landing>
    );
};

export default LoginLayout;