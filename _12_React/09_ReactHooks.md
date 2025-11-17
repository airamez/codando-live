# React Hooks

- React Hooks are special functions that let you use state and other React features in functional components.
- Introduced in React 16.8, hooks revolutionized React development by eliminating the need for class components while providing a more intuitive and composable way to manage component logic.

**Documentation:**

* [React Hooks Documentation](https://react.dev/reference/react/hooks) - Complete reference for all built-in hooks
* [Introducing Hooks](https://react.dev/learn#using-hooks) - Official guide to hooks
* [Rules of Hooks](https://react.dev/warnings/invalid-hook-call-warning) - Important rules for using hooks correctly
* [Building Your Own Hooks](https://react.dev/learn/reusing-logic-with-custom-hooks) - Creating custom hooks

**Key Concepts:**

* **Functional Components Only**: Hooks work only in functional components, not class components
* **Rules of Hooks**: 
  * Only call hooks at the top level (not inside loops, conditions, or nested functions)
  * Only call hooks from React functional components or custom hooks
* **Naming Convention**: All hooks start with "use" (e.g., `useState`, `useEffect`, `useCustomHook`)
* **Composition**: Hooks can be combined and composed to create custom hooks for reusable logic

**Why Use Hooks:**

* **Simpler Code**: Functional components are shorter and easier to understand than class components
* **Reusable Logic**: Custom hooks allow sharing stateful logic between components
* **Better Organization**: Related logic stays together instead of being split across lifecycle methods
* **No `this` Keyword**: Eliminates confusion about `this` binding in JavaScript
* **Modern React**: The recommended way to write React components

**React Built-in Hooks Overview:**

| Hook | Purpose | Common Use Cases |
|------|---------|------------------|
| **`useState`** | Add state to functional components | Interactive UI, form inputs, toggles, counters |
| **`useEffect`** | Perform side effects after render | API calls, subscriptions, timers, event listeners |
| **`useContext`** | Access React Context values | Global state, themes, auth, avoiding prop drilling |
| **`useMemo`** | Memoize expensive calculations | Heavy computations, sorting/filtering large arrays |
| **`useRef`** | Access DOM or persist mutable values | Focus management, DOM measurements, previous values |
| **`useReducer`** | Manage complex state logic | Complex state objects, state machines, Redux-like patterns |
| **`useCallback`** | Memoize callback functions | Optimizing child re-renders, stable function references |
| **`useLayoutEffect`** | Synchronous DOM updates before paint | DOM measurements, preventing visual flicker |
| **`useImperativeHandle`** | Customize ref exposure to parent | Custom component APIs, controlled imperative actions |
| **`useDebugValue`** | Display custom hook debug info | Custom hook debugging in React DevTools |
| **`useDeferredValue`** | Defer updating non-urgent values | Debouncing expensive renders, background updates |
| **`useTransition`** | Mark state updates as non-urgent | Keeping UI responsive during heavy updates |
| **`useId`** | Generate unique IDs for accessibility | Form labels, ARIA attributes, SSR-safe IDs |
| **`useSyncExternalStore`** | Subscribe to external stores | Redux, Zustand, custom state managers |
| **`useInsertionEffect`** | Insert styles before DOM reads | CSS-in-JS libraries (styled-components, emotion) |


---

##### useState Hook

`useState` is the most fundamental hook that adds state management to functional components. It returns an array with two elements: the current state value and a function to update it.

**Syntax:**
```jsx
const [state, setState] = useState(initialValue);
```

**Key Points:**
* Manages component-local state that persists across re-renders
* Initial value can be any type: string, number, boolean, object, array
* State updates trigger component re-renders
* State updates are asynchronous
* Use functional updates when new state depends on previous state: `setState(prev => prev + 1)`
* Each `useState` call creates independent state
* Essential for interactive components (forms, toggles, counters, etc.)

**When to use**: Any time component needs to remember data between renders

**Documentation:** [useState Reference](https://react.dev/reference/react/useState)

---

**Syntax:**
```jsx
const [state, setState] = useState(initialValue);
```

**Example:**

```jsx
import { useState } from 'react';
import './hooks.css';

function UseState() {
  // Example 1: Counter (number state)
  const [count, setCount] = useState(0);
  
  // Example 2: Text input (string state)
  const [name, setName] = useState('');
  
  // Example 3: Toggle (boolean state)
  const [isVisible, setIsVisible] = useState(false);

  return (
    <div className="hook-example-section">
      <h3>useState Examples</h3>
      
      {/* Example 1: Counter */}
      <div className="hook-example-section">
        <p>Count: {count}</p>
        <button onClick={() => setCount(count + 1)}>Increment</button>
        <button onClick={() => setCount(count - 1)} className="hook-button-spacing">Decrement</button>
        <button onClick={() => setCount(0)} className="hook-button-spacing">Reset</button>
      </div>

      {/* Example 2: Text Input */}
      <div className="hook-example-section">
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="Enter your name"
        />
        <p>Hello, {name || 'Guest'}!</p>
      </div>

      {/* Example 3: Toggle Visibility */}
      <div className="hook-example-section">
        <button onClick={() => setIsVisible(!isVisible)}>
          {isVisible ? 'Hide' : 'Show'} Content
        </button>
        {isVisible && <p>This content is now visible!</p>}
      </div>
    </div>
  );
}

export default UseState;
```

---

##### useEffect Hook

`useEffect` lets you perform side effects in functional components. Side effects are operations that interact with the outside world (API calls, subscriptions, timers, DOM updates).

**Syntax:**
```jsx
useEffect(() => {
  // Effect code here
  return () => {
    // Cleanup code here (optional)
  };
}, [dependencies]);
```

**Key Points:**
* Runs after the component renders to the screen (after DOM updates)
* Can return cleanup function to prevent memory leaks
* Dependencies array controls when effect runs:
  * Empty array `[]` - runs once after initial render
  * No array - runs after every render
  * `[dep1, dep2]` - runs when dependencies change
* Cleanup function runs before component unmounts and before next effect
* Handles operations that interact with the outside world

**When to use**: Data fetching, event listeners, subscriptions, manual DOM manipulation, logging, timers

**Documentation:** [useEffect Reference](https://react.dev/reference/react/useEffect)

**Example:**

```jsx
import { useState, useEffect } from 'react';
import './hooks.css';

function UseEffect() {
  const [posts, setPosts] = useState([]);
  const [selectedPostId, setSelectedPostId] = useState('');
  const [postDetails, setPostDetails] = useState(null);
  const [loading, setLoading] = useState(true);
  const [detailsLoading, setDetailsLoading] = useState(false);

  // Effect 1: Fetch list of posts when component mounts
  useEffect(() => {
    fetch('https://jsonplaceholder.typicode.com/posts?_limit=10')
      .then(response => response.json())
      .then(data => {
        setPosts(data);
        setLoading(false);
      })
      .catch(err => {
        console.error('Error fetching posts:', err);
        setLoading(false);
      });
  }, []); // Empty array = runs once when component mounts

  // Effect 2: Fetch post details when selectedPostId changes
  useEffect(() => {
    if (!selectedPostId) {
      setPostDetails(null);
      return;
    }

    setDetailsLoading(true);
    
    // Fetch post details and comments
    Promise.all([
      fetch(`https://jsonplaceholder.typicode.com/posts/${selectedPostId}`).then(r => r.json()),
      fetch(`https://jsonplaceholder.typicode.com/posts/${selectedPostId}/comments`).then(r => r.json())
    ])
      .then(([post, comments]) => {
        setPostDetails({ ...post, comments });
        setDetailsLoading(false);
      })
      .catch(err => {
        console.error('Error fetching details:', err);
        setDetailsLoading(false);
      });
  }, [selectedPostId]); // Runs whenever selectedPostId changes

  if (loading) return <p>Loading posts...</p>;

  return (
    <div className="hook-example-section">
      <h3>useEffect Example - Fetching Data with Dependencies</h3>
      
      <div className="use-effect-container">
        <label htmlFor="post-select" className="use-effect-label">Select a post: </label>
        <select 
          id="post-select"
          value={selectedPostId} 
          onChange={(e) => setSelectedPostId(e.target.value)}
          className="use-effect-select"
        >
          <option value="">-- Choose a post --</option>
          {posts.map(post => (
            <option key={post.id} value={post.id}>
              {post.title}
            </option>
          ))}
        </select>
      </div>

      {detailsLoading && <p>Loading details...</p>}

      {postDetails && !detailsLoading && (
        <div className="use-effect-details">
          <h4>{postDetails.title}</h4>
          <p><strong>Post ID:</strong> {postDetails.id}</p>
          <p><strong>Description:</strong> {postDetails.body}</p>
          
          <h5>Comments ({postDetails.comments.length}):</h5>
          <ul className="use-effect-comments">
            {postDetails.comments.map(comment => (
              <li key={comment.id} className="use-effect-comment-item">
                <strong>{comment.name}</strong> <span className="use-effect-comment-email">({comment.email})</span>
                <p className="use-effect-comment-body">{comment.body}</p>
              </li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
}

export default UseEffect;
```

---

##### useContext Hook

`useContext` is a React Hook that lets you read and subscribe to context from your component. Context provides a way to share data across the component tree without having to manually pass props through every level of components (avoiding "prop drilling").

**Documentation:** [useContext Reference](https://react.dev/reference/react/useContext)


**The Problem: Prop Drilling**

In React's normal data flow, data flows down from parent to child via props. This becomes cumbersome when data needs to travel through many component levels, especially when intermediate components don't use the data:

```jsx
// Prop Drilling Problem
<App user={user}>
  // ParentComponent doesn't need user, but must receive it
  <ParentComponent user={user}>
    // MiddleComponent doesn't need user, but must receive it  
    <MiddleComponent user={user}>
      // GrandchildComponent finally uses it!
      <GrandchildComponent user={user} />
```

```jsx
// Context Solution
import { createContext, useContext } from 'react';

// Context created ONCE - this object is shared across all components
const UserContext = createContext();

// App provides the data
function App() {
  const user = { name: "Jose", email: "jose@email.com" };
  
  return (
    // Provider uses UserContext to share data
    <UserContext.Provider value={user}>
      <ParentComponent />
    </UserContext.Provider>
  );
}

function ParentComponent() {
  // No props needed!
  return <MiddleComponent />;
}

function MiddleComponent() {
  // No props needed!
  return <GrandchildComponent />;
}

function GrandchildComponent() {
  // Consumer uses THE SAME UserContext object to access data
  const user = useContext(UserContext);
  return <div>Welcome, {user.name}!</div>;
}
```

**Critical Point:** The `UserContext` object created by `createContext()` must be the **same object** used by both:
- The `<UserContext.Provider>` (to share data)
- The `useContext(UserContext)` (to consume data)

If you create two separate contexts (even with the same name), they won't work together. This is why contexts are usually:
1. Created in a separate file
2. Exported: `export const UserContext = createContext()`
3. Imported wherever needed: `import { UserContext } from './UserContext'`

---

**How Context Works: Three Core Concepts**

**1. Create Context** - Define what data you want to share

The context object itself is created using `createContext()`. This is typically done once at the module level:

```jsx
import { createContext } from 'react';

// Create a context with optional default value
const MyContext = createContext(defaultValue);
```

- **Context object**: The result of `createContext()` is a context object
- **Default value**: Optional; used only when a component has no matching Provider above it in the tree
- **Typically exported**: So other files can import and use it

**2. Provide Context** - Make data available to components

A Provider component wraps the part of your component tree that needs access to the context:

```jsx
<MyContext.Provider value={actualData}>
  {/* All children can access actualData */}
  <ChildComponents />
</MyContext.Provider>
```

- **Provider component**: Every context object comes with a `Provider` component
- **value prop**: The data you want to share (can be any type: object, array, function, primitive)
- **Component tree**: Only components inside the Provider can access the context
- **Value changes**: When value changes, all consuming components re-render

**3. Consume Context** - Read the data in child components

Any component inside the Provider can read the context using `useContext()`:

```jsx
import { useContext } from 'react';

function ChildComponent() {
  const value = useContext(MyContext);
  // Now you can use value
  return <div>{value.someProperty}</div>;
}
```

**Step-by-Step: Building with Context**

**Step 1: Create the Context**

```jsx
// Usually in a separate file, e.g., UserContext.js
import { createContext } from 'react';

export const UserContext = createContext(null); // null is the default value
```

---

**Key Concepts to Understand**

**Data Flow:**
- Context doesn't "push" data to components
- Components that call `useContext()` "pull" the current value
- When value changes, React notifies subscribed components to re-render

**Re-rendering Behavior:**
- All components using `useContext()` re-render when the context value changes
- This happens even if the component only uses part of the value
- Optimize with `useMemo` for the value object if needed

**Provider Hierarchy:**
- You can have multiple Providers for the same context
- Components receive value from the nearest Provider above them
- Providers can be nested for different scopes

**Multiple Contexts:**
- Components can consume multiple contexts
- Just call `useContext()` multiple times with different context objects

```jsx
function MyComponent() {
  const theme = useContext(ThemeContext);
  const user = useContext(UserContext);
  const settings = useContext(SettingsContext);
  
  // Use all three contexts
}
```

---

**How Child Components Can Modify Context Data**

**The Problem:**
Child components can **read** context data, but how do they **change** it?

**The Solution:**
Pass **both data AND setter functions** through the context value!

**Pattern 1: Simple - Pass setState function**

The simplest approach is to pass the setState function directly through context:

```jsx
// 1. Create context
const UserContext = createContext();

// 2. Provider component with state
function App() {
  const [user, setUser] = useState({ name: 'Jose', email: 'jose@email.com' });
  
  // Pass BOTH the data AND the setter function
  const value = { user, setUser };
  
  return (
    <UserContext.Provider value={value}>
      <UserDisplay />
      <UserControls />
    </UserContext.Provider>
  );
}

// 3. Child components can modify the data
function UserDisplay() {
  const { user } = useContext(UserContext);
  return (
    <div>
      <h2>Welcome, {user.name}!</h2>
      <p>Email: {user.email}</p>
    </div>
  );
}

function UserControls() {
  const { user, setUser } = useContext(UserContext);
  
  return (
    <div>
      <button onClick={() => setUser({ ...user, name: 'Maria' })}>
        Change to Maria
      </button>
      <button onClick={() => setUser({ ...user, name: 'Carlos' })}>
        Change to Carlos
      </button>
      <button onClick={() => setUser({ name: 'Jose', email: 'jose@email.com' })}>
        Reset
      </button>
    </div>
  );
}
```

**Drawbacks of this approach:**
- Children need to know **how** to update state (implementation details)
- Duplicated logic if multiple components update the same way
- Risk of invalid state updates
- Harder to maintain when logic changes

**Pattern 2: Better - Pass specific action functions**

Instead of passing the raw setState function, create specific action functions that encapsulate the logic:

```jsx
// 1. Create context
const UserContext = createContext();

// 2. Provider component with specific actions
function App() {
  const [user, setUser] = useState({ name: 'Jose', email: 'jose@email.com' });
  
  // Specific action functions (better than passing setUser directly)
  const updateName = (newName) => setUser(prev => ({ ...prev, name: newName }));
  const updateEmail = (newEmail) => setUser(prev => ({ ...prev, email: newEmail }));
  const resetUser = () => setUser({ name: 'Jose', email: 'jose@email.com' });
  
  // Pass data and actions
  const value = { user, updateName, updateEmail, resetUser };
  
  return (
    <UserContext.Provider value={value}>
      <UserDisplay />
      <UserControls />
    </UserContext.Provider>
  );
}

// 3. Components use specific actions
function UserDisplay() {
  const { user } = useContext(UserContext);
  return (
    <div>
      <h2>Welcome, {user.name}!</h2>
      <p>Email: {user.email}</p>
    </div>
  );
}

function UserControls() {
  const { updateName, updateEmail, resetUser } = useContext(UserContext);
  
  return (
    <div>
      <button onClick={() => updateName('Jose Maria')}>Change to Maria</button>
      <button onClick={() => updateName('Leila')}>Change to Leila</button>
      <button onClick={() => resetUser()}>Reset</button>
    </div>
  );
}
```

**Why this is better:**
- **Encapsulation**: Logic is in one place (the Provider)
- **Intent clarity**: Function names describe what they do (`updateName` vs `setUser({ ...user, name: ... })`)
- **Less error-prone**: Children can't accidentally set invalid state
- **Easier to maintain**: Change implementation in one place
---

**When to Use Context vs Props**

| Scenario | Use Props | Use Context |
|----------|-----------|-------------|
| **Data depth** | 1-2 levels | 3+ levels deep |
| **Number of consumers** | Few components | Many components at different levels |
| **Relationship** | Clear parent-child | Components scattered in tree |
| **Data nature** | Component-specific | Global or semi-global |
| **Frequency of change** | Doesn't matter | Consider performance for frequent changes |

**Common Use Cases for Context:**
- **Theme**: Light/dark mode across entire app
- **Authentication**: Current user info and login state
- **Localization**: Current language/translations
- **Shopping Cart**: Cart items accessible from anywhere
- **App Settings**: Global configuration preferences
- **Responsive**: Screen size/device info

**Best Practices:**

- **Don't overuse context**: For simple parent-child communication (1-2 levels), props are simpler and more explicit
- **Separate contexts**: Create separate contexts for different concerns (don't put everything in one giant context)
- **Provider placement**: Place Providers only where needed, not always at the root
- **Memoize values**: Use `useMemo` for context values to prevent unnecessary re-renders

**Example:**

- This example demonstrates a use case of `useContext` with a phrase analysis application that calculates word and character frequencies.
- It shows both approaches side-by-side:
  - **WITHOUT useContext** (prop drilling)
  - **WITH useContext** (avoiding prop drilling).

**Component Hierarchy:**

```
WITHOUT useContext (Messy - Prop Drilling Required)
├── MainPage (owns phrase state, passes props down)
│   ├── Phrase (receives phrase + updatePhrase as props)
│   └── Container (receives phrase + updatePhrase as props, doesn't use them!)
│       ├── WordsFrequency (receives phrase + updatePhrase from Container)
│       └── CharactersFrequency (receives phrase + updatePhrase from Container)

WITH useContext (Clean - No Prop Drilling)
├── MainPage (Provider - owns phrase state, provides context)
│   ├── Phrase (Consumer - edits phrase via context)
│   └── Container (Wrapper - no props needed!)
│       ├── WordsFrequency (Consumer - reads/updates via context)
│       └── CharactersFrequency (Consumer - reads/updates via context)
```

**Key Differences:**

| Aspect | WITH useContext | WITHOUT useContext |
|--------|-----------------|---------------------|
| **Container Component** | No props needed - just renders children | Must receive and pass props it doesn't use |
| **Data Access** | Components pull data from context | Props must be passed through every level |
| **Code Clarity** | Clean, direct access to needed data | Prop drilling through intermediate components |
| **Maintenance** | Easy - change Provider, consumers work unchanged | Hard - add/remove props at every level |

**How It Works:**

1. **MainPage** creates `PhraseContext` and provides:
   - `phrase` (string): The current phrase to analyze
   - `updatePhrase` (function): Updates the phrase

2. **Phrase Component** allows real-time editing via textarea

3. **WordsFrequency Component**:
   - Calculates word frequency
   - Displays total/unique word counts
   - Shows frequency table sorted by count

4. **CharactersFrequency Component**:
   - Calculates character frequency (letters only)
   - Displays total/unique letter counts
   - Shows frequency table sorted by count

5. **Real-time Updates**: Typing in any textarea updates all components instantly

**Example Files:**

The complete implementation is available in the repository:

**WITH useContext** (Recommended Approach):
- `_12_React/react-demo-app/src/components/Hooks/UseContext/WithUseContext/MainPage.jsx`
- `_12_React/react-demo-app/src/components/Hooks/UseContext/WithUseContext/Phrase.jsx`
- `_12_React/react-demo-app/src/components/Hooks/UseContext/WithUseContext/Container.jsx`
- `_12_React/react-demo-app/src/components/Hooks/UseContext/WithUseContext/WordsFrequency.jsx`
- `_12_React/react-demo-app/src/components/Hooks/UseContext/WithUseContext/CharactersFrequency.jsx`

**WITHOUT useContext** (Prop Drilling Approach):
- `_12_React/react-demo-app/src/components/Hooks/UseContext/WithoutUseContext/MainPage.jsx`
- `_12_React/react-demo-app/src/components/Hooks/UseContext/WithoutUseContext/Phrase.jsx`
- `_12_React/react-demo-app/src/components/Hooks/UseContext/WithoutUseContext/Container.jsx`
- `_12_React/react-demo-app/src/components/Hooks/UseContext/WithoutUseContext/WordsFrequency.jsx`
- `_12_React/react-demo-app/src/components/Hooks/UseContext/WithoutUseContext/CharactersFrequency.jsx`

**Shared Styling:**
- `_12_React/react-demo-app/src/components/Hooks/UseContext/useContext.css`

**The Problem Solved:**

Without context, the `Container` component is forced to:
```jsx
// Container must receive props it doesn't use, just to pass them down
function Container({ phrase, updatePhrase }) {
  return (
    <div className="frequency-container">
      <WordsFrequency phrase={phrase} updatePhrase={updatePhrase} />
      <CharactersFrequency phrase={phrase} updatePhrase={updatePhrase} />
    </div>
  );
}
```

With context, the `Container` becomes clean:
```jsx
// Container doesn't need any props - children access context directly
function Container() {
  return (
    <div className="frequency-container">
      <WordsFrequency />
      <CharactersFrequency />
    </div>
  );
}
```

This demonstrates the core benefit of `useContext`: **avoiding prop drilling** by allowing deeply nested components to access shared state directly without forcing intermediate components to pass props they don't use.

---

##### useMemo Hook

`useMemo` is a React Hook that **memoizes** (caches) the result of a calculation between re-renders. It returns a cached value and only recalculates when one of its dependencies changes.

**What is Memoization?**

Memoization is an optimization technique that stores the result of an expensive computation and returns the cached result when the same inputs occur again, instead of recalculating.

**When to Use useMemo:**

React components re-render when:
- State changes
- Props change
- Parent component re-renders

During each re-render, **all code inside the component function runs again**, including expensive calculations. `useMemo` prevents unnecessary recalculations by caching results.

**Documentation:** [useMemo Reference](https://react.dev/reference/react/useMemo)

**Syntax:**

```jsx
const result = useMemo(
  () => expensiveFunction(input), // Calculation function (returns a value)
  [input] // Dependencies array
);
```

- **First argument**: A function that returns the value to cache
- **Second argument**: Array of dependencies to watch
- **Returns**: The cached value (not a function!)

1. **First render**: Executes the calculation function and caches the result
2. **Subsequent re-renders**: 
   - If dependencies **haven't changed** → returns cached value (fast!)
   - If dependencies **have changed** → re-runs calculation and caches new result

**Dependencies Array Behavior:**

```jsx
const cachedValue = useMemo(() => {
  // Expensive calculation here
  return computeExpensiveValue(a, b);
}, [a, b]); // Dependencies array - recalculate only when a or b changes
```

| Dependencies | Behavior | Use Case |
|--------------|----------|----------|
| `[a, b]` | Recalculates when `a` or `b` changes | Most common - recalculate on specific changes |
| `[]` | Calculates once, never again | One-time expensive initialization |
| No array | Recalculates on every render | ❌ Don't do this - defeats the purpose! |

**When to Use useMemo:**

**Use when:**
- Expensive calculations (complex math, large data processing)
- Filtering/sorting/transforming large arrays
- Creating objects/arrays passed as props to child components (prevents unnecessary re-renders)
- Calculations that depend on specific values

**Don't use when:**
- Simple calculations (adding numbers, string concatenation)
- Values that change on every render anyway
- Premature optimization (measure first!)

**Important Notes:**

- `useMemo` returns a **value**, not a function
- Use `useCallback` for memoizing functions instead
- Memoization adds overhead - only use for truly expensive operations
- React may discard memoized values during memory pressure (it's an optimization hint, not a guarantee)

---

**Example - Todo Statistics with Memoized Processing:**

This example demonstrates `useMemo` by fetching 200 todos from JSONPlaceholder API and performing expensive statistical calculations that only run when the data actually changes.

```jsx
import { useState, useEffect, useMemo } from 'react';
import './hooks.css';

function UseMemo() {
  const [todos, setTodos] = useState([]);
  const [loading, setLoading] = useState(true);
  const [refreshTrigger, setRefreshTrigger] = useState(0);
  const [renderCount, setRenderCount] = useState(0);

  // Fetch todos from API on component mount or when refreshTrigger changes
  useEffect(() => {
    const fetchTodos = async () => {
      setLoading(true);
      try {
        const response = await fetch('https://jsonplaceholder.typicode.com/todos');
        const data = await response.json();
        setTodos(data);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching todos:', error);
        setLoading(false);
      }
    };

    fetchTodos();
  }, [refreshTrigger]); // Re-fetch when refreshTrigger changes

  // useMemo: Process todos to generate statistics
  // This expensive calculation only runs when todos change, not on every render
  const todoStats = useMemo(() => {
    console.log('📊 Processing todo statistics...');
    const completed = todos.filter(todo => todo.completed).length;
    const pending = todos.length - completed;
    const completionRate = todos.length > 0 ? ((completed / todos.length) * 100).toFixed(1) : 0;

    // Group todos by userId using reduce
    // summary starts as an empty object {}
    // For each todo, we create/update a user entry with their stats
    const byUser = todos.reduce((summary, todo) => {
      // If this user doesn't exist in accumulator yet, initialize their stats
      if (!summary[todo.userId]) {
        summary[todo.userId] = { completed: 0, pending: 0, total: 0 };
      }
      // Increment total count for this user
      summary[todo.userId].total++;
      // Increment either completed or pending count based on todo status
      if (todo.completed) {
        summary[todo.userId].completed++;
      } else {
        summary[todo.userId].pending++;
      }
      // Return accumulator for next iteration
      return summary;
    }, {}); // Initial value: empty object

    return {
      total: todos.length,
      completed,
      pending,
      completionRate,
      byUser
    };
  }, [todos]); // Only recalculate when todos change

  if (loading) return <div className="hook-example-section">Loading todos...</div>;

  return (
    <div className="hook-example-section">
      <h3>useMemo Example - Todo Statistics</h3>
      
      <div className="hook-example-section">
        <button onClick={() => setRefreshTrigger(refreshTrigger + 1)}>
          Refresh Todos
        </button>
        <button onClick={() => setRenderCount(renderCount + 1)} style={{ marginLeft: '10px' }}>
          Force Re-render ({renderCount})
        </button>
        <p>
          <small>
            💡 "Refresh Todos" re-fetches and recalculates | "Force Re-render" just re-renders (check console)
          </small>
        </p>

        <div className="use-memo-stats-grid">
          <div className="use-memo-stat-card total">
            <div className="use-memo-stat-value">{todoStats.total}</div>
            <div className="use-memo-stat-label">Total Todos</div>
          </div>
          <div className="use-memo-stat-card completed">
            <div className="use-memo-stat-value">{todoStats.completed}</div>
            <div className="use-memo-stat-label">Completed</div>
          </div>
          <div className="use-memo-stat-card pending">
            <div className="use-memo-stat-value">{todoStats.pending}</div>
            <div className="use-memo-stat-label">Pending</div>
          </div>
          <div className="use-memo-stat-card rate">
            <div className="use-memo-stat-value">{todoStats.completionRate}%</div>
            <div className="use-memo-stat-label">Completion Rate</div>
          </div>
        </div>

        <h4>Statistics by User</h4>
        <div className="use-memo-todos-container use-memo-table-container">
          <table className="use-memo-table">
            <thead>
              <tr>
                <th>User ID</th>
                <th>Total</th>
                <th>Completed</th>
                <th>Pending</th>
                <th>Completion %</th>
              </tr>
            </thead>
            <tbody>
              {Object.entries(todoStats.byUser).map(([userId, stats]) => (
                <tr key={userId}>
                  <td>User {userId}</td>
                  <td className="center">{stats.total}</td>
                  <td className="center completed-text">{stats.completed}</td>
                  <td className="center pending-text">{stats.pending}</td>
                  <td className="center">
                    {((stats.completed / stats.total) * 100).toFixed(1)}%
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

export default UseMemo;
```

**Key Demonstration Points:**

- **useEffect** handles the side effect (API fetch) and runs when `refreshTrigger` changes
- **useMemo** handles expensive computation (filtering, grouping, calculating stats) and only runs when `todos` changes
- **"Refresh Todos" button**: Changes `refreshTrigger` → triggers useEffect → fetches new data → todos change → useMemo recalculates
- **"Force Re-render" button**: Changes `renderCount` → component re-renders → useMemo does NOT recalculate
