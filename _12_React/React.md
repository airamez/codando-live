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
* 3. Dynamic CSS Styles
* 4. Embed expressions
* 5. Conditional rendering
* 6. Render lists
* 7. Functions that return JSX
* 8. Props (Properties)
* 9. Event handlers
* 10. Controlled Components
* 11. Dynamic attributes
* 12. Spread props

#### 1. Comments

Use normal JS comments in logic, and {/* ... */} inside JSX.

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

#### 3. Dynamic CSS Styles

Create style objects dynamically using JavaScript expressions and state.

Example (component: `DynamicStyles.jsx`):

```jsx
import React, { useState } from 'react';

export default function DynamicStyles({ initialColor = 'blue', initialSize = 16 }) {
  const [color, setColor] = useState(initialColor);
  const [size, setSize] = useState(initialSize);
  const [isBold, setIsBold] = useState(false);

  // Dynamic style object
  const textStyle = {
    color: color,
    fontSize: `${size}px`,
    fontWeight: isBold ? 'bold' : 'normal',
    padding: '8px',
    border: `2px solid ${color}`,
    borderRadius: '4px',
    transition: 'all 0.3s ease',
  };

  return (
    <div>
      <p style={textStyle}>
        This text style is dynamic! Color: {color}, Size: {size}px, Bold: {isBold ? 'Yes' : 'No'}
      </p>

      <div style={{ display: 'flex', gap: '8px', marginTop: '12px', flexWrap: 'wrap' }}>
        <button onClick={() => setColor('red')} style={{ padding: '4px 8px' }}>Red</button>
        <button onClick={() => setColor('green')} style={{ padding: '4px 8px' }}>Green</button>
        <button onClick={() => setColor('blue')} style={{ padding: '4px 8px' }}>Blue</button>
        <button onClick={() => setColor('purple')} style={{ padding: '4px 8px' }}>Purple</button>
      </div>

      <div style={{ marginTop: '12px' }}>
        <label>
          Font size: {size}px
          <input
            type="range"
            min="12"
            max="48"
            value={size}
            onChange={(e) => setSize(Number(e.target.value))}
            style={{ marginLeft: '8px' }}
          />
        </label>
      </div>

      <div style={{ marginTop: '12px' }}>
        <label>
          <input
            type="checkbox"
            checked={isBold}
            onChange={(e) => setIsBold(e.target.checked)}
          />
          {' '}Bold
        </label>
      </div>
    </div>
  );
}
```

#### 4. Embed expressions

Use `{}` to evaluate JavaScript expressions inside JSX.

Example (component: `Price.jsx`):

```jsx
export default function Price({ amount = 0, taxRate = 0.1 }) {
  const total = (amount * (1 + taxRate)).toFixed(2);
  return <div>Total: ${total} = ({amount} + {taxRate})</div>;
}
```

#### 5. Conditional rendering

It is very common to render results based on conditions

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

#### 6. Render lists

* Using `Array.map` to turn data into elements.
* Provide stable keys.

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

* Using `for` when per-item logic is complex
* Build an array of nodes and render it.

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

#### 7. Functions that return JSX

Extract repeated or complex fragments into small helper functions that return JSX.

Example (component: `PRsReview.jsx`):

```jsx
export default function PRsReview({ reviews }) {

  // helper function that calculates word count
  function getWordCount(text) {
    return text.trim().split(/\s+/).length;
  }

  // helper function to translate status number to text
  function getStatusText(statusNumber) {
    switch (statusNumber) {
      case 1:
        return 'Approved';
      case 2:
        return 'Approved with comments';
      case 3:
        return 'Rejected';
      default:
        return 'Unknown';
    }
  }

  return (
    <div>
      <h4>Pull Request Reviews</h4>
      <table border="1">
        <thead>
          <tr>
            <th>Date</th>
            <th>Author</th>
            <th>Review Text</th>
            <th>Word Count</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {reviews.map((review, index) => (
            <tr key={index}>
              <td>{review.date}</td>
              <td>{review.author}</td>
              <td>{review.text}</td>
              <td>{getWordCount(review.text)}</td>
              <td>{getStatusText(review.status)}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
```

#### 8. Props (Properties)

**Props (properties)** are how components [receive data from their parent components](https://react.dev/learn/passing-props-to-a-component). They enable component composition, reusability, and the unidirectional data flow that makes React predictable.

**Props vs useState - Understanding the Difference:**

The key difference is **who owns and controls the data**:

| Aspect | Props | useState |
|--------|-------|----------|
| **Ownership** | Owned by **parent** component | Owned by **current** component |
| **Mutability** | **Read-only** (immutable) | **Mutable** (via setter function) |
| **Data Flow** | **Unidirectional**: Parent → Child | **Unidirectional**: State → View → Event → State |
| **Direction** | Flows **down** from parent to child | Internal cycle within component |
| **Purpose** | Pass data to child components | Manage component's internal state |
| **How Updates Work** | Parent changes its state → Parent re-renders → Child receives new props → Child re-renders | setState called → Component re-renders with new state |
| **Change Mechanism** | Child notifies parent via callbacks | Direct setState call within component |

**Important:** Both follow React's **unidirectional data flow** principle:
- **Props:** Data flows down (parent → child), changes flow up via callbacks
- **State:** State changes trigger view updates, view changes require explicit setState calls
- Neither supports automatic two-way binding (unlike Angular's `[(ngModel)]`)

**Example - Counter with Props vs useState:**

```jsx
// ❌ WRONG: Trying to modify props (will not work!)
function Counter({ count }) {
  return (
    <div>
      <p>Count: {count}</p>
      {/* This button does nothing - can't change props! */}
      <button onClick={() => count++}>Increment</button>
    </div>
  );
}

// ✅ CORRECT: Using useState for local state
function Counter() {
  const [count, setCount] = useState(0);  // Component owns this data
  
  return (
    <div>
      <p>Count: {count}</p>
      <button onClick={() => setCount(count + 1)}>Increment</button>
    </div>
  );
}

// ✅ ALSO CORRECT: Props for display, callback to notify parent
function Counter({ count, onIncrement }) {
  return (
    <div>
      <p>Count: {count}</p>
      {/* Calls parent's function to update parent's state */}
      <button onClick={onIncrement}>Increment</button>
    </div>
  );
}

// Parent component that uses the Counter with props
function App() {
  const [count, setCount] = useState(0);  // Parent owns the state
  
  return (
    <Counter 
      count={count}                        // Pass data down
      onIncrement={() => setCount(count + 1)}  // Pass callback up
    />
  );
}
```

**When to use Props vs useState:**

- **Use Props** when:
  - Data comes from a parent component
  - Child should display but not modify data
  - Multiple children need to share the same data
  - Building reusable components

- **Use useState** when:
  - Component needs to manage its own data
  - Data changes based on user interaction within the component
  - Data doesn't need to be shared with parent or siblings

---

**Key Concepts:**

* **Read-only**: Props cannot be modified by the child component - they are immutable
* **Single object**: React always passes props as a single object (not separate parameters)
* **Unidirectional flow**: Data flows down from parent to child (top-down)
* **Reusability**: Same component can display different data based on props received
* **Type safety**: Can be validated with PropTypes or TypeScript

**How React Passes Props:**

When you write:
```jsx
<Greeting name="Leila" age={25} />
```

React internally calls:
```javascript
Greeting({ name: "Leila", age: 25 })  // Single object argument
```

**Three Ways to Receive Props:**

1. **Destructuring (Recommended)** - Clean and explicit
```jsx
function Greeting({ name, age }) {
  return <h2>Hello, {name}! Age: {age}</h2>;
}
```

2. **Props object** - Access via `props.propertyName`
```jsx
function Greeting(props) {
  return <h2>Hello, {props.name}! Age: {props.age}</h2>;
}
```

3. **❌ Separate parameters (Does NOT work)**
```jsx
function Greeting(name, age) {  // Wrong! Won't work
  return <h2>Hello, {name}! Age: {age}</h2>;  // Both undefined
}
```

**Passing Props - Curly Braces Rules:**

In JSX, you must use the correct syntax for different value types:

```jsx
// ✅ Strings: Use quotes (no curly braces needed)
<Greeting name="Leila" role="Admin" />

// ✅ Numbers: Use curly braces
<Greeting age={25} score={98.5} />

// ❌ WRONG: Numbers without curly braces become strings
<Greeting age=25 />  // age will be string "25", not number 25

// ✅ Booleans: Use curly braces
<Greeting isActive={true} isAdmin={false} />

// ✅ Variables/Expressions: Use curly braces
<Greeting name={userName} age={currentYear - birthYear} />

// ✅ Objects/Arrays: Use curly braces
<Greeting user={{ name: "Leila", age: 25 }} />
<Greeting tags={["react", "javascript"]} />
```

**Props with Default Values:**

```jsx
function Greeting({ name = "Guest", age = 0, role = "User" }) {
  return (
    <div>
      <h2>Hello, {name}!</h2>
      <p>Age: {age} | Role: {role}</p>
    </div>
  );
}

// Usage
<Greeting name="Leila" age={25} role="Admin" />  // Hello, Leila! Age: 25 | Role: Admin
<Greeting name="Jose" />                          // Hello, Jose! Age: 0 | Role: User
<Greeting />                                     // Hello, Guest! Age: 0 | Role: User
```

**Example (component: `ProductCard.jsx`):**

```jsx
import './ProductCard.css';

export default function ProductCard({
  name,
  price,
  inStock = true,
  category = "General",
  onAddToCart,
  imageUrl
}) {
  return (
    <div className={`product-card ${inStock ? 'in-stock' : 'out-of-stock'}`}>
      <img
        src={imageUrl}
        alt={name}
        className="product-card-image"
      />

      <h3 className="product-card-title">{name}</h3>

      <p className="product-card-category">
        Category: {category}
      </p>

      <p className="product-card-price">
        ${price.toFixed(2)}
      </p>

      <p className={`product-card-stock ${inStock ? 'in-stock' : 'out-of-stock'}`}>
        {inStock ? '✓ In Stock' : '✗ Out of Stock'}
      </p>

      <button
        onClick={() => onAddToCart(name)}
        disabled={!inStock}
        className={`product-card-button ${inStock ? 'available' : 'unavailable'}`}
      >
        {inStock ? 'Add to Cart' : 'Unavailable'}
      </button>
    </div>
  );
}
```

**Using the ProductCard component:**

```jsx
import { useState } from 'react';
import ProductCard from './components/ProductCard';

function App() {
  const [cart, setCart] = useState([]);
  
  const handleAddToCart = (productName) => {
    setCart([...cart, productName]);
    alert(`${productName} added to cart!`);
  };
  
  return (
    <div>
      <h2>Products ({cart.length} items in cart)</h2>
      
      <div style={{ display: 'flex', flexWrap: 'wrap' }}>
        <ProductCard 
          name="Laptop"
          price={999.99}
          category="Electronics"
          inStock={true}
          onAddToCart={handleAddToCart}
        />
        
        <ProductCard 
          name="Coffee Mug"
          price={12.50}
          category="Kitchen"
          inStock={true}
          onAddToCart={handleAddToCart}
        />
        
        <ProductCard 
          name="Headphones"
          price={199.99}
          category="Electronics"
          inStock={false}
          onAddToCart={handleAddToCart}
        />
        
        {/* Using default values */}
        <ProductCard 
          name="Mystery Box"
          price={49.99}
          onAddToCart={handleAddToCart}
        />
      </div>
    </div>
  );
}
```

**Props vs State:**

| Aspect | Props | State |
|--------|-------|-------|
| **Mutability** | Read-only (immutable) | Can be changed with setter |
| **Owner** | Passed from parent | Owned by component |
| **Purpose** | Configure component | Track component data |
| **Flow** | Top-down (parent → child) | Internal to component |
| **Update** | Parent re-renders with new props | Component calls setState |

**Props Best Practices:**

1. **Destructure for clarity**: `function MyComponent({ title, count })` instead of `props.title`
2. **Provide defaults**: `function MyComponent({ title = "Default" })`
3. **Validate types**: Use PropTypes or TypeScript for type checking
4. **Keep props simple**: Avoid deeply nested objects when possible
5. **Don't modify props**: Never do `props.value = newValue` (props are read-only)
6. **Use meaningful names**: `isActive` better than `flag`, `userName` better than `n`

**Common Props Pattern - Callback Functions:**

```jsx
// Parent passes a function as prop
function Parent() {
  const handleClick = (message) => {
    alert(`Received: ${message}`);
  };
  
  return <Child onButtonClick={handleClick} />;
}

// Child calls the function passed via props
function Child({ onButtonClick }) {
  return (
    <button onClick={() => onButtonClick("Hello from child!")}>
      Click Me
    </button>
  );
}
```

##### A better example of ProductCard

* Example: `_12_React/react-demo-app/src/components/ProductCardImproved.jsx`

```jsx
import './ProductCard.css';

export default function ProductCardImproved({ product, onAddToCart }) {
  const { name, price, inStock = true, category = "General", imageUrl } = product;

  return (
    <div className={`product-card ${inStock ? 'in-stock' : 'out-of-stock'}`}>
      <img
        src={imageUrl}
        alt={name}
        className="product-card-image"
      />

      <h3 className="product-card-title">{name}</h3>

      <p className="product-card-category">
        Category: {category}
      </p>

      <p className="product-card-price">
        ${price.toFixed(2)}
      </p>

      <p className={`product-card-stock ${inStock ? 'in-stock' : 'out-of-stock'}`}>
        {inStock ? '✓ In Stock' : '✗ Out of Stock'}
      </p>

      <button
        onClick={() => onAddToCart(name)}
        disabled={!inStock}
        className={`product-card-button ${inStock ? 'available' : 'unavailable'}`}
      >
        {inStock ? 'Add to Cart' : 'Unavailable'}
      </button>
    </div>
  );
}
```

#### 9. Event Handling

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

#### 10. Parent/Child communication

Parent/Child communication demonstrates how data and functions flow between components in React's unidirectional architecture. Parents pass data and callback functions to children via props, and children notify parents of user actions by invoking those callbacks.

**Key Concepts:**
- **Props down**: Parent passes data (state) and functions to children
- **Callbacks up**: Children call parent functions to trigger state changes
- **Shared state**: Parent maintains state that multiple children need to access or modify
- **Array operations**: Demonstrates immutable array manipulation (spread operator, filter)
- **Single source of truth**: Parent owns the state, children display and interact with it

**Communication Pattern:**
```
Parent (owns state)
  ↓ props (data + callbacks)
Child 1 (displays + modifies)    Child 2 (displays + modifies)
  ↑ callbacks (notify parent)      ↑ callbacks (notify parent)
```

Example (component: `Parent.jsx`, `ChildAdd.jsx`, `ChildRemove.jsx`):

**Parent Component** - Manages shared state and provides handlers:

```jsx
import React, { useState } from 'react';
import ChildAdd from './ChildAdd';
import ChildRemove from './ChildRemove';
import './Parent.css';

function Parent() {
  // State to hold the array of entries (shared between children)
  const [entries, setEntries] = useState([]);

  /**
   * Adds a new entry to the array
   * Uses spread operator [...entries, entry] to create a new array
   * This is immutable - doesn't modify the original array
   */
  const handlerAdd = (entry) => {
    setEntries([...entries, entry]);
  }

  /**
   * Removes an entry from the array by index
   * Uses filter() to create a new array without the specified index
   * filter() returns a new array, keeping immutability
   */
  const handlerRemove = (index) => {
    setEntries(entries.filter((_, i) => i !== index));
  }

  return (
    <div className="container">
      <h1 className="title">Parent/Child communication</h1>
      <div className="childrenContainer">
        {/* Pass state and callbacks to children */}
        <ChildAdd entries={entries} addEntry={handlerAdd} />
        <ChildRemove entries={entries} removeEntry={handlerRemove} />
      </div>
    </div>
  );
}

export default Parent;
```

**Child Component 1** - Adds entries by calling parent's callback:

```jsx
import React, { useState } from 'react';
import './ChildAdd.css';

function ChildAdd({ entries = [], addEntry }) {
  // Local state for the input field (child's own state)
  const [inputValue, setInputValue] = useState('');

  /**
   * Handles adding a new entry to the parent's array
   * Validates input is not empty before adding
   * Clears the input field after adding
   */
  const handleAdd = () => {
    if (inputValue.trim()) {
      addEntry(inputValue);  // Call parent's function
      setInputValue('');     // Clear local state
    }
  };

  /**
   * Allows adding entry by pressing Enter key
   */
  const handleKeyPress = (e) => {
    if (e.key === 'Enter') {
      handleAdd();
    }
  };

  return (
    <div className="container">
      <h2 className="title">Add Entry</h2>
      <div className="inputContainer">
        <input
          type="text"
          value={inputValue}
          onChange={(event) => setInputValue(event.target.value)}
          onKeyUp={handleKeyPress}
          placeholder="New Entry value..."
          className="input"
        />
        <button onClick={handleAdd} className="button">Add</button>
      </div>
      <h3 className="listTitle">Entries ({entries.length})</h3>
      <ul className="list">
        {/* Display parent's data */}
        {entries.map((entry, index) => (
          <li key={index} className="listItem">{entry}</li>
        ))}
      </ul>
    </div>
  );
}

export default ChildAdd;
```

**Child Component 2** - Removes entries by calling parent's callback:

```jsx
import React, { useState } from 'react';
import './ChildRemove.css';

function ChildRemove({ entries = [], removeEntry }) {
  // Local state to track which entry is selected in the dropdown
  const [selectedIndex, setSelectedIndex] = useState('');

  /**
   * Handles removing the selected entry from the parent's array
   * Converts selectedIndex from string to integer
   * Clears the selection after removal
   */
  const handleRemove = () => {
    if (selectedIndex !== '') {
      removeEntry(parseInt(selectedIndex));  // Call parent's function
      setSelectedIndex('');                  // Clear local state
    }
  };

  return (
    <div className="container">
      <h2 className="title">Remove Entry</h2>
      <div className="selectContainer">
        <select
          value={selectedIndex}
          onChange={(e) => setSelectedIndex(e.target.value)}
          className="select"
        >
          <option value="">Select an entry to remove...</option>
          {/* Display parent's data in dropdown */}
          {entries.map((entry, index) => (
            <option key={index} value={index}>
              {entry}
            </option>
          ))}
        </select>
        <button
          onClick={handleRemove}
          disabled={selectedIndex === ''}
          className="button"
        >
          Remove
        </button>
      </div>
    </div>
  );
}

export default ChildRemove;
```

**How It Works:**

1. **Parent owns the state**: `entries` array is stored in Parent component
2. **Parent passes data down**: Both children receive `entries` via props
3. **Parent passes callbacks**: `handlerAdd` and `handlerRemove` passed as props
4. **Children have local state**: Each child manages its own UI state (input value, selected index)
5. **Children notify parent**: When user acts, children call parent's callback functions
6. **Parent updates state**: Parent's setState triggers re-render
7. **Children re-render**: With new props, both children display updated data

**Why This Pattern:**
- **Single source of truth**: Parent owns the data, avoiding sync issues
- **Separation of concerns**: Each child handles its own UI logic
- **Reusability**: Children don't care who their parent is
- **Predictability**: Data flows one direction, making debugging easier
- **Immutability**: Array operations create new arrays, following React best practices

#### 11. Controlled Components

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
const [value, setValue] = useState('');

<input 
  value={value} // Bind to state
  onChange={(e) => setValue(e.target.value)} // Update state on change
/>
```

**React Documentation:**
- [Forms - Controlled Components](https://react.dev/reference/react-dom/components/input#controlling-an-input-with-a-state-variable)
- [Managing State - Reacting to Input with State](https://react.dev/learn/reacting-to-input-with-state)
- [API Reference - Common components (input, textarea, select)](https://react.dev/reference/react-dom/components/common)

#### 12. Dynamic attributes

Compute `className` or inline `style` from props/state for dynamic styling.

Example (component: `Notification.jsx`):


#### 13. Spread props

Forward multiple props easily using `{...props}` when building passthrough components.

Example (component: `TextInput.jsx`):

```jsx
export default function TextInput(props) {
  return <input type="text" {...props} />;
}
```