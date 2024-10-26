import classes from './TextMain.module.css';

const TextMain = ({ children, className }) => {
    return (
        <span className={`${classes.TextMain} ${className}`}>
            {children}
        </span>
    );
};

export default TextMain;