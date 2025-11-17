# 9. Event Handling

Attach handlers (onClick, onChange) and use hooks like `useState` to respond to user actions.

* **Overview:**
  * **Event names use camelCase**: `onClick`, `onChange`, `onSubmit`, `onMouseEnter`, etc. (not lowercase like HTML)
  * **Pass function references**: `onClick={handleClick}` (not `onClick={handleClick()}`
  * **Inline arrow functions**: `onClick={() => doSomething(arg)}` when you need to pass arguments or call multiple functions
  * **Event object**: React passes a event object to handlers: `onChange={(e) => setText(e.target.value)}`

* **Common Events:**
- `onClick` - Mouse clicks
- `onChange` - Input value changes
- `onSubmit` - Form submissions
- `onKeyDown/onKeyUp/onKeyPress` - Keyboard events
- `onMouseEnter/onMouseLeave` - Mouse hover
- `onFocus/onBlur` - Focus events

Example (component: `EventHandling.jsx`):

```jsx
import React, { useState } from 'react';

export default function EventHandling() {

  const [counter, setCounter] = useState(0);
  const [text, setText] = useState('');

  function AlertCounter() {
    alert(`Counter: ${counter}`);
  }

  function Increment() {
    setCounter(counter + 1);
  }

  function Decrement() {
    setCounter(counter - 1);
  }

  function GetWordCount(str) {
    return str.trim() === '' ? 0 : str.trim().split(/\s+/).length;
  }

  function GetCharCount(str) {
    return str.length;
  }

  function ClearText() {
    setText("");
  }

  function AlertText(textToAlert = text) {
    debugger;
    alert(textToAlert)
  }

  return (
    <div>
      <button onClick={Increment}>Increment</button>
      <button onClick={() => Decrement()}>Decrement</button>
      <span>Count: {counter}</span>
      <button onClick={AlertCounter}>Alert Counter</button>
      <br></br>
      <br></br>
      <div>
        <input
          type="text"
          value={text}
          onChange={(e) => setText(e.target.value)}
          placeholder="Type something..."
        />
        <span>Words: {GetWordCount(text)} | Characters: {GetCharCount(text)}</span>
        <br></br>
        <button onClick={ClearText}>Clear</button>
        <button onClick={() => AlertText(text)}>Alert Text 1</button>
        <button onClick={() => AlertText()}>Alert Text 2</button>
      </div>
    </div>
  );
}
```
