// React passes all props as a single object argument
// Common convention is to name it 'props'
export default function TextInput(props) {
  // The spread operator {...props} forwards all received props to the input element
  // This allows the parent to pass any valid input attributes: placeholder, value, onChange, etc.
  return <input type="text" {...props} />;
}