import React from 'react';
import classes from './RegisterLanding.module.css'
import TextMain from '../../../UI/TextMain/TextMain';
import TextSub from '../../../UI/TextSub/TextSub';
import MyInput from '../../../UI/Input/MyInput';
import MyButton from '../../../UI/MyButton/MyButton';
import LinkButton from '../../../UI/LinkButton/LinkButton';
import AuthLanding from '../../../modules/AuthLanding/AuthLanding';

const RegisterLanding = () => {
    return (
        <AuthLanding>
            <div className= {classes.TextWrapper}>
                <TextMain className={classes.TextMain}>Присоединитесь к сообществу</TextMain>
            </div>
            <div className= {classes.TextWrapper}>
                <TextSub className={classes.TextMain}>Введите логин</TextSub>
            </div>
            <MyInput label={"Пароль"} className={classes.Input} errorMessage={""}/>
            <div className= {classes.TextWrapper}>
                <TextSub className={classes.TextMain}>Введите пароль</TextSub>
            </div>
            <MyInput hidable={true} label={"Пароль"} className={classes.Input} errorMessage={""}/>
            <MyButton>Зарегистрироваться</MyButton>
            <div className={classes.ButtonWrapper}>
                <LinkButton pageName={"/login"}>Уже есть аккаунт</LinkButton>
            </div>
        </AuthLanding>
    );
};

export default RegisterLanding;