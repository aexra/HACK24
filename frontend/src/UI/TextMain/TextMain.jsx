import classes from './TextMain.module.css';

const TextMain = ({ children }) => {
    return (
        <span className={classes.TextMain}>
            {children}
        </span>
    );
};

export default TextMain;