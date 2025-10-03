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

```
cd [YOUR_FOLDER]/codando-live/_12_React/
npm create vite@latest react-demo-app -- --template react

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

Functional components are JavaScript functions that return JSX. They use React Hooks for state and lifecycle management.

```jsx
// HelloWorld.js
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

#### 2. Class Components (Legacy Approach)

Class components extend React.Component and use lifecycle methods. While still supported, functional components with hooks are preferred.

```jsx
// HelloWorldClass.js
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

### Creating Your First Component

Let's create a simple `HelloWorld` component step by step:

* **Step 1**: Create a new file `src/components/HelloWorld.js`
* **Step 2**: Write the component function
* **Step 3**: Export the component
* **Step 4**: Import and use it in App.js

See the examples in the `examples/` directory for complete implementations.

## JSX (JavaScript XML)

* [JSX](https://react.dev/learn/writing-markup-with-jsx) is a syntax extension for JavaScript that allows you to write HTML-like code within JavaScript.
* It makes React components more readable and intuitive by combining the power of JavaScript with the familiarity of HTML.
* JSX is transpiled to regular JavaScript function calls by tools like Babel.

### JSX Rules

1. **Return a single root element**: Components must return a single parent element or React Fragment.
2. **Close all tags**: All HTML tags must be properly closed, including self-closing tags.
3. **Use camelCase for attributes**: HTML attributes use camelCase (e.g., `className` instead of `class`).
4. **JavaScript expressions in curly braces**: Use `{}` to embed JavaScript expressions.

### JSX Examples

```jsx
// Valid JSX - Single root element
function MyComponent() {
  return (
    <div>
      <h1>Hello World</h1>
      <p>This is a paragraph</p>
    </div>
  );
}

// Valid JSX - React Fragment
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

### Basic useState Example

```jsx
import React, { useState } from 'react';

function Counter() {
  // Declare state variable with initial value
  const [count, setCount] = useState(0);

  return (
    <div>
      <h2>Counter: {count}</h2>
      <button onClick={() => setCount(count + 1)}>
        Increment
      </button>
      <button onClick={() => setCount(count - 1)}>
        Decrement
      </button>
      <button onClick={() => setCount(0)}>
        Reset
      </button>
    </div>
  );
}
```

### Multiple State Variables

```jsx
function UserProfile() {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [isVisible, setIsVisible] = useState(true);

  return (
    <div>
      {isVisible && (
        <div>
          <input 
            value={name}
            onChange={(e) => setName(e.target.value)}
            placeholder="Enter name"
          />
          <input 
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="Enter email"
          />
          <p>Name: {name}</p>
          <p>Email: {email}</p>
        </div>
      )}
      <button onClick={() => setIsVisible(!isVisible)}>
        {isVisible ? 'Hide' : 'Show'} Profile
      </button>
    </div>
  );
}
```

## Event Handling

* React uses [SyntheticEvents](https://react.dev/reference/react-dom/components/common#applying-css-styles) to handle user interactions consistently across different browsers.
* Event handlers are functions that respond to user actions like clicks, form submissions, and keyboard input.

### Common Event Handlers

```jsx
function EventDemo() {
  const [message, setMessage] = useState('');

  const handleClick = () => {
    setMessage('Button was clicked!');
  };

  const handleInputChange = (event) => {
    setMessage(event.target.value);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    alert(`Submitted: ${message}`);
  };

  return (
    <div>
      <button onClick={handleClick}>Click Me</button>
      
      <form onSubmit={handleSubmit}>
        <input 
          type="text"
          value={message}
          onChange={handleInputChange}
          placeholder="Type something..."
        />
        <button type="submit">Submit</button>
      </form>
      
      <p>Message: {message}</p>
    </div>
  );
}
```

## Conditional Rendering

* React allows you to conditionally render different content based on component state or props.
* Use JavaScript conditional operators like `if`, ternary operator (`?:`), and logical AND (`&&`).

### Conditional Rendering Examples

```jsx
function LoginStatus({ isLoggedIn, username }) {
  // Using if statement
  if (isLoggedIn) {
    return <h2>Welcome back, {username}!</h2>;
  }
  return <h2>Please log in.</h2>;
}

function UserDashboard({ user }) {
  return (
    <div>
      {/* Using ternary operator */}
      {user ? (
        <div>
          <h2>Welcome, {user.name}!</h2>
          <p>Email: {user.email}</p>
        </div>
      ) : (
        <p>No user data available.</p>
      )}
      
      {/* Using logical AND */}
      {user && user.isPremium && (
        <div>
          <h3>Premium Features</h3>
          <p>You have access to premium content!</p>
        </div>
      )}
    </div>
  );
}
```

## Lists and Keys

* Render lists of data using JavaScript's `map()` function.
* Each list item needs a unique `key` prop to help React efficiently update the DOM.

### Rendering Lists

```jsx
function TodoList() {
  const [todos, setTodos] = useState([
    { id: 1, text: 'Learn React', completed: false },
    { id: 2, text: 'Build a project', completed: false },
    { id: 3, text: 'Deploy to production', completed: true }
  ]);

  const toggleTodo = (id) => {
    setTodos(todos.map(todo =>
      todo.id === id ? { ...todo, completed: !todo.completed } : todo
    ));
  };

  return (
    <div>
      <h2>Todo List</h2>
      <ul>
        {todos.map(todo => (
          <li key={todo.id}>
            <span 
              style={{ 
                textDecoration: todo.completed ? 'line-through' : 'none' 
              }}
              onClick={() => toggleTodo(todo.id)}
            >
              {todo.text}
            </span>
          </li>
        ))}
      </ul>
      {todos.length === 0 && <p>No todos available.</p>}
    </div>
  );
}
```

## Interactive Demo Application

All React examples are consolidated into a single interactive demo application in the `react-demo/` directory. This provides a seamless way to demonstrate concepts and show source code side-by-side.

### Available Examples:

* **Hello World** - Basic component creation, JSX syntax, and props
* **Counter App** - State management with useState hook and event handling  
* **Todo List** - Complex state management, arrays, forms, and filtering
* **User Profile** - Form validation, controlled components, and object state
* **Lifecycle Demo** - useEffect hook, side effects, cleanup, and data fetching
* **React 19 Actions** - useActionState, useOptimistic, and modern form handling (NEW!)

### Running the Demo:

```bash
cd _12_React/react-demo
npm install
npm run dev
# Open http://localhost:5173/ in your browser
```

### Teaching with the Demo:

1. **Show the Home Page**: Start with the overview and learning path
2. **Navigate Between Examples**: Use the top navigation to switch between concepts
3. **Show Source Code**: Open your IDE alongside the browser to show the actual component code
4. **Encourage Interaction**: Have students modify the code and see immediate results
5. **Use Browser DevTools**: Show React Developer Tools and console logs

### Demo Features:

- **Interactive Navigation**: Easy switching between different React concepts
- **Visual Learning Path**: Recommended progression from beginner to advanced
- **Teaching Tips**: Built-in guidance for instructors
- **Responsive Design**: Works on all screen sizes
- **Modern UI**: Clean, professional interface for presentations

## React 19 New Features

### useEffect Hook and Side Effects

* [useEffect](https://react.dev/reference/react/useEffect) allows you to perform side effects in functional components.
* Side effects include data fetching, subscriptions, DOM manipulation, and cleanup.

```jsx
import React, { useState, useEffect } from 'react';

function UserProfile({ userId }) {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Effect runs after component mounts and when userId changes
    const fetchUser = async () => {
      setLoading(true);
      try {
        const response = await fetch(`/api/users/${userId}`);
        const userData = await response.json();
        setUser(userData);
      } catch (error) {
        console.error('Failed to fetch user:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchUser();

    // Cleanup function (optional)
    return () => {
      // Cancel any ongoing requests or subscriptions
    };
  }, [userId]); // Dependency array

  if (loading) return <div>Loading...</div>;
  if (!user) return <div>User not found</div>;

  return (
    <div>
      <h2>{user.name}</h2>
      <p>Email: {user.email}</p>
    </div>
  );
}
```

### Actions (React 19)

* Actions provide a built-in way to handle form submissions and data mutations.
* They automatically handle loading states, error handling, and optimistic updates.

```jsx
import { useActionState } from 'react';

function ContactForm() {
  const [state, submitAction, isPending] = useActionState(
    async (prevState, formData) => {
      try {
        const response = await fetch('/api/contact', {
          method: 'POST',
          body: formData,
        });
        
        if (!response.ok) {
          throw new Error('Failed to submit form');
        }
        
        return { success: true, message: 'Message sent successfully!' };
      } catch (error) {
        return { success: false, error: error.message };
      }
    },
    { success: false, message: '' }
  );

  return (
    <form action={submitAction}>
      <input name="name" placeholder="Your name" required />
      <input name="email" type="email" placeholder="Your email" required />
      <textarea name="message" placeholder="Your message" required />
      
      <button type="submit" disabled={isPending}>
        {isPending ? 'Sending...' : 'Send Message'}
      </button>
      
      {state.success && <p style={{color: 'green'}}>{state.message}</p>}
      {state.error && <p style={{color: 'red'}}>{state.error}</p>}
    </form>
  );
}
```

### Server Components (React 19)

* Server Components run on the server and can directly access databases and APIs.
* They reduce bundle size and improve initial page load performance.

```jsx
// ServerComponent.js (runs on server)
import { db } from './database';

async function ProductList() {
  // This runs on the server - can access database directly
  const products = await db.products.findMany({
    orderBy: { createdAt: 'desc' },
    take: 10
  });

  return (
    <div>
      <h2>Latest Products</h2>
      {products.map(product => (
        <div key={product.id}>
          <h3>{product.name}</h3>
          <p>{product.description}</p>
          <span>${product.price}</span>
        </div>
      ))}
    </div>
  );
}

export default ProductList;
```

### Enhanced Suspense

* React 19 improves Suspense for better loading states and error boundaries.

```jsx
import { Suspense } from 'react';

function App() {
  return (
    <div>
      <h1>My App</h1>
      <Suspense fallback={<div>Loading products...</div>}>
        <ProductList />
      </Suspense>
    </div>
  );
}
```

## Next Steps

After mastering these fundamentals, explore:

* **Custom Hooks** - Reusable stateful logic
* **Context API** - Global state management
* **React Router** - Client-side routing for SPAs
* **Server Components** - Advanced server-side rendering patterns
* **Actions and Forms** - Modern form handling with React 19
* **State Management** - Redux, Zustand, or other libraries
* **Testing** - Jest and React Testing Library
* **Performance** - Optimization techniques and best practices

>Class Note: Work through the examples together, encouraging students to modify and experiment with the code!