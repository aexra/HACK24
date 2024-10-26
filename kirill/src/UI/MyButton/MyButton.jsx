import './MyButton.css'

const MyButton = ({ text, onClick }) => {
    return (
        <button className="mbt" onClick={onClick}>
            {text}
        </button>
    )
}

export default MyButton;