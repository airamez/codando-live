import { useRef, useState, useEffect } from 'react';

function UseRefExamples() {
  // Example 1: Accessing DOM elements
  const inputRef = useRef(null);

  // Example 2: Storing mutable values
  const renderCount = useRef(0);
  const previousValue = useRef('');

  // Example 3: Storing timer ID
  const timerRef = useRef(null);

  const [count, setCount] = useState(0);
  const [inputValue, setInputValue] = useState('');
  const [timerCount, setTimerCount] = useState(0);

  // Track render count without causing re-renders
  useEffect(() => {
    renderCount.current += 1;
  });

  // Store previous value
  useEffect(() => {
    previousValue.current = inputValue;
  }, [inputValue]);

  // Example 1: Focus input
  const focusInput = () => {
    inputRef.current.focus();
  };

  // Example 1: Scroll input into view
  const scrollToInput = () => {
    inputRef.current.scrollIntoView({ behavior: 'smooth' });
  };

  // Example 2: Access previous value
  const showPreviousValue = () => {
    alert(`Previous value was: "${previousValue.current}"`);
  };

  // Example 3: Start/stop timer
  const startTimer = () => {
    if (timerRef.current) return; // Already running

    timerRef.current = setInterval(() => {
      setTimerCount(prev => prev + 1);
    }, 1000);
  };

  const stopTimer = () => {
    if (timerRef.current) {
      clearInterval(timerRef.current);
      timerRef.current = null;
    }
  };

  // Cleanup timer on unmount
  useEffect(() => {
    return () => {
      if (timerRef.current) {
        clearInterval(timerRef.current);
      }
    };
  }, []);

  return (
    <div>
      <h3>useRef Examples</h3>

      {/* DOM element access */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>DOM Access</h4>
        <input
          ref={inputRef}
          type="text"
          value={inputValue}
          onChange={(e) => setInputValue(e.target.value)}
          placeholder="Type something..."
          style={{ marginRight: '8px' }}
        />
        <button onClick={focusInput}>Focus Input</button>
        <button onClick={scrollToInput} style={{ marginLeft: '8px' }}>Scroll to Input</button>
      </div>

      {/* Previous value tracking */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Previous Value Tracking</h4>
        <p>Current: {inputValue || '(empty)'}</p>
        <p>Previous: {previousValue.current || '(none)'}</p>
        <button onClick={showPreviousValue}>Alert Previous Value</button>
      </div>

      {/* Render count tracking */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Render Count</h4>
        <p>This component has rendered {renderCount.current} times</p>
        <p>State count: {count}</p>
        <button onClick={() => setCount(count + 1)}>Increment State (triggers re-render)</button>
      </div>

      {/* Timer with ref */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Timer with useRef</h4>
        <p>Timer Count: {timerCount}</p>
        <p>Status: {timerRef.current ? '🟢 Running' : '🔴 Stopped'}</p>
        <button onClick={startTimer}>Start Timer</button>
        <button onClick={stopTimer} style={{ marginLeft: '8px' }}>Stop Timer</button>
        <button onClick={() => setTimerCount(0)} style={{ marginLeft: '8px' }}>Reset Count</button>
      </div>

      {/* Key differences explanation */}
      <div style={{ marginBottom: '20px', padding: '10px', backgroundColor: '#f0f0f0' }}>
        <h4>useState vs useRef</h4>
        <ul style={{ textAlign: 'left' }}>
          <li><strong>useState:</strong> Triggers re-render when updated</li>
          <li><strong>useRef:</strong> Does NOT trigger re-render when .current changes</li>
          <li><strong>useRef:</strong> Persists across renders (like instance variables)</li>
          <li><strong>useRef:</strong> Perfect for DOM references and mutable values</li>
        </ul>
      </div>
    </div>
  );
}

export default UseRefExamples;
