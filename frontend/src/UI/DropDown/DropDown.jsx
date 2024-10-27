import classes from './DropDown.module.css';
import { Link } from 'react-router-dom';

const Dropdown = ({ items, isHoverable = true }) => {
    return (
        <div className={classes.Dropdown}>
            {items.map((item, index) => (
                <div
                    key={index}
                    className={`${classes.DropdownItem} ${isHoverable ? classes.Hoverable : ''}`}
                >
                    {item.link ? (
                        <Link to={item.link} className={classes.Link}>
                            {item.label}
                        </Link>
                    ) : (
                        item.label
                    )}
                </div>
            ))}
        </div>
    );
};

export default Dropdown;