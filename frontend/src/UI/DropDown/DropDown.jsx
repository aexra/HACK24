import classes from './DropDown.module.css';

const Dropdown = ({ items, isHoverable = true }) => {
    return (
        <div className={classes.Dropdown}>
            {items.map((item, index) => (
                <div
                    key={index}
                    className={`${classes.DropdownItem} ${isHoverable ? classes.Hoverable : ''}`}
                >
                    {item.label}
                </div>
            ))}
        </div>
    );
};

export default Dropdown;
