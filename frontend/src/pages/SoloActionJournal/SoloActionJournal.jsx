import React from 'react'
import Header from '../../modules/Header/Header'
import classes from './SoloActionJournal.module.css'
import { useState } from 'react'
import { ButtonNewGoal } from '../../UI/ButtonNewGoal/ButtonNewGoal'
import TextWrapper from '../../components/TextWrapper/TextWrapper'

export const SoloActionJournal = () => {
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
      { desc: 'Название', value: 'Тип 2', label: 'Текущий челлендж' },
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
          'Все активности';
  return (
    <div>
      <div>
          <Header className={`${classes.Header}`}></Header>
      </div>
      <div>
      <div className={classes.Actions}>
            <TextWrapper
                title="Активность"
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
      </div>
      <div>
        <ButtonNewGoal textButton={"Новая цель"}></ButtonNewGoal>
      </div>
    </div>
  )
}