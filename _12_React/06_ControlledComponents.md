# Controlled Components

Controlled components are form inputs whose values are controlled by React state. The component's state becomes the "single source of truth" for the input value.

**Key Concept:**
- Input value is bound to state via the `value` attribute (one-way: state → view)
- Input changes are captured via `onChange` handler which updates state (manual: view → state)
- This creates a controlled, predictable data flow

**Why use controlled components:**
- State is always in sync with the input
- Easy to validate and transform data in real-time
- Can programmatically set/clear values
- Single source of truth (the state)

**Basic Pattern:**

```jsx
const [myAttribute, setAttribute] = useState('');

<input 
  value={myAttribute} // Bind to state
  onChange={(e) => setAttribute(e.target.value)} // Update state on change
/>
```

**React Documentation:**
- [Forms - Controlled Components](https://react.dev/reference/react-dom/components/input#controlling-an-input-with-a-state-variable)
- [Managing State - Reacting to Input with State](https://react.dev/learn/reacting-to-input-with-state)
- [API Reference - Common components (input, textarea, select)](https://react.dev/reference/react-dom/components/common)

**Example** - ControlledForm.jsx

```jsx
import { useState } from 'react';
import './ControlledForm.css';

// Define initial state as a constant to reuse for initialization and reset
const INITIAL_FORM_STATE = {
  name: '',
  email: '',
  age: 0,
  country: '',
  subscribe: false
};

export default function ControlledForm() {
  // Initialize state with all form fields using useState hook
  // formData holds the current values, setFormData updates them
  const [formData, setFormData] = useState(INITIAL_FORM_STATE);

  const handleNameChange = (e) => {

    // NOTE: Inspect e
    debugger;
    console.log(e.target.name);
    console.log(e.target.value)

    // e = event object containing information about the change event
    // e.target = the input element that triggered the event
    // e.target.value = the current value of the input field

    // setFormData updates the state
    // prev = previous state object (React provides this automatically)
    // { ...prev, name: e.target.value } creates a new object by:
    //   1. Spreading (...) all properties from previous state
    //   2. Overwriting the 'name' property with the new value
    // This keeps the state immutable (creates new object instead of modifying existing)
    // https://react.dev/reference/react/useState#updating-objects-and-arrays-in-state
    // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/Spread_syntax
    setFormData(prev => ({ ...prev, name: e.target.value }));
  };

  const handleEmailChange = (e) => {
    setFormData(prev => ({ ...prev, email: e.target.value }));
  };

  const handleAgeChange = (e) => {
    setFormData(prev => ({ ...prev, age: parseInt(e.target.value) || 0 }));
  };

  const handleCountryChange = (e) => {
    setFormData(prev => ({ ...prev, country: e.target.value }));
  };

  const handleSubscribeChange = () => {
    setFormData(prev => ({ ...prev, subscribe: !prev.subscribe }));
  };

  // Handle form submission
  const handleSubmit = (e) => {
    // Prevent default form submission behavior (page reload)
    e.preventDefault();

    // Log the form data (in real apps, you'd send this to a server)
    console.log('Form submitted:', formData);
    alert(JSON.stringify(formData, null, 2));
  };

  // Reset form to initial empty state
  const handleReset = () => {
    setFormData(INITIAL_FORM_STATE);
  };

  return (
    <form onSubmit={handleSubmit} className="controlled-form">
      <h3>Controlled Form Demo</h3>

      <input
        type="text"
        name="name"
        value={formData.name}
        onChange={handleNameChange}
        placeholder="Name"
        required
      />

      <input
        type="email"
        name="email"
        value={formData.email}
        onChange={handleEmailChange}
        placeholder="Email"
        required
      />

      <input
        type="number"
        name="age"
        value={formData.age}
        onChange={handleAgeChange}
        placeholder="Age"
        min="0"
      />

      <select name="country" value={formData.country} onChange={handleCountryChange}>
        <option value="">Select Country</option>
        <option value="BR">Brazil</option>
        <option value="CA">Canada</option>
        <option value="US">USA</option>
      </select>

      <label>
        <input
          type="checkbox"
          name="subscribe"
          checked={formData.subscribe}
          onChange={handleSubscribeChange}
        />
        {' '}Subscribe to newsletter
      </label>

      <div className="button-group">
        <button type="submit">Submit</button>
        <button type="button" onClick={handleReset}>Reset</button>
      </div>

      <div className="form-preview">
        <label>
          <strong>Current Form State:</strong>
        </label>
        <pre>{JSON.stringify(formData, null, 2)}</pre>
      </div>
    </form>
  );
}
```
