import React from 'react';
import AchievementList from '../AchievementList/AchievementList';
import classes from './HomePage.module.css'

const HomePage = () => {
    return (
        <div className={classes.Page}>
            <AchievementList className={classes.AchievementList}/>
        </div>
    );
};

export default HomePage;        