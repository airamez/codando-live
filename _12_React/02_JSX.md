# JSX (JavaScript XML)

* [JSX](https://react.dev/learn/writing-markup-with-jsx) is a syntax extension for JavaScript that allows you to write HTML-like code within JavaScript.
* It makes React components more readable and intuitive by combining the power of JavaScript with the familiarity of HTML.
* JSX is transpiled to regular JavaScript function calls by tools like Babel.

>Note: [Great JSX Tutorial from W3 School](https://www.w3schools.com/react/react_jsx.asp)

## JSX Rules

1. **Return a single root element**: Components must return a single parent element or React Fragment.
2. **Close all tags**: All HTML tags must be properly closed, including self-closing tags.
3. **Use camelCase for attributes**: HTML attributes use camelCase (e.g., `className` instead of `class`).
4. **JavaScript expressions in curly braces**: Use `{}` to embed JavaScript expressions.

##  Why do multiple JSX tags need to be wrapped?

* JSX looks like HTML, but under the hood it is transformed into plain JavaScript objects. 
* You can't return two objects from a function without wrapping them into an array.
* This explains why you also can't return two JSX tags without wrapping them into another tag or a Fragment.

## Why use camelCase

* JSX turns into JavaScript and attributes written in JSX become keys of JavaScript objects.
* In your own components, you will often want to read those attributes into variables.
* But JavaScript has limitations on variable names. 
* For example, their names can't contain dashes or be reserved words like class.
* This is why, in React, many HTML and SVG attributes are written in camelCase. 
* For example, instead of stroke-width you use strokeWidth. 
* Since class is a reserved word, in React you write className instead

## Basic JSX Examples

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

## Combining JSX and JavaScript (common patterns)

Below are the most common patterns when you mix JavaScript and JSX. The repo includes small example components under `react-demo-app/src/components` that demonstrate each pattern — the code snippets below match those components so you can copy/paste them easily.

* 1. Comments
* 2. Store JSX in variables
* 3. Dynamic CSS Styles
* 4. Embed expressions
* 5. Conditional rendering
* 6. Render lists
* 7. Functions that return JSX

### 1. Comments

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

### 2. Store JSX in variables

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

### 3. Dynamic CSS Styles

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

### 4. Embed expressions

Use `{}` to evaluate JavaScript expressions inside JSX.

Example (component: `Price.jsx`):

```jsx
export default function Price({ amount = 0, taxRate = 0.1 }) {
  const total = (amount * (1 + taxRate)).toFixed(2);
  return <div>Total: ${total} = ({amount} + {taxRate})</div>;
}
```

### 5. Conditional rendering

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

### 6. Render lists

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

### 7. Functions that return JSX

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
