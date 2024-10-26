import './Input.css';

const Desc = ({ label, rightAddon, onToggle }) => {
    return (
        <div className="label_and_addon">
            <label className="input_label">{label}</label>
            {rightAddon && (
                <div className="right_addon" onClick={onToggle}>
                    {rightAddon}
                </div>
            )}
        </div>
    );
};

export default Desc;