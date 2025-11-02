import { useState, useCallback, memo } from 'react';

// Optimized child component that only re-renders when props change
const ChildComponent = memo(({ onClick, title }) => {
  console.log(`Rendering ${title}`);
  return (
    <div style={{ padding: '10px', margin: '10px 0', border: '1px solid #ddd' }}>
      <h4>{title}</h4>
      <button onClick={onClick}>Click Me</button>
    </div>
  );
});

// List item component
const ListItem = memo(({ item, onDelete, onToggle }) => {
  console.log(`Rendering ListItem: ${item.text}`);
  return (
    <li style={{ marginBottom: '8px' }}>
      <input
        type="checkbox"
        checked={item.completed}
        onChange={() => onToggle(item.id)}
        style={{ marginRight: '8px' }}
      />
      <span style={{ textDecoration: item.completed ? 'line-through' : 'none' }}>
        {item.text}
      </span>
      <button onClick={() => onDelete(item.id)} style={{ marginLeft: '8px' }}>Delete</button>
    </li>
  );
});

function UseCallbackExamples() {
  const [count, setCount] = useState(0);
  const [items, setItems] = useState([
    { id: 1, text: 'Learn React', completed: false },
    { id: 2, text: 'Learn Hooks', completed: false },
    { id: 3, text: 'Build Project', completed: false }
  ]);
  const [inputValue, setInputValue] = useState('');

  // Example 1: Without useCallback - function recreated on every render
  // This would cause ChildComponent to re-render even when count doesn't change
  const handleClickWithoutCallback = () => {
    console.log('Clicked without callback!', count);
  };

  // Example 2: With useCallback - function only recreated when count changes
  const handleClickWithCallback = useCallback(() => {
    console.log('Clicked with callback!', count);
  }, [count]);

  // Example 3: Callback with no dependencies - created once
  const handleClickStable = useCallback(() => {
    console.log('Stable callback - never recreated');
  }, []);

  // Example 4: Complex callback for list operations
  const handleDeleteItem = useCallback((id) => {
    setItems(prevItems => prevItems.filter(item => item.id !== id));
  }, []); // No dependencies - uses functional state update

  const handleToggleItem = useCallback((id) => {
    setItems(prevItems =>
      prevItems.map(item =>
        item.id === id ? { ...item, completed: !item.completed } : item
      )
    );
  }, []);

  const handleAddItem = useCallback(() => {
    if (inputValue.trim()) {
      setItems(prevItems => [
        ...prevItems,
        { id: Date.now(), text: inputValue, completed: false }
      ]);
      setInputValue('');
    }
  }, [inputValue]); // Depends on inputValue

  return (
    <div>
      <h3>useCallback Examples</h3>

      {/* Trigger re-renders */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Trigger Re-render</h4>
        <p>Count: {count}</p>
        <button onClick={() => setCount(count + 1)}>Increment</button>
        <p><small>Watch console to see which components re-render</small></p>
      </div>

      {/* Compare with/without useCallback */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>❌ Without useCallback</h4>
        <ChildComponent
          onClick={handleClickWithoutCallback}
          title="Re-renders on EVERY parent render"
        />
      </div>

      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>✅ With useCallback (depends on count)</h4>
        <ChildComponent
          onClick={handleClickWithCallback}
          title="Only re-renders when count changes"
        />
      </div>

      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>✅ Stable Callback (no dependencies)</h4>
        <ChildComponent
          onClick={handleClickStable}
          title="Never re-renders (stable callback)"
        />
      </div>

      {/* Todo list with optimized callbacks */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Optimized Todo List</h4>
        <div>
          <input
            type="text"
            value={inputValue}
            onChange={(e) => setInputValue(e.target.value)}
            onKeyPress={(e) => e.key === 'Enter' && handleAddItem()}
            placeholder="Add item..."
            style={{ marginRight: '8px', padding: '4px' }}
          />
          <button onClick={handleAddItem}>Add</button>
        </div>

        <ul style={{ listStyle: 'none', padding: 0 }}>
          {items.map(item => (
            <ListItem
              key={item.id}
              item={item}
              onDelete={handleDeleteItem}
              onToggle={handleToggleItem}
            />
          ))}
        </ul>
        <p><small>Each list item only re-renders when its data changes</small></p>
      </div>

      {/* Explanation */}
      <div style={{ marginBottom: '20px', padding: '10px', backgroundColor: '#f0f0f0' }}>
        <h4>When to use useCallback?</h4>
        <ul style={{ textAlign: 'left' }}>
          <li>Passing callbacks to optimized child components (with React.memo)</li>
          <li>Callbacks used as dependencies in other hooks</li>
          <li>Event handlers for expensive operations</li>
          <li>Preventing unnecessary re-creations of functions</li>
          <li><strong>Don't overuse:</strong> Only optimize when there's a performance issue</li>
        </ul>
      </div>
    </div>
  );
}

export default UseCallbackExamples;
