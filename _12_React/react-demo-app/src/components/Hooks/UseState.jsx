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
    <div>
      <h3>useState Example</h3>

      {/* Example 1: Counter */}
      <div className="hook-example-section">
        <h4>Example 1: Counter (Number State)</h4>
        <p>Count: {count}</p>
        <button onClick={() => setCount(count + 1)}>Increment</button>
        <button onClick={() => setCount(count - 1)} className="hook-button-spacing">Decrement</button>
        <button onClick={() => setCount(0)} className="hook-button-spacing">Reset</button>
      </div>

      {/* Example 2: Text Input */}
      <div className="hook-example-section">
        <h4>Example 2: Text Input (String State)</h4>
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
        <h4>Example 3: Toggle (Boolean State)</h4>
        <button onClick={() => setIsVisible(!isVisible)}>
          {isVisible ? 'Hide' : 'Show'} Content
        </button>
        {isVisible && <p>This content is now visible!</p>}
      </div>
    </div>
  );
}

export default UseState;
