export default function TextInputImproved({ value, onChange, placeholder, ...props }) {
  return (
    <input
      type="text"
      value={value}
      onChange={onChange}
      placeholder={placeholder}
      {...props}
    />
  );
}
