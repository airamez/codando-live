// LifecycleDemo.js - useEffect Hook and Component Lifecycle
import React, { useState, useEffect } from 'react';
import './LifecycleDemo.css';

/**
 * LifecycleDemo Component
 * 
 * Demonstrates:
 * - useEffect hook for side effects
 * - Component mounting, updating, and unmounting
 * - Cleanup functions
 * - Multiple useEffect hooks
 * - Dependency arrays
 * - Data fetching patterns
 * - Timer and interval management
 */
function LifecycleDemo() {
  const [count, setCount] = useState(0);
  const [isVisible, setIsVisible] = useState(true);
  const [logs, setLogs] = useState([]);
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(false);

  // Add log entry
  const addLog = (message) => {
    const timestamp = new Date().toLocaleTimeString();
    setLogs(prevLogs => [...prevLogs, `[${timestamp}] ${message}`]);
  };

  // Clear logs
  const clearLogs = () => {
    setLogs([]);
  };

  return (
    <div className="lifecycle-demo">
      <h2>React Lifecycle Demo</h2>
      <p>This demo shows how useEffect works in different scenarios.</p>

      <div className="demo-controls">
        <button onClick={() => setCount(count + 1)} className="btn btn-primary">
          Increment Count ({count})
        </button>
        
        <button 
          onClick={() => setIsVisible(!isVisible)} 
          className="btn btn-secondary"
        >
          {isVisible ? 'Hide' : 'Show'} Timer Component
        </button>

        <button onClick={clearLogs} className="btn btn-warning">
          Clear Logs
        </button>
      </div>

      <div className="demo-content">
        <div className="component-section">
          <h3>Main Component Effects</h3>
          <MainEffectsDemo count={count} onLog={addLog} />
        </div>

        {isVisible && (
          <div className="component-section">
            <h3>Timer Component (Mount/Unmount Demo)</h3>
            <TimerComponent onLog={addLog} />
          </div>
        )}

        <div className="component-section">
          <h3>Data Fetching Demo</h3>
          <DataFetchingDemo onLog={addLog} />
        </div>
      </div>

      <div className="logs-section">
        <h3>Lifecycle Logs</h3>
        <div className="logs-container">
          {logs.length === 0 ? (
            <p className="no-logs">No logs yet. Interact with the components above!</p>
          ) : (
            logs.map((log, index) => (
              <div key={index} className="log-entry">
                {log}
              </div>
            ))
          )}
        </div>
      </div>
    </div>
  );
}

// Component demonstrating various useEffect patterns
function MainEffectsDemo({ count, onLog }) {
  const [name, setName] = useState('');

  // Effect with no dependencies - runs after every render
  useEffect(() => {
    onLog('MainEffectsDemo: Effect with no dependencies ran');
  });

  // Effect with empty dependency array - runs only on mount
  useEffect(() => {
    onLog('MainEffectsDemo: Component mounted (empty dependency array)');
    
    // Cleanup function - runs on unmount
    return () => {
      onLog('MainEffectsDemo: Component will unmount');
    };
  }, []);

  // Effect with dependencies - runs when count changes
  useEffect(() => {
    onLog(`MainEffectsDemo: Count changed to ${count}`);
  }, [count]);

  // Effect with multiple dependencies
  useEffect(() => {
    if (name) {
      onLog(`MainEffectsDemo: Name changed to "${name}"`);
    }
  }, [name]);

  // Effect with cleanup - document title
  useEffect(() => {
    const originalTitle = document.title;
    document.title = `React Demo - Count: ${count}`;
    
    return () => {
      document.title = originalTitle;
    };
  }, [count]);

  return (
    <div className="effects-demo">
      <div className="demo-info">
        <p><strong>Current count:</strong> {count}</p>
        <div className="input-group">
          <label htmlFor="name">Name:</label>
          <input
            id="name"
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            placeholder="Enter your name"
          />
        </div>
        {name && <p><strong>Hello, {name}!</strong></p>}
      </div>
      
      <div className="effect-explanations">
        <h4>useEffect Examples in this component:</h4>
        <ul>
          <li><code>useEffect(() =&gt; {})</code> - Runs after every render</li>
          <li><code>useEffect(() =&gt; {}, [])</code> - Runs only on mount</li>
          <li><code>useEffect(() =&gt; {}, [count])</code> - Runs when count changes</li>
          <li><code>useEffect(() =&gt; {}, [name])</code> - Runs when name changes</li>
        </ul>
      </div>
    </div>
  );
}

// Component demonstrating timer and cleanup
function TimerComponent({ onLog }) {
  const [seconds, setSeconds] = useState(0);
  const [isRunning, setIsRunning] = useState(true);

  // Timer effect with cleanup
  useEffect(() => {
    onLog('TimerComponent: Timer component mounted');
    
    let interval;
    
    if (isRunning) {
      interval = setInterval(() => {
        setSeconds(prevSeconds => prevSeconds + 1);
      }, 1000);
      onLog('TimerComponent: Timer started');
    }

    // Cleanup function
    return () => {
      if (interval) {
        clearInterval(interval);
        onLog('TimerComponent: Timer cleaned up');
      }
    };
  }, [isRunning, onLog]);

  // Component unmount effect
  useEffect(() => {
    return () => {
      onLog('TimerComponent: Component unmounted');
    };
  }, [onLog]);

  const toggleTimer = () => {
    setIsRunning(!isRunning);
    onLog(`TimerComponent: Timer ${!isRunning ? 'started' : 'stopped'}`);
  };

  const resetTimer = () => {
    setSeconds(0);
    onLog('TimerComponent: Timer reset');
  };

  return (
    <div className="timer-component">
      <div className="timer-display">
        <span className="timer-value">{seconds}</span>
        <span className="timer-label">seconds</span>
      </div>
      
      <div className="timer-controls">
        <button onClick={toggleTimer} className="btn btn-primary">
          {isRunning ? 'Pause' : 'Start'}
        </button>
        <button onClick={resetTimer} className="btn btn-secondary">
          Reset
        </button>
      </div>
      
      <p className="timer-status">
        Status: <span className={isRunning ? 'running' : 'paused'}>
          {isRunning ? 'Running' : 'Paused'}
        </span>
      </p>
    </div>
  );
}

// Component demonstrating data fetching with useEffect
function DataFetchingDemo({ onLog }) {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  // Simulate API call
  const fetchUsers = async () => {
    setLoading(true);
    setError(null);
    onLog('DataFetchingDemo: Starting data fetch...');

    try {
      // Simulate network delay
      await new Promise(resolve => setTimeout(resolve, 1500));
      
      // Simulate API response
      const mockUsers = [
        { id: 1, name: 'Alice Johnson', email: 'alice@example.com' },
        { id: 2, name: 'Bob Smith', email: 'bob@example.com' },
        { id: 3, name: 'Carol Davis', email: 'carol@example.com' }
      ];
      
      setUsers(mockUsers);
      onLog('DataFetchingDemo: Data fetch successful');
    } catch (err) {
      setError('Failed to fetch users');
      onLog('DataFetchingDemo: Data fetch failed');
    } finally {
      setLoading(false);
    }
  };

  // Effect for initial data loading
  useEffect(() => {
    onLog('DataFetchingDemo: Component mounted, fetching initial data');
    fetchUsers();
  }, []);

  return (
    <div className="data-fetching-demo">
      <div className="fetch-controls">
        <button 
          onClick={fetchUsers} 
          disabled={loading}
          className="btn btn-primary"
        >
          {loading ? 'Loading...' : 'Refresh Users'}
        </button>
      </div>

      {loading && (
        <div className="loading-state">
          <div className="spinner"></div>
          <p>Loading users...</p>
        </div>
      )}

      {error && (
        <div className="error-state">
          <p>Error: {error}</p>
        </div>
      )}

      {!loading && !error && users.length > 0 && (
        <div className="users-list">
          <h4>Users ({users.length})</h4>
          {users.map(user => (
            <div key={user.id} className="user-card">
              <strong>{user.name}</strong>
              <span>{user.email}</span>
            </div>
          ))}
        </div>
      )}

      <div className="fetch-info">
        <h4>Data Fetching Pattern:</h4>
        <pre><code>{`useEffect(() => {
  fetchData();
}, []); // Empty dependency array for initial load`}</code></pre>
      </div>
    </div>
  );
}

export default LifecycleDemo;
