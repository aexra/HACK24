import React from 'react';
import Landing from '../../components/Landing/Landing';
import classes from './ProfileLanding.module.css';
import ImgContainer from '../../UI/ImgContainer/ImgContainer';
import Avatar from '../../resources/avatar_m.png'
import TextMain from '../../UI/TextMain/TextMain';
import Tg from '../../resources/tg-icon.svg'
import Vk from '../../resources/vk-icon.svg'

const ProfileLanding = () => {
    return (
        <Landing className={classes.ProfileLanding}>
            <div className={classes.ProfileInfo}>
                <ImgContainer src={Avatar} alt="Profile Image" />
                <div className={classes.TextInfo}>
                    <TextMain> ФИО участника</TextMain>
                    <div className={classes.SvgLinks}>
                        <a href="https://t.me/egocucumber" target="_blank" rel="noopener noreferrer">
                            <img src={Tg} alt='tg' className={classes.Svg} />
                        </a>
                        <a href="https://vk.com/egocucumber" target="_blank" rel="noopener noreferrer">
                            <img src={Vk} alt='vk' className={classes.Svg} />
                        </a>
                    </div>
                </div>
            </div>
        </Landing>
    );
};

export default ProfileLanding;

