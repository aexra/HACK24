import classes from './List.module.css'

<<<<<<< HEAD
const List = ({ children, className }) => {
=======
const List = ({children, className}) => {
>>>>>>> 0b9ea7315089eac99aa2efc36c040a1cb1bfa77c
    return (
        <div className={`${classes.List} ${className}`}>
            {children}
        </div>
    );
};

export default List;