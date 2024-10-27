import React from 'react'
import classes from './ButtonNewGoal.module.css'

export const ButtonNewGoal = ({textButton}) => {
  return (
    <button className={`${classes.ButtonNewGoal}`}>
        {textButton}
    </button>
  )
}