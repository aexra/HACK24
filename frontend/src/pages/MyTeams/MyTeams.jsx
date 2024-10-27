import React, { useState } from "react";
import TextWrapper from "../../components/TextWrapper/TextWrapper";
import classes from './MyTeams.module.css';
import MyButton from "../../UI/MyButton/MyButton";

const MyTeams = () => {

    const data = [
        { desc: 'Название', value: 'Тип 1', label: 'Текущий челлендж' },
        { desc: 'Название', value: 'Тип 2', label: 'Текущий челлендж' },
        { desc: 'Название', value: 'Тип 2', label: 'Текущий челлендж' },
        { desc: 'Название', value: 'Тип 2', label: 'Текущий челлендж' },
        { desc: 'Название', value: 'Тип 1', label: 'Текущий челлендж' },
        { desc: 'Название', value: 'Тип 1', label: 'Текущий челлендж' },
        { desc: 'Название', value: 'Тип 2', label: 'Текущий челлендж' },
        { desc: 'Название', value: 'Тип 1', label: 'Текущий челлендж' },
        { desc: 'Название', value: 'Тип 2', label: 'Текущий челлендж' }
    ];

    return (
        <div className={classes.MyTeamsContainer}>
            <TextWrapper
                title="Мои команды"
                data={data}
                className={classes.MyTeamsWrapper}
                listClassName={classes.MyTeamsList}
            />
            <MyButton className={classes.NewTeam} text={"СОЗДАТЬ КОМАНДУ"} />
        </div>
    );
};

export default MyTeams;
