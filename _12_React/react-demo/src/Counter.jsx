// Counter.js - useState Hook Example
import React, { useState } from 'react';
import './Counter.css';

/**
 * Counter Component
 * 
 * Demonstrates:
 * - useState hook for state management
 * - Event handling
 * - Multiple state variables
 * - Conditional rendering
 * - Function components with state
 */
function Counter() {
  // State for the counter value
  const [count, setCount] = useState(0);
  
  // State for step size
  const [step, setStep] = useState(1);
  
  // State for tracking if counter is active
  const [isActive, setIsActive] = useState(true);

  // Event handlers
  const increment = () => {
    if (isActive) {
      setCount(count + step);
    }
  };

  const decrement = () => {
    if (isActive) {
      setCount(count - step);
    }
  };

  const reset = () => {
    setCount(0);
  };

  const toggleActive = () => {
    setIsActive(!isActive);
  };

  // Determine counter status
  const getCounterStatus = () => {
    if (count === 0) return 'neutral';
    if (count > 0) return 'positive';
    return 'negative';
  };

  return (
    <div className={`counter ${getCounterStatus()}`}>
      <h2>React Counter</h2>
      
      <div className="counter-display">
        <span className="count-value">{count}</span>
        <span className="count-label">
          {count === 1 || count === -1 ? 'count' : 'counts'}
        </span>
      </div>

      <div className="step-control">
        <label htmlFor="step">Step size:</label>
        <input
          id="step"
          type="number"
          value={step}
          onChange={(e) => setStep(parseInt(e.target.value) || 1)}
          min="1"
          max="10"
        />
      </div>

      <div className="button-group">
        <button 
          onClick={decrement} 
          disabled={!isActive}
          className="btn btn-decrement"
        >
          - {step}
        </button>
        
        <button 
          onClick={reset} 
          className="btn btn-reset"
        >
          Reset
        </button>
        
        <button 
          onClick={increment} 
          disabled={!isActive}
          className="btn btn-increment"
        >
          + {step}
        </button>
      </div>

      <div className="controls">
        <button 
          onClick={toggleActive} 
          className={`btn btn-toggle ${isActive ? 'active' : 'inactive'}`}
        >
          {isActive ? 'Pause' : 'Resume'}
        </button>
      </div>

      <div className="info">
        <p>Status: <span className="status">{isActive ? 'Active' : 'Paused'}</span></p>
        <p>Current step: <span className="step-display">{step}</span></p>
      </div>
    </div>
  );
}

export default Counter;
