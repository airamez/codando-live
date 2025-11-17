# 8. Props (Properties)

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
