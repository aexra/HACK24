import './MyButton.css'

const MyButton = ({ children, onClick }) => {
    return (
        <button className="mbt" onClick={onClick}>
            {children}
        </button>
    )
}

export default MyButton;