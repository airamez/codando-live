import { useState } from 'react';

function UseStateExamples() {
  // Simple counter
  const [count, setCount] = useState(0);

  // String state
  const [name, setName] = useState('');

  // Boolean state
  const [isVisible, setIsVisible] = useState(false);

  // Object state
  const [user, setUser] = useState({ name: '', age: 0 });

  // Array state
  const [items, setItems] = useState([]);

  // Lazy initialization - function runs only once
  const [expensiveValue] = useState(() => {
    console.log('Computing expensive initial value...');
    return Array.from({ length: 1000 }, (_, i) => i);
  });

  // Functional update - when new state depends on previous
  const incrementCount = () => {
    setCount(prevCount => prevCount + 1);
  };

  // Multiple updates in a row - use functional form
  const incrementByThree = () => {
    setCount(prev => prev + 1);
    setCount(prev => prev + 1);
    setCount(prev => prev + 1);
  };

  // Update object state immutably
  const updateUser = () => {
    setUser(prevUser => ({
      ...prevUser,
      age: prevUser.age + 1
    }));
  };

  // Update array state immutably
  const addItem = (newItem) => {
    setItems(prevItems => [...prevItems, newItem]);
  };

  const removeItem = (index) => {
    setItems(prevItems => prevItems.filter((_, i) => i !== index));
  };

  return (
    <div>
      <h3>useState Examples</h3>

      {/* Counter */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Counter</h4>
        <p>Count: {count}</p>
        <button onClick={() => setCount(count + 1)}>Increment</button>
        <button onClick={incrementCount} style={{ marginLeft: '8px' }}>Increment (Functional)</button>
        <button onClick={incrementByThree} style={{ marginLeft: '8px' }}>Increment by 3</button>
        <button onClick={() => setCount(0)} style={{ marginLeft: '8px' }}>Reset</button>
      </div>

      {/* String input */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>String Input</h4>
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="Enter your name"
        />
        <p>Hello, {name || '(empty)'}!</p>
      </div>

      {/* Toggle visibility */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Toggle Visibility</h4>
        <button onClick={() => setIsVisible(!isVisible)}>
          Toggle Content
        </button>
        {isVisible && <p>This content is visible!</p>}
      </div>

      {/* Object state */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Object State</h4>
        <p>User: {user.name || '(no name)'}, Age: {user.age}</p>
        <button onClick={() => setUser({ ...user, name: 'John' })}>
          Set Name to John
        </button>
        <button onClick={updateUser} style={{ marginLeft: '8px' }}>Increment Age</button>
      </div>

      {/* Array state */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Array State</h4>
        <button onClick={() => addItem(`Item ${items.length + 1}`)}>
          Add Item
        </button>
        <ul>
          {items.map((item, index) => (
            <li key={index}>
              {item}
              <button onClick={() => removeItem(index)} style={{ marginLeft: '8px' }}>Remove</button>
            </li>
          ))}
        </ul>
        {items.length === 0 && <p>No items yet</p>}
      </div>

      {/* Lazy initialization */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Lazy Initialization</h4>
        <p>Expensive array length: {expensiveValue.length}</p>
        <p>Check console - initialization only happens once!</p>
      </div>
    </div>
  );
}

export default UseStateExamples;
