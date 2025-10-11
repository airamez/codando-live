# React

* React is a powerful, open-source JavaScript library developed by Meta, designed for building dynamic, interactive user interfaces and single-page applications (SPAs).
* Built with a component-based architecture, React promotes modularity, reusability, and maintainability through encapsulated components that manage their own state.
* React 19, released in April 2024, introduces revolutionary features like Server Components, Actions, and enhanced concurrent rendering, making it the most powerful version yet for modern web development.

## Key Features

* **Component-Based Architecture**: Build encapsulated, reusable UI components that manage their own state and compose to create complex interfaces.
* **Virtual DOM**: Uses a virtual representation of the DOM for efficient updates and rendering, improving performance.
  * **What is the Virtual DOM?**: A JavaScript representation of the real DOM kept in memory. It's a lightweight copy of the actual DOM elements stored as JavaScript objects.
  * **How it Works**: When state changes occur, React creates a new virtual DOM tree representing the new state, then compares (diffs) it with the previous virtual DOM tree to identify what actually changed.
  * **Reconciliation Process**: React's diffing algorithm efficiently determines the minimum number of changes needed to update the real DOM, then applies only those specific changes.
  * **Performance Benefits**: Direct DOM manipulation is expensive because it triggers layout recalculations and repaints. The Virtual DOM minimizes these operations by batching updates and only touching the real DOM when necessary.
  * **Example**: If you update one item in a list of 1000 items, React will only update that single DOM element rather than re-rendering the entire list.
  * **Memory Trade-off**: Uses more memory to store the virtual representation, but this is typically insignificant compared to the performance gains from reduced DOM operations.
* **JSX Syntax**: Write HTML-like syntax within JavaScript, making component templates intuitive and readable.
* **Unidirectional Data Flow**: Data flows down from parent to child components, making applications predictable and easier to debug.
* **Hooks**: Modern functional approach to state management and lifecycle methods without class components.
* **Server Components**: Run components on the server for better performance and SEO.
* **Actions**: Built-in support for handling form submissions and data mutations.
* **Enhanced Concurrent Features**: Improved Suspense, automatic batching, and better error boundaries.
* **React Developer Tools**: Browser extensions for debugging and inspecting React component trees.
* **Rich Ecosystem**: Vast collection of third-party libraries, tools, and community resources.
* **Cross-Platform Development**: Build web apps, mobile apps (React Native), and desktop apps (Electron) with shared knowledge.

## Why Use React?

* **Developer Experience**: Excellent tooling, hot reloading, and debugging capabilities enhance productivity.
* **Performance**: Virtual DOM, Server Components, and enhanced concurrent features ensure fast, responsive user interfaces.
* **Flexibility**: Library approach allows choosing the best tools for routing, state management, and other concerns.
* **Community**: Large, active community with extensive documentation, tutorials, and third-party packages.
* **Industry Adoption**: Used by major companies like Meta, Netflix, Airbnb, and thousands of others.
* **Learning Path**: Skills transfer well to React Native for mobile development.

## Resources

* **Official React Website**: Comprehensive documentation, tutorials, and community resources.
  * (<https://react.dev>)
* **Official Documentation**: Detailed guides, API references, and best practices.
  * (<https://react.dev/learn>)
* **React Blog**: Latest news, release notes, and updates.
  * (<https://react.dev/blog>)
* **Interactive Tutorial**: Learn React step-by-step with hands-on examples.
  * (<https://react.dev/learn/tutorial-tic-tac-toe>)
  * Highly recommended

## Getting Started

* Install Node.js (version 18 or higher required for React 19)
  * React 19 requires Node.js 18+ for development tooling and package management.
  * Download from: <https://nodejs.org>

* Create a new React project using Create React App (CRA):
  * CRA is the traditional, official tool from Facebook/Meta for bootstrapping React applications.

  ```bash
  npx create-react-app my-react-app
  cd my-react-app
  npm start
  ```

* Alternative: Create a new React project with Vite (faster build tool):
  * Vite is a modern, fast build tool created by Evan You (Vue.js creator)

  ```bash
  npm create vite@latest my-react-app -- --template react
  cd my-react-app
  npm install
  npm run dev
  ```

### Key Differences Summary

| Feature | Create React App | Vite |
|---------|------------------|------|
| **Speed** | Slower | Much faster |
| **Bundle Size** | Larger | Smaller |
| **Configuration** | Limited (requires ejecting) | Highly flexible |
| **TypeScript** | Additional setup needed | Built-in support |
| **Hot Reload** | Slower | Near-instant |
| **Modern Standards** | Older approach | Modern, cutting-edge |
| **Learning Curve** | Easier for beginners | Slightly steeper but worth it |
| **Maintenance** | Reduced active development | Active development |

* For new projects in 2024/2025, Vite is generally the better choice because:
  * Significantly faster development experience
  * Better performance and smaller bundles
  * More modern tooling and better TypeScript support
  * Active development and growing ecosystem
  * Easy migration path if needed

>Class Note: Demo creating a new app using both options and exploring the file structure.

## File Structure

### Create React App Structure

| **Location**              | **File/Directory**    | **Description**                                                                 |
| ------------------------- | --------------------- | ------------------------------------------------------------------------------- |
| `/my-react-app/`          | `package.json`        | Project metadata, dependencies, and npm scripts configuration.                  |
| `/my-react-app/`          | `package-lock.json`   | Locks exact versions of dependencies for consistent installs.                   |
| `/my-react-app/`          | `README.md`           | Project documentation with setup and usage instructions.                       |
| `/my-react-app/`          | `.gitignore`          | Specifies files and directories Git should ignore.                             |
| `/my-react-app/`          | `node_modules/`       | Contains all npm dependencies installed for the project.                        |
| `/my-react-app/public/`   | `public/`             | Static assets served directly by the web server.                               |
| `/my-react-app/public/`   | `index.html`          | Main HTML file with root div where React app mounts.                          |
| `/my-react-app/public/`   | `favicon.ico`         | Website icon displayed in browser tabs.                                        |
| `/my-react-app/src/`      | `src/`                | Source code directory containing all React components and assets.               |
| `/my-react-app/src/`      | `index.js`            | Entry point that renders the App component into the DOM.                       |
| `/my-react-app/src/`      | `App.js`              | Main application component containing the app's root structure.                 |
| `/my-react-app/src/`      | `App.css`             | Styles for the main App component.                                              |
| `/my-react-app/src/`      | `index.css`           | Global styles applied to the entire application.                                |
| `/my-react-app/src/`      | `App.test.js`         | Unit tests for the App component using Jest testing framework.                  |

### Vite Structure

| **Location**              | **File/Directory**    | **Description**                                                                 |
| ------------------------- | --------------------- | ------------------------------------------------------------------------------- |
| `/my-react-app/`          | `package.json`        | Project metadata, dependencies, and npm scripts configuration.                  |
| `/my-react-app/`          | `package-lock.json`   | Locks exact versions of dependencies for consistent installs.                   |
| `/my-react-app/`          | `vite.config.js`      | Vite configuration file for build settings and plugins.                        |
| `/my-react-app/`          | `README.md`           | Project documentation with setup and usage instructions.                       |
| `/my-react-app/`          | `.gitignore`          | Specifies files and directories Git should ignore.                             |
| `/my-react-app/`          | `node_modules/`       | Contains all npm dependencies installed for the project.                        |
| `/my-react-app/`          | `index.html`          | Main HTML file (in root, not public/) with root div where React app mounts.   |
| `/my-react-app/public/`   | `public/`             | Static assets served directly by the web server.                               |
| `/my-react-app/public/`   | `vite.svg`            | Vite logo used in the default template.                                        |
| `/my-react-app/src/`      | `src/`                | Source code directory containing all React components and assets.               |
| `/my-react-app/src/`      | `main.jsx`            | Entry point that renders the App component into the DOM (JSX extension).       |
| `/my-react-app/src/`      | `App.jsx`             | Main application component containing the app's root structure (JSX extension). |
| `/my-react-app/src/`      | `App.css`             | Styles for the main App component.                                              |
| `/my-react-app/src/`      | `index.css`           | Global styles applied to the entire application.                                |
| `/my-react-app/src/assets/` | `assets/`           | Directory for static assets like images, fonts, etc.                           |
| `/my-react-app/src/assets/` | `react.svg`         | React logo used in the default template.                                       |

### Key Structural Differences

* **HTML Location**: CRA keeps `index.html` in `public/`, Vite keeps it in the root directory
* **File Extensions**: Vite uses `.jsx` extensions by default, CRA uses `.js`
* **Entry Point**: CRA uses `index.js`, Vite uses `main.jsx`
* **Configuration**: CRA has no config file (requires ejecting), Vite has `vite.config.js`
* **Assets**: Vite includes a dedicated `src/assets/` directory

## Our Demo Application

```bash
cd [YOUR_FOLDER]/codando-live/_12_React/

# Creating a react app called react-demo-app
npm create vite@latest react-demo-app -- --template react

# Running the app in development mode
cd react-demo-app
npm run dev
```

### Structural elements

| File | Description |
| --- | --- |
| `index.html` | The static HTML shell. Vite serves this and the `<script type="module" src="/src/main.jsx">` loads your app. Contains the DOM mount node (e.g. `<div id="root"></div>`). |
| `src/main.jsx` | Entry module. Imports React, ReactDOM and your root component, then mounts it into the DOM node from `index.html`. |
| `src/App.jsx` | Root React component (default export). Composes the app UI and child components. |

## Components

* A [**component**](https://react.dev/learn/your-first-component) is the fundamental building block of React applications.
* Components are reusable, self-contained pieces of UI that encapsulate their structure, behavior, and styling.
* They represent parts of the user interface and can be composed together to build complex applications.

### Key Characteristics of Components

* **Encapsulation**: Each component manages its own state, props, and rendering logic.
* **Reusability**: Components can be used multiple times throughout the application.
* **Composition**: Components can contain other components, creating a component tree.
* **Props**: Components receive data from parent components through properties (props).
* **State**: Components can manage their own internal state for dynamic behavior.

### Types of Components

#### 1. Functional Components (Modern Approach)

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

>Warning: React components are regular JavaScript functions, but their names must start with a capital letter or they won’t work!

#### 2. Class Components (Legacy Approach)

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

### Creating Your First Functional Component

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

### Functional component content
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

#### Props
Props (properties) are the read-only inputs a parent component passes to a child. They configure and customize a component's behavior and appearance without the child modifying them. Props are received as a single object argument (often destructured) and enable composition and reuse by decoupling data from implementation.

#### useState

`useState` is a hook that gives a component its own local piece of data (state) and a setter to update it.

#### useEffect

`useEffect` is the hook for running side effects after a component renders. Side effects are interactions with the outside world (network requests, subscriptions, timers, or manual DOM updates).

#### Example:

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

---

## JSX (JavaScript XML)

* [JSX](https://react.dev/learn/writing-markup-with-jsx) is a syntax extension for JavaScript that allows you to write HTML-like code within JavaScript.
* It makes React components more readable and intuitive by combining the power of JavaScript with the familiarity of HTML.
* JSX is transpiled to regular JavaScript function calls by tools like Babel.

>Note: [Great JSX Tutorial from W3 School](https://www.w3schools.com/react/react_jsx.asp)

### JSX Rules

1. **Return a single root element**: Components must return a single parent element or React Fragment.
2. **Close all tags**: All HTML tags must be properly closed, including self-closing tags.
3. **Use camelCase for attributes**: HTML attributes use camelCase (e.g., `className` instead of `class`).
4. **JavaScript expressions in curly braces**: Use `{}` to embed JavaScript expressions.

####  Why do multiple JSX tags need to be wrapped?

* JSX looks like HTML, but under the hood it is transformed into plain JavaScript objects. 
* You can’t return two objects from a function without wrapping them into an array.
* This explains why you also can’t return two JSX tags without wrapping them into another tag or a Fragment.

#### Why use camelCase

* JSX turns into JavaScript and attributes written in JSX become keys of JavaScript objects.
* In your own components, you will often want to read those attributes into variables.
* But JavaScript has limitations on variable names. 
* For example, their names can’t contain dashes or be reserved words like class.
* This is why, in React, many HTML and SVG attributes are written in camelCase. 
* For example, instead of stroke-width you use strokeWidth. 
* Since class is a reserved word, in React you write className instead

### Basic JSX Examples

```jsx
// Valid JSX - Single root element.
// Returning a div
function MyComponent() {
  return (
    <div>
      <h1>Hello World</h1>
      <p>This is a paragraph</p>
    </div>
  );
}

// Valid JSX - React Fragment
// Returning two paragraphs inside <> </>
function MyComponent() {
  return (
    <>
      <h1>Hello World</h1>
      <p>This is a paragraph</p>
    </>
  );
}

// JavaScript expressions in JSX
function Greeting({ name }) {
  const currentTime = new Date().toLocaleTimeString();
  
  return (
    <div>
      <h1>Hello, {name}!</h1>
      <p>Current time: {currentTime}</p>
      <p>Random number: {Math.floor(Math.random() * 100)}</p>
    </div>
  );
}
```

### Combining JSX and JavaScript (common patterns)

Below are the most common patterns when you mix JavaScript and JSX. The repo includes small example components under `react-demo-app/src/components` that demonstrate each pattern — the code snippets below match those components so you can copy/paste them easily.

* 1. Comments
* 2. Store JSX in variables
* 3. Embed expressions
* 4. Conditional rendering
* 5. Render lists
* 6. Functions that return JSX
* 7. Event handlers
* 8. Dynamic attributes
* 9. Spread props

#### 1. Comments

Short: use normal JS comments in logic, and {/* ... */} inside JSX.

Example (component: `ExampleComments.jsx`):

```jsx
import React from 'react';

export default function ExampleComments() {
  // JS comment above
  const count = 3;

  return (
    <div>
      {/* JSX comment: explains the header */}
      <h1>Inbox</h1>

      {/* Multi-line JSX comment:
          - documents group intent
      */}
      <ul>
        <li>Message 1</li>
        <li>Message 2</li>
      </ul>

      {/* Commenting out an element */}
      {/* <LegacyBadge /> */}

      {process.env.NODE_ENV === 'development' && (
        <small>Dev mode — debug info visible</small>
      )}
      <div>Count example: {count}</div>
    </div>
  );
}
```

#### 2. Store JSX in variables

Short: put reusable fragments into constants for clarity.

Example (component: `SimpleLayout.jsx`):

```jsx
const header = <h1>My Static Header</h1>;
const content = (
  <div>
    <ul>
      <li>Apples</li>
      <li>Bananas</li>
      <li>Cherries</li>
    </ul>
  </div>
);
const footer = <footer><small>Static Footer — © 2025</small></footer>;

return (
  <>
    {header}
    {content}
    {footer}
  </>
);
```

#### 3. Embed expressions

Short: use `{}` to evaluate JavaScript expressions inside JSX.

Example (component: `Price.jsx`):

```jsx
export default function Price({ amount = 0, taxRate = 0.1 }) {
  const total = (amount * (1 + taxRate)).toFixed(2);
  return <div>Total: ${total} = ({amount} + {taxRate})</div>;
}
```

#### 4. Conditional rendering

Short: use ternary, `&&`, or early return to show/hide UI.

Example (component: `UserStatus.jsx`):

```jsx
export default function UserStatus({ user }) {
  if (!user) return <div>Please sign in.</div>;

  return (
    <div>
      {user.isAdmin ? <strong>Admin</strong> : <span>User</span>}
      {user.notifications && user.notifications.length > 0 && (
        <span> • {user.notifications.length}</span>
      )}
    </div>
  );
}
```

#### 5. Render lists (map)

Short: use `Array.map` to turn data into elements — provide stable keys.

Example (component: `TodoList.jsx`):

```jsx
export default function TodoList({ todos = [] }) {
  return (
    <ul>
      {todos.map((todo) => (
        <li key={todo.id}>{todo.title}</li>
      ))}
    </ul>
  );
}
```

#### 5b. Render lists (for loop)

Short: useful when per-item logic is complex; build an array of nodes and render it.

Example (component: `TodoListWithLoop.jsx`):

```jsx
export default function TodoListWithLoop({ todos = [] }) {
  const items = [];
  for (let i = 0; i < todos.length; i++) {
    const todo = todos[i];
    if (todo.hidden) continue; // complex per-item logic
    items.push(<li key={todo.id ?? i}>{todo.title}</li>);
  }
  return <ul>{items}</ul>;
}
```

#### 6. Functions that return JSX

Short: extract repeated or complex fragments into small helper functions that return JSX.

Example (component: `ExampleFunctionsReturnJSX.jsx`):

```jsx
export default function ExampleFunctionsReturnJSX({ comment = { author: 'Bob', time: '2h', text: 'Looks good!' } }) {
  function Meta(author, time) {
    return <div className="meta">{author} • {time}</div>;
  }

  return (
    <article>
      <p>{comment.text}</p>
      {Meta(comment.author, comment.time)}
    </article>
  );
}
```

#### 7. Event handlers

Short: attach handlers (onClick, onChange) and use hooks like `useState` to respond to user actions.

Example (component: `Counter.jsx`):

```jsx
import { useState } from 'react';

export default function Counter() {
  const [n, setN] = useState(0);
  return (
    <div>
      <button onClick={() => setN((s) => s + 1)}>+1</button>
      <span> Count: {n}</span>
      <button onClick={() => alert('Hello from Counter')}>Say Hello</button>
    </div>
  );
}
```

#### 8. Dynamic attributes

Short: compute `className` or inline `style` from props/state for dynamic styling.

Example (component: `Notification.jsx`):

```jsx
export default function Notification({ unread = false }) {
  const className = unread ? 'notif unread' : 'notif';
  const style = { borderLeft: unread ? '4px solid #007bff' : '4px solid transparent', padding: 8 };
  return <div className={className} style={style}>You have messages</div>;
}
```

#### 9. Spread props

Short: forward multiple props easily using `{...props}` when building passthrough components.

Example (component: `TextInput.jsx`):

```jsx
export default function TextInput(props) {
  return <input type="text" {...props} />;
}
```

More realistic TextInput usages

```jsx
// 1) Controlled input (parent manages value)
function ControlledExample() {
  const [value, setValue] = useState('Alice');
  return <TextInput value={value} onChange={(e) => setValue(e.target.value)} aria-label="name" />;
}

// 2) Uncontrolled with defaultValue
<TextInput defaultValue="Bob" />

// 3) Disabled / readOnly
<TextInput placeholder="Can't edit" disabled />
<TextInput value="Read only" readOnly />

// 4) Styling & className via spread
const styleProps = { className: 'form-input', style: { padding: 8, borderRadius: 4 } };
<TextInput {...styleProps} placeholder="Styled input" />

// 5) Accessibility (ARIA props forwarded)
<TextInput aria-label="email" aria-required={true} />

// 6) Conditional props
const maybeProps = isMobile ? { inputMode: 'numeric' } : {};
<TextInput {...maybeProps} />

// 7) Merge/override pattern (later props override earlier ones)
const base = { placeholder: 'base', maxLength: 30 };
<TextInput {...base} placeholder="overridden" />

// 8) Forwarding props from parent to child
function Parent(props) {
  return <TextInput {...props} />; // Parent forwards all received props
}

// 9) Small demo component is included: TextInputExamples
//    shows inline props, spread-from-object, and merged props
//    Usage: <TextInputExamples />
```

Notes
- Prefer stable keys for lists (use IDs, not array indexes, unless the list is static).
- Keep heavy computations out of JSX — move them to variables or helpers for readability.
- Use helper functions/components to keep JSX compact and testable.


* Use normal JavaScript comments (`//` single-line or `/* */` multi-line) in JS code.
* Inside JSX you must use JS expressions for comments: `{/*` comment `*/}`.
* Do not use HTML comments (<!-- -->) inside JSX — they are invalid.
* You can "comment out" JSX elements by wrapping them in `{/*` ... `*/}`

```jsx
// JS-level comments
function ExampleA() {

  // counter value
  const count = 3;

  /* 
   * multi-line style also works in JS 
   *
   */

  return (
    <div>
      {/* JSX comment: explains the header */}
      <h1>Inbox</h1>

      {/* Multi-line JSX comment:
          - used to document groups of elements
          - keeps intent near the markup
       */}
      <ul>
        <li>Message 1</li>
        <li>Message 2</li>
      </ul>

      {/* Commenting out an element */}
      {/* <LegacyBadge /> */}
    </div>
  );
}
```

* Invalid example (do NOT use):

```jsx
function Broken() {
  return (
    <div>
      <!-- This looks like HTML but will break JSX -->
      <p>Will not compile</p>
    </div>
  );
}
```

#### 2. Store JSX in variables

* It is possible to create variable/constants with JSX content
* Keep static or pre-composed pieces of UI in variables for clarity and reuse within the same render.

```jsx
function SimpleLayout() {
  const header = <h1>My Static Header</h1>;
  const content = (
    <div>
      <ul>
        <li>Apples</li>
        <li>Bananas</li>
        <li>Cherries</li>
      </ul>
   </div>
  );
  const footer = (
    <div>
      <small>Static Footer — © 2025</small>
    </div>
  );

  return (
    <>
      {header}
      {content}
      {footer}
    </>
  );
}
```

#### 3. Embed expressions

* Use {} to evaluate JavaScript expressions directly inside JSX (variables, math, function calls).

```jsx
function Price({ amount = 0, taxRate = 0.1 }) {

  const total = (amount * (1 + taxRate)).toFixed(2);

  return (
    <div>
      Total: ${total} = ({amount} + {taxRate})
    </div>
  );
}
```

#### 4. Conditional rendering

* Render different UI based on conditions using ternary, && short-circuit, or early return.

```jsx
function UserStatus({ user }) {
  if (!user) return <div>Please sign in.</div>;

  return (
    <div>
      {user.isAdmin ? <strong>Admin</strong> : <span>User</span>} {/* ternary */}
      {user.notifications.length > 0 && <span> • {user.notifications.length}</span>} {/* && */}
    </div>
  );
}
```

```jsx
import { useState } from 'react'
import './App.css'

// Import UserStatus

function App() {

  const [user, setUser] = useState({
    name: 'Alice',
    isAdmin: true,
    notifications: ['Welcome!', 'New message']
  })

  return (
    <>
      <UserStatus user={user} />
    </>
  )
}

export default App
```

```jsx
// Component that receives a choice (1-5) as a prop and renders the corresponding content.
function ChoiceContent({ choice = 1 }) {
  const content = (() => {
    switch (choice) {
      case 1:
        return <p>Tip: Break large tasks into 25-minute focused blocks to stay productive.</p>;
      case 2:
        return <p>Quote: "Simplicity is the soul of efficiency." — keep your components small.</p>;
      case 3:
        return <p>News: The build finished successfully — check the dev server at http://localhost:5173.</p>;
      case 4:
        return <p>Reminder: Commit early and often with clear messages to keep history useful.</p>;
      case 5:
        return <p>Suggestion: Add unit tests for edge cases like empty arrays and null props.</p>;
      default:
        return <p>Nothing to show.</p>;
    }
  })();

  return (
    <section>
      <h3>Selected content ({choice})</h3>
      {content}
    </section>
  );
}

// Usage examples:
// <ChoiceContent choice={1} />
// <ChoiceContent choice={3} />
```

#### 5. Render lists

* It is very comon to use array or collections to return a list of `HTML` elements
* Always provide stable keys when rendering lists.
  * Stable key: Does not change between renders for the same logical item.
  * Keys let React identify which items changed, were added, or removed during reconciliation.

* Using Array.map

```jsx
function TodoList({ todos }) {
  return (
    <ul>
      {todos.map((todo) => (
        <li key={todo.id}>{todo.title}</li>
      ))}
    </ul>
  );
}
```

* Using for

```jsx
function TodoListWithLoop({ todos = [] }) {
  const items = [];
  for (let i = 0; i < todos.length; i++) {
    const todo = todos[i];
    items.push(<li key={todo.id}>{todo.title}</li>);
  }
  return <ul>{items}</ul>;
}
```

#### 6. Functions that return JSX

* Extract repeated or complex fragments into small helper functions or components that return JSX for readability.

```jsx
function Avatar({ user }) {
  return <img src={user.avatar} alt={user.name} className="avatar" />;
}

function Comment({ comment }) {
  function Meta() {
    return <div className="meta">{comment.author} • {comment.time}</div>;
  }

  return (
    <article>
      <Avatar user={comment.authorInfo} />
      <p>{comment.text}</p>
      <Meta />
    </article>
  );
}
```

#### 7. Event handlers

* Attach functions to events (onClick, onChange).
* Use useState or callbacks to react to user actions.

Example:
```jsx
import { useState } from 'react';

function Counter() {
  const [n, setN] = useState(0);

  function sayHello () {
    alert("Hello");
  }

  return (
    <div>
      <button onClick={() => setN((s) => s + 1)}>+1</button>
      <span> Count: {n}</span>
      <button onClick={sayHello()}>Say Hello</button>
    </div>
  );
}
```

#### 8. Dynamic attributes (className, style)

* Compute attributes like className or inline styles from state/props for conditional styling.

Example:
```jsx
function Notification({ unread }) {
  const className = unread ? 'notif unread' : 'notif';
  const style = { borderLeft: unread ? '4px solid #007bff' : '4px solid transparent' };

  return <div className={className} style={style}>You have messages</div>;
}
```

## Props (Properties)

* [Props](https://react.dev/learn/passing-props-to-a-component) are how components receive data from their parent components.
* They are read-only and help make components reusable by allowing different data to be passed in.
* Props flow down from parent to child components (unidirectional data flow).

### Passing and Using Props

```jsx
// Parent Component
function App() {
  return (
    <div>
      <Greeting name="Alice" age={25} />
      <Greeting name="Bob" age={30} />
    </div>
  );
}

// Child Component
function Greeting({ name, age }) {
  return (
    <div>
      <h2>Hello, {name}!</h2>
      <p>You are {age} years old.</p>
    </div>
  );
}
```

### Props with Default Values

```jsx
function Button({ text = "Click me", color = "blue" }) {
  return (
    <button style={{ backgroundColor: color }}>
      {text}
    </button>
  );
}

// Usage
<Button text="Submit" color="green" />
<Button /> {/* Uses default values */}
```

## State and useState Hook

* [State](https://react.dev/learn/state-a-components-memory) allows components to remember and manage data that can change over time.
* The `useState` hook is the modern way to add state to functional components.
* When state changes, React automatically re-renders the component with the new data.

### Multiple State Variables

## Event Handling

* React uses [SyntheticEvents](https://react.dev/reference/react-dom/components/common#applying-css-styles) to handle user interactions consistently across different browsers.
* Event handlers are functions that respond to user actions like clicks, form submissions, and keyboard input.

## Conditional Rendering

* React allows you to conditionally render different content based on component state or props.
* Use JavaScript conditional operators like `if`, ternary operator (`?:`), and logical AND (`&&`).

## React 19 New Features

### useEffect Hook and Side Effects

* [useEffect](https://react.dev/reference/react/useEffect) allows you to perform side effects in functional components.
* Side effects include data fetching, subscriptions, DOM manipulation, and cleanup.

### Actions

* Actions provide a built-in way to handle form submissions and data mutations.
* They automatically handle loading states, error handling, and optimistic updates.


### Server Components

* Server Components run on the server and can directly access databases and APIs.
* They reduce bundle size and improve initial page load performance.



