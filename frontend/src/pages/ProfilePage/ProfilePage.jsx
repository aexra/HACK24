import ProfileLanding from "../../modules/ProfileLanding/ProfileLanding";
import TextWrapper from "../../components/TextWrapper/TextWrapper";
import classes from './ProfilePage.module.css';

const ProfilePage = () => {
    const leftData = [
        { desc: 'ФИО', value: 'Значение 1' },
        { desc: 'Должность', value: 'Значение 2' },
        { desc: 'Хобби', value: 'Значение 3' },
        { desc: 'Роль', value: 'Значение 4' },
        { desc: 'Значение', value: 'Значение 5' }
    ];

    const rightData = [
        { desc: 'Название', value: 'Вид', label: 'Описание' },
        { desc: 'Название', value: 'Вид', label: 'Описание' },
        { desc: 'Название', value: 'Вид', label: 'Описание' },
        { desc: 'Название', value: 'Вид', label: 'Описание' },
        { desc: 'Название', value: 'Вид', label: 'Описание' }
    ];

    const dataLeft = leftData.map((item, index) => ({ id: index + 1, ...item }));
    const dataRight = rightData.map((item, index) => ({ id: index + 1, ...item }));

    return (
        <>
            <ProfileLanding />
            <div className={classes.ProfileContainer}>
                <TextWrapper title="Личная информация" data={dataLeft} className={classes.ProfileWrapper} listClassName={classes.ProfileList} listItem={classes.ProfileItem} />
                <TextWrapper title="Выполненные челленджи" data={dataRight} className={classes.ProfileWrapper} listClassName={classes.ProfileList} listItem={classes.ProfileItem} />
            </div>
        </>
    );
}

export default ProfilePage;
