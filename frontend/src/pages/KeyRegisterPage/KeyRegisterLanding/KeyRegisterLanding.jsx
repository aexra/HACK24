import React from 'react';
import classes from './KeyRegisterLanding.module.css'
import TextMain from '../../../UI/TextMain/TextMain';
import TextSub from '../../../UI/TextSub/TextSub';
import MyInput from '../../../UI/Input/MyInput';
import MyButton from '../../../UI/MyButton/MyButton';
import LinkButton from '../../../UI/LinkButton/LinkButton';
import AuthLanding from '../../../modules/AuthLanding/AuthLanding';

const KeyRegisterLanding = () => {
    return (
        <AuthLanding>
            <div className= {classes.TextWrapper}>
                <TextMain className={classes.TextMain}>Присоединитесь к сообществу</TextMain>
            </div>
            <div className= {classes.TextWrapper}>
                <TextSub className={classes.TextMain}>Введите ключ аунтефикации сотрудников</TextSub>
            </div>
            <MyInput hidable={true} label={"Ключ"} className={classes.Input} errorMessage={"abobas"}/>
            <MyButton>Проверить ключ</MyButton>
            <div className={classes.ButtonWrapper}>
                <LinkButton pageName={"/login"}>Уже есть аккаунт</LinkButton>
            </div>
        </AuthLanding>
    );
};

export default KeyRegisterLanding;