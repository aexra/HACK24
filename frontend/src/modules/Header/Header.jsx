import React, { useState } from 'react';
import classes from "./Header.module.css";
import { Link, Outlet } from 'react-router-dom';
import Logo from '../../resources/Logo.png';
import ProfileIcon from '../../resources/Avatar.png';
import NotificationsIcon from '../../resources/Notification.svg';
import Dropdown from '../../UI/DropDown/DropDown';

const Header = () => {
    const [isProfileOpen, setProfileOpen] = useState(false);
    const [isNotificationsOpen, setNotificationsOpen] = useState(false);

    const handleProfileMouseEnter = () => {
        setProfileOpen(true);
        if (isNotificationsOpen) setNotificationsOpen(false);
    };

    const handleProfileMouseLeave = () => {
        setProfileOpen(false);
    };

    const handleNotificationsMouseEnter = () => {
        setNotificationsOpen(true);
        if (isProfileOpen) setProfileOpen(false);
    };

    const handleNotificationsMouseLeave = () => {
        setNotificationsOpen(false);
    };

    const profileItems = [
        { label: 'Профиль', link: '/profile' },
        { label: 'Мои команды', link: '/my-teams' },
    ];

    const notificationItems = [
        { label: 'sdjvhljsdhljdbhsd sdhhdghkldgss dgsbhsdgdkshhsd ghdghldsh ldsglhkjgdsl' },
        { label: 'Уведомление 2' },
    ];

    return (
        <>
            <div className={classes.Header}>
                <Link to="/" className={classes.LogoLink}>
                    <img src={Logo} className={classes.Logo} alt='Логотип' />
                </Link>
                <nav className={classes.Nav}>
                    <Link to="/challenges" className={classes.NavLink}>Доступные челленджи</Link>
                    <Link to="/activity-log" className={classes.NavLink}>Дневник активностей</Link>
                    <Link to="/leaderboard" className={classes.NavLink}>Таблица лидеров</Link>
                    <Link to="/teams" className={classes.NavLink}>Все команды</Link>
                </nav>
                <div className={classes.Icons}>
                    <div
                        className={classes.ProfileIcon}
                        onMouseEnter={handleProfileMouseEnter}
                        onMouseLeave={handleProfileMouseLeave}
                    >
                        <img src={ProfileIcon} className={classes.Icon} alt='Профиль' />
                        {isProfileOpen && <Dropdown items={profileItems} isHoverable={true} link />}
                    </div>
                    <div
                        className={classes.NotificationsIcon}
                        onMouseEnter={handleNotificationsMouseEnter}
                        onMouseLeave={handleNotificationsMouseLeave}
                    >
                        <img src={NotificationsIcon} className={classes.Icon} alt='Уведомления' />
                        {isNotificationsOpen && <Dropdown items={notificationItems} isHoverable={false} link />}
                    </div>
                </div>
            </div>
            <Outlet />
        </>
    );
};

export default Header;
