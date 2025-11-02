import { useState, useEffect } from 'react';

function UseEffectExamples() {
  const [count, setCount] = useState(0);
  const [data, setData] = useState(null);
  const [userId, setUserId] = useState(1);
  const [windowWidth, setWindowWidth] = useState(window.innerWidth);
  const [seconds, setSeconds] = useState(0);

  // Example 1: Runs after every render (no dependency array)
  useEffect(() => {
    console.log('Component rendered or updated');
  });

  // Example 2: Runs once after initial render (empty dependency array)
  useEffect(() => {
    console.log('Component mounted');
    const originalTitle = document.title;
    document.title = 'React Hooks Demo';

    return () => {
      console.log('Component will unmount');
      document.title = originalTitle;
    };
  }, []);

  // Example 3: Runs when specific dependency changes
  useEffect(() => {
    document.title = `Count: ${count}`;
  }, [count]);

  // Example 4: Data fetching with cleanup
  useEffect(() => {
    let cancelled = false;

    async function fetchData() {
      setData(null);
      try {
        const response = await fetch(`https://jsonplaceholder.typicode.com/users/${userId}`);
        const result = await response.json();

        if (!cancelled) {
          setData(result);
        }
      } catch (error) {
        console.error('Fetch error:', error);
        if (!cancelled) {
          setData({ error: error.message });
        }
      }
    }

    fetchData();

    // Cleanup: prevent state update if component unmounts during fetch
    return () => {
      cancelled = true;
    };
  }, [userId]);

  // Example 5: Event listener with cleanup
  useEffect(() => {
    const handleResize = () => {
      setWindowWidth(window.innerWidth);
    };

    window.addEventListener('resize', handleResize);

    // Cleanup: remove event listener
    return () => {
      window.removeEventListener('resize', handleResize);
    };
  }, []);

  // Example 6: Timer with cleanup
  useEffect(() => {
    const timer = setInterval(() => {
      setSeconds(prev => prev + 1);
    }, 1000);

    // Cleanup: clear interval
    return () => {
      clearInterval(timer);
    };
  }, []);

  // Example 7: Local storage sync
  useEffect(() => {
    localStorage.setItem('demoCount', count.toString());
  }, [count]);

  return (
    <div>
      <h3>useEffect Examples</h3>

      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Counter (updates document title)</h4>
        <p>Count: {count}</p>
        <button onClick={() => setCount(count + 1)}>Increment</button>
        <p><small>Check the browser tab title!</small></p>
      </div>

      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Window Width (event listener)</h4>
        <p>Window Width: {windowWidth}px</p>
        <p><small>Resize the browser window to see changes</small></p>
      </div>

      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Timer (runs every second)</h4>
        <p>Seconds elapsed: {seconds}</p>
      </div>

      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Data Fetching</h4>
        <button onClick={() => setUserId(userId > 1 ? userId - 1 : 10)}>Previous User</button>
        <button onClick={() => setUserId(userId < 10 ? userId + 1 : 1)} style={{ marginLeft: '8px' }}>Next User</button>
        <p>User ID: {userId}</p>
        {data ? (
          data.error ? (
            <p style={{ color: 'red' }}>Error: {data.error}</p>
          ) : (
            <div>
              <p><strong>Name:</strong> {data.name}</p>
              <p><strong>Email:</strong> {data.email}</p>
              <p><strong>Phone:</strong> {data.phone}</p>
              <p><strong>Website:</strong> {data.website}</p>
            </div>
          )
        ) : (
          <p>Loading...</p>
        )}
      </div>

      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Local Storage</h4>
        <p>Count is saved to localStorage: {localStorage.getItem('demoCount')}</p>
      </div>
    </div>
  );
}

export default UseEffectExamples;
