import classes from './TextSub.module.css';

const TextSub = ({ children }) => {
    return (
        <span className={classes.TextSub}>
            {children}
        </span>
    );
};

export default TextSub;