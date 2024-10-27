import React, { useState } from "react";
import TextWrapper from "../../components/TextWrapper/TextWrapper";
import classes from './Teams.module.css';

const Teams = () => {
    const [filterValue, setFilterValue] = useState(null);

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

    const handleFilter = () => {
        setFilterValue(prevFilter => {
            if (prevFilter === null) return 'Тип 1';
            if (prevFilter === 'Тип 1') return 'Тип 2';
            return null;
        });
    };

    const buttonText = filterValue === 'Тип 1' ? 'по Типу 1' :
        filterValue === 'Тип 2' ? 'по Типу 2' :
            'Все команды';

    return (
        <div className={classes.TeamsContainer}>
            <TextWrapper
                title="Все команды"
                data={data}
                filterValue={filterValue}
                onFilter={handleFilter}
                buttonText={buttonText}
                showButton={true}
                className={classes.TeamsWrapper}
                listClassName={classes.TeamsList}
                listItem={classes.TeamsItem}
            />
        </div>
    );
};

export default Teams;
