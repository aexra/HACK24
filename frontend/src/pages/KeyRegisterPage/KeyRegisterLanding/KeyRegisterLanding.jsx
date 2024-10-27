import React, { useEffect, useState } from 'react';
import classes from './KeyRegisterLanding.module.css'
import TextMain from '../../../UI/TextMain/TextMain';
import TextSub from '../../../UI/TextSub/TextSub';
import MyInput from '../../../UI/Input/MyInput';
import MyButton from '../../../UI/MyButton/MyButton';
import LinkButton from '../../../UI/LinkButton/LinkButton';
import AuthLanding from '../../../modules/AuthLanding/AuthLanding';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const KeyRegisterLanding = (props) => {
    useEffect(() => {
        axios.defaults.baseURL = 'https://localhost:7002';
    }, [])

    const [key, setKey] = useState("");
    const [keyErrorMessage, setKeyErrorMessage] = useState("");

    const navigate = useNavigate();

    const checkKey = () => {
        axios.post(`api/key/${key}`).then(() => navigate('/register')).catch(() => setKeyErrorMessage("Неверный ключ"));
    }

    return (
        <AuthLanding>
            <div className= {classes.TextWrapper}>
                <TextMain className={classes.TextMain}>Присоединитесь к сообществу</TextMain>
            </div>
            <div className= {classes.TextWrapper}>
                <TextSub className={classes.TextMain}>Введите ключ аунтефикации сотрудников</TextSub>
            </div>
            <MyInput hidable={true} label={"Ключ"} className={classes.Input} errorMessage={keyErrorMessage} value={key} onChange={setKey}/>
            <MyButton onClick={checkKey}>Проверить ключ</MyButton>
            <div className={classes.ButtonWrapper}>
                <LinkButton pageName={"/login"}>Уже есть аккаунт</LinkButton>
            </div>
        </AuthLanding>
    );
};

export default KeyRegisterLanding;