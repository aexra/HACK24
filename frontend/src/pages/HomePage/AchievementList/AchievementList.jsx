import React from 'react';
import TextMain from '../../../UI/TextMain/TextMain';
import CardList from '../../../modules/CardList/CardList';
import AchievementListUnit from '../AchievementListUnit/AchievementListUnit';
import classes from './AchievementList.module.css'

const AchievementList = ({className}) => {
    const achievements = [
                            {challengeName: "Aboba", challengeType: "Bebebe", challengeDescription: "Abobabebebe", challengeStatus: "One"}, 
                            {challengeName: "Aboba2", challengeType:"Bebebe2", challengeDescription:"Abobabebebe",  challengeStatus: "Two"}
                        ]
    return (
        <div className={className}>
            <TextMain>Мои челленджи</TextMain>
            <CardList className={classes.AchievementList}>
                {
                    achievements.map(achievement => 
                        <AchievementListUnit 
                            challengeName={achievement.challengeName}
                            challengeType={achievement.challengeType}
                            challengeDescription={achievement.challengeDescription}
                            challengeStatus={achievement.challengeStatus}
                        />
                    )
                }
            </CardList>
        </div>
    );
};

export default AchievementList;