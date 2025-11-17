# Spread props

The spread operator (`{...props}`) allows you to forward all props from a parent component to a child element or component in a single expression. This is especially useful when creating wrapper or passthrough components that need to support all the attributes of the underlying element without explicitly listing each one.

**Related Documentation:**

* [JavaScript Spread Syntax](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/Spread_syntax) - MDN documentation on spread operator
* [JSX Spread Attributes](https://react.dev/learn/passing-props-to-a-component#forwarding-props-with-the-jsx-spread-syntax) - React documentation on spreading props
* [Rest Parameters](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Functions/rest_parameters) - Related JavaScript feature for collecting props

**How It Works:**

The spread syntax takes all properties from an object and "spreads" them as individual props:

```jsx
// Without spread - explicitly passing each prop
<input 
  placeholder={props.placeholder}
  value={props.value}
  onChange={props.onChange}
  disabled={props.disabled}
  maxLength={props.maxLength}
  // ... and many more possible attributes
/>

// With spread - automatically forwards all props
<input {...props} />
```

**Combining attributes and spread props**

1. **Adding Fixed Props**: Combine spread with specific props
   ```jsx
   // className can be redefined from by props content
   <input className="my-class-name" {...props} />
   ```

2. **Overriding Props**: Props after spread override spread props
   ```jsx
   // className is always "my-class-name"
   <input {...props} className="my-class-name" />
   ```

**Example (component: `TextInput.jsx`)**:

```jsx
export default function TextInput(props) {
  return <input type="text" {...props} />;
}
```

**Usage Examples:**

```jsx
<TextInput placeholder="Your name" />

<TextInput value="Read only value" readOnly aria-label="readonly" disabled />

<TextInput
    value={textControlled}
    onChange={(e) => setTextControlled(e.target.value)}
    placeholder="Controlled input"
    aria-label="controlled-input"
    maxLength={50}
    style={{ width: 320, padding: 6 }}
  />

<TextInput
  placeholder="Email or username"
  inputMode="email"
  aria-required={true}
  className="form-input"
  maxLength={100}
  style={{ width: 320 }}
/>
```

##### Spreading Props with Different Parameters and Callbacks

When you want to spread props to a component but also pass different parameters or override specific props (like callbacks), you can combine the spread operator with explicit prop definitions. The key principle is **order matters**: props defined after `{...props}` will override any matching props from the spread.

**Pattern:**

```jsx
// Spread first, then override specific props
<ChildComponent {...props} specificProp={newValue} />

// This allows you to:
// 1. Forward all props from parent
// 2. Override or add specific props
// 3. Transform or wrap callbacks
```

**Example (component: `TextInputImproved.jsx`)**:

```jsx
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
```

**Usage Examples:**

```jsx
import { useState } from 'react';
import TextInputImproved from './components/TextInputImproved';

function App() {
  const [text, setText] = useState('');

  return (
    <div>
      <TextInputImproved
        value={text}
        onChange={(e) => setText(e.target.value)}
        placeholder="Enter your name"
        maxLength={50}
        className="my-input"
        disabled={false}
      />
      <p>Text: {text}</p>
    </div>
  );
}
```

**Key Points:**

* **Destructure specific props**: Extract the props you want to use explicitly (value, onChange, placeholder)
* **Use rest operator (`...props`)**: Collect remaining props to spread to the input element
* **Explicit props first**: Define important props explicitly for clarity and documentation
* **Spread remaining props**: Use `{...props}` to forward all other props to the underlying input
* **Flexibility**: Allows parent to pass any valid input attributes (maxLength, className, disabled, etc.)

**More Examples:**

```jsx
// Example 1: Add logging to any onClick
function LoggingButton({ onClick, children, ...props }) {
  const handleClick = (e) => {
    console.log('Button clicked:', children);
    if (onClick) onClick(e);
  };
  return <button {...props} onClick={handleClick}>{children}</button>;
}

// Example 2: Add validation before onChange
function ValidatedInput({ onChange, validate, ...props }) {
  const handleChange = (e) => {
    if (!validate || validate(e.target.value)) {
      if (onChange) onChange(e);
    }
  };
  return <input {...props} onChange={handleChange} />;
}

// Example 3: Merge className
function StyledInput({ className, ...props }) {
  const mergedClassName = `base-input ${className || ''}`.trim();
  return <input {...props} className={mergedClassName} />;
}
```
