import React from 'react';
import classes from './AchievementListUnit.module.css'
import CompletedStatusButton from '../StatusButtons/CompletedStatusButton/CompletedStatusButton';
import RefusedStatusButton from '../StatusButtons/RefusedStatusButton/RefusedStatusButton';
import UnknownStatusButton from '../StatusButtons/UnknownStatusButton/UnknownStatusButton';
import CompleteButton from '../CompleteButton/CompleteButton';

const AchievementListUnit = ({challengeName, challengeType, challengeDescription, challengeStatus}) => {
    return (
        <div className={classes.AchievementListUnit}>
            <div className={classes.UnitPart1}>
                <div className={classes.ChallengeName}>{challengeName}</div>
                <div className={classes.ChallengeType}>{challengeType}</div>
                <div className={classes.ChallengeDescription}>{challengeDescription}</div>
            </div>
            <div className={classes.UnitPart2}>
                {
                    challengeStatus == "Completed" ? <CompletedStatusButton/> : 
                    challengeStatus == "Refused" ? <RefusedStatusButton/> :
                    challengeStatus == "Unknown" ? <UnknownStatusButton/> :
                    <CompleteButton/>
                }
            </div>
        </div>
    );
};

export default AchievementListUnit;