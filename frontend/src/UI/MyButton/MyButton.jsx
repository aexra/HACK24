import classes from './MyButton.module.css'

const MyButton = ({ text, onClick, className }) => {
    return (
        <button className={`${classes.mbt} ${className}`} onClick={onClick}>
            {text}
        </button>
    )
}

export default MyButton;