# Components

* A [**component**](https://react.dev/learn/your-first-component) is the fundamental building block of React applications.
* Components are reusable, self-contained pieces of UI that encapsulate their structure, behavior, and styling.
* They represent parts of the user interface and can be composed together to build complex applications.

## Key Characteristics of Components

* **Encapsulation**: Each component manages its own state, props, and rendering logic.
* **Reusability**: Components can be used multiple times throughout the application.
* **Composition**: Components can contain other components, creating a component tree.
* **Props**: Components receive data from parent components through properties (props).
* **State**: Components can manage their own internal state for dynamic behavior.

## Types of Components

### 1. Functional Components (Modern Approach)

* Functional components are JavaScript functions that return JSX.
* They use React Hooks for state and lifecycle management.

```jsx
import React from 'react';

function HelloWorld() {
  return (
    <div>
      <h2>Welcome to Our React App!</h2>
      <p>Hello React World!</p>
    </div>
  );
}

export default HelloWorld;
```

>Warning: React components are regular JavaScript functions, but their names must start with a capital letter or they won't work!

### 2. Class Components (Legacy Approach)

* Class components extend React.Component and use lifecycle methods.
* While still supported, functional components with hooks are preferred.

```jsx
import React, { Component } from 'react';

class HelloWorldClass extends Component {
  render() {
    return (
      <div>
        <h2>Welcome to Our React App!</h2>
        <p>Hello React World!</p>
      </div>
    );
  }
}

export default HelloWorldClass;
```

## Creating Your First Functional Component

* Create a file called `HelloWorld.jsx` inside the `components` folder
* Paste the content below

  ```jsx
  import React from 'react';

  function HelloWorld() {
    return (
      <div>
        <h2>Welcome to Our React App!</h2>
        <p>Hello React World!</p>
      </div>
    );
  }

  export default HelloWorld;
  ```

* Import the new componet in the App.jsx
  * `import HelloWorld from './components/HelloWorld'`
* Add the new component to the App.jsx body
  * `<HelloWorld /> {/* render the new component without breaking existing layout */}`

* App.jsx after the changes

  ```jsx
  import { useState } from 'react'
  import './App.css'

  import HelloWorld from './components/HelloWorld'

  function App() {

    return (
      <>
        <HelloWorld />
      </>
    )
  }

  export default App
  ```

## Functional component content
- Component function
  - Must start with a capital letter (e.g. `HelloWorld`).
  - Accepts `props` (e.g. `function HelloWorld({ name }) { ... }`).
- Local state and hooks
  - `const [state, setState] = useState(initial)` and other hooks.
- Event handlers and helper functions
  - Defined inside the component so they can access props/state.
- Return (JSX)
  - The function returns JSX. This is the UI the component renders.
- Export
  - `export default HelloWorld` or named export.

### Props
Props (properties) are the read-only inputs a parent component passes to a child. They configure and customize a component's behavior and appearance without the child modifying them. Props are received as a single object argument (often destructured) and enable composition and reuse by decoupling data from implementation.

### useState

`useState` is a hook that gives a component its own local piece of data (state) and a setter to update it.

### useEffect

`useEffect` is the hook for running side effects after a component renders. Side effects are interactions with the outside world (network requests, subscriptions, timers, or manual DOM updates).

### Example:

* MonthsDropDown component

```css
/* Basic styles for the MonthsDropdown component */
select {
  padding: 6px 10px;
  font-size: 14px;
  border: 1px solid #ccc;
  border-radius: 4px;
  background: #fff;
  color: #111;
  appearance: none;
  /* remove native arrow in some browsers */
}

select:focus {
  outline: none;
  box-shadow: 0 0 0 3px rgba(21, 156, 228, 0.15);
  border-color: #159ce4;
}

/* optional small responsive tweak */
@media (max-width: 480px) {
  select {
    width: 100%;
    font-size: 16px;
  }
}
```

```jsx
import { useState } from 'react';
import './MonthsDropdown.css'; // <-- import the CSS file

function MonthsDropdown({ value = '', onChange }) {
  // Props:
  // - value: initial / controlled selected month (string)
  // - onChange: callback invoked when the user selects a month

  // Local constant array of month names.
  const months = [
    'January', 'February', 'March', 'April', 'May', 'June',
    'July', 'August', 'September', 'October', 'November', 'December'
  ];

  // Hooks:
  // useState -> local state for the currently selected month
  const [month, setMonth] = useState(value);

  // handleMonthChange uses the useState setter to update local state
  // and calls the onChange prop to notify the parent of the new selection
  function handleMonthChange(e) {
    const selectedMonth = e.target.value;
    setMonth(selectedMonth); // updates local state (useState)
    onChange(selectedMonth); // notifies parent (prop)
  }

  return (
    <select value={month} onChange={handleMonthChange} >
      <option value="">Select month</option>
      {
        months.map((m) => (
          <option key={m} value={m}>{m}</option>
        ))
      }
    </select>
  );
}

export default MonthsDropdown;
```

* App.jsx

```jsx
import { useState } from 'react' // Hook: useState for local component state
import './App.css'

import HelloWorld from './components/HelloWorld'
import MonthsDropdown from './components/MonthsDropdown' // Child component that uses props and hooks

function App() {

  // useState: parent keeps the currently selected month
  // - month: current value
  // - setMonth: setter passed down to child so it can notify the parent
  const [month1, setMonth1] = useState('')

  const [month2, setMonth2] = useState('')

  return (
    <>
      {/* <HelloWorld /> */}
      <label>
        Choose month 1:{' '}
        {
          /* Props:
            - value: current selected month (from parent state)
            - onChange: callback the child calls with the new month
          */
        }
        <MonthsDropdown value={month1} onChange={setMonth1} />
        <MonthsDropdown value={month2} onChange={setMonth2} />
      </label>

      <p>Selected months: {month1} - {month2}</p>
    </>
  )
}

export default App
```
