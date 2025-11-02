import { useState, useEffect, useCallback, useRef } from 'react';

// Custom Hook 1: useFetch - Data fetching hook
function useFetch(url) {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    let cancelled = false;

    async function fetchData() {
      setLoading(true);
      setError(null);

      try {
        const response = await fetch(url);
        if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
        const result = await response.json();

        if (!cancelled) {
          setData(result);
        }
      } catch (err) {
        if (!cancelled) {
          setError(err.message);
        }
      } finally {
        if (!cancelled) {
          setLoading(false);
        }
      }
    }

    fetchData();

    return () => {
      cancelled = true;
    };
  }, [url]);

  return { data, loading, error };
}

// Custom Hook 2: useLocalStorage - Sync state with localStorage
function useLocalStorage(key, initialValue) {
  const [storedValue, setStoredValue] = useState(() => {
    try {
      const item = window.localStorage.getItem(key);
      return item ? JSON.parse(item) : initialValue;
    } catch (error) {
      console.error(error);
      return initialValue;
    }
  });

  const setValue = useCallback((value) => {
    try {
      const valueToStore = value instanceof Function ? value(storedValue) : value;
      setStoredValue(valueToStore);
      window.localStorage.setItem(key, JSON.stringify(valueToStore));
    } catch (error) {
      console.error(error);
    }
  }, [key, storedValue]);

  return [storedValue, setValue];
}

// Custom Hook 3: useToggle - Boolean state toggle
function useToggle(initialValue = false) {
  const [value, setValue] = useState(initialValue);

  const toggle = useCallback(() => {
    setValue(v => !v);
  }, []);

  return [value, toggle, setValue];
}

// Custom Hook 4: useDebounce - Debounce a value
function useDebounce(value, delay) {
  const [debouncedValue, setDebouncedValue] = useState(value);

  useEffect(() => {
    const handler = setTimeout(() => {
      setDebouncedValue(value);
    }, delay);

    return () => {
      clearTimeout(handler);
    };
  }, [value, delay]);

  return debouncedValue;
}

// Custom Hook 5: useWindowSize - Track window dimensions
function useWindowSize() {
  const [windowSize, setWindowSize] = useState({
    width: window.innerWidth,
    height: window.innerHeight,
  });

  useEffect(() => {
    function handleResize() {
      setWindowSize({
        width: window.innerWidth,
        height: window.innerHeight,
      });
    }

    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  return windowSize;
}

// Custom Hook 6: useOnClickOutside - Detect clicks outside element
function useOnClickOutside(ref, handler) {
  useEffect(() => {
    const listener = (event) => {
      if (!ref.current || ref.current.contains(event.target)) {
        return;
      }
      handler(event);
    };

    document.addEventListener('mousedown', listener);
    document.addEventListener('touchstart', listener);

    return () => {
      document.removeEventListener('mousedown', listener);
      document.removeEventListener('touchstart', listener);
    };
  }, [ref, handler]);
}

// Using the custom hooks
function CustomHooksExample() {
  // useFetch example
  const [userId, setUserId] = useState(1);
  const { data: user, loading, error } = useFetch(`https://jsonplaceholder.typicode.com/users/${userId}`);

  // useLocalStorage example
  const [name, setName] = useLocalStorage('demoName', '');
  const [theme, setTheme] = useLocalStorage('demoTheme', 'light');

  // useToggle example
  const [isOpen, toggleOpen] = useToggle(false);

  // useDebounce example
  const [searchTerm, setSearchTerm] = useState('');
  const debouncedSearchTerm = useDebounce(searchTerm, 500);

  // useWindowSize example
  const { width, height } = useWindowSize();

  // useOnClickOutside example
  const dropdownRef = useRef(null);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  useOnClickOutside(dropdownRef, () => setDropdownOpen(false));

  useEffect(() => {
    if (debouncedSearchTerm) {
      console.log('Searching for:', debouncedSearchTerm);
    }
  }, [debouncedSearchTerm]);

  return (
    <div>
      <h3>Custom Hooks Examples</h3>

      {/* useFetch */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>1. useFetch Hook</h4>
        <button onClick={() => setUserId(prev => prev > 1 ? prev - 1 : 10)}>Previous</button>
        <button onClick={() => setUserId(prev => prev < 10 ? prev + 1 : 1)} style={{ marginLeft: '8px' }}>Next</button>
        {loading && <p>Loading user {userId}...</p>}
        {error && <p style={{ color: 'red' }}>Error: {error}</p>}
        {user && (
          <div>
            <p><strong>{user.name}</strong></p>
            <p>Email: {user.email}</p>
            <p>Phone: {user.phone}</p>
          </div>
        )}
      </div>

      {/* useLocalStorage */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>2. useLocalStorage Hook</h4>
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="Your name (persisted)"
          style={{ marginRight: '8px' }}
        />
        <p>Stored name: {name || '(empty)'}</p>
        <button onClick={() => setTheme(theme === 'light' ? 'dark' : 'light')}>
          Toggle Theme (Current: {theme})
        </button>
      </div>

      {/* useToggle */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>3. useToggle Hook</h4>
        <button onClick={toggleOpen}>
          {isOpen ? 'Close' : 'Open'} Panel
        </button>
        {isOpen && (
          <div style={{ padding: '10px', backgroundColor: '#f0f0f0', marginTop: '10px' }}>
            Panel Content - This is toggled!
          </div>
        )}
      </div>

      {/* useDebounce */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>4. useDebounce Hook</h4>
        <input
          type="text"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          placeholder="Search (debounced 500ms)..."
          style={{ width: '300px' }}
        />
        <p>Immediate value: {searchTerm || '(empty)'}</p>
        <p>Debounced value: {debouncedSearchTerm || '(empty)'}</p>
        <p><small>The debounced value updates 500ms after you stop typing</small></p>
      </div>

      {/* useWindowSize */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>5. useWindowSize Hook</h4>
        <p>Window size: {width} × {height}</p>
        <p><small>Resize the browser window to see changes</small></p>
      </div>

      {/* useOnClickOutside */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>6. useOnClickOutside Hook</h4>
        <div style={{ position: 'relative' }}>
          <button onClick={() => setDropdownOpen(!dropdownOpen)}>
            Toggle Dropdown
          </button>
          {dropdownOpen && (
            <div
              ref={dropdownRef}
              style={{
                marginTop: '8px',
                padding: '10px',
                backgroundColor: 'white',
                border: '1px solid #ccc',
                borderRadius: '4px',
                boxShadow: '0 2px 8px rgba(0,0,0,0.1)',
              }}
            >
              <p>Dropdown content</p>
              <p><small>Click outside to close</small></p>
            </div>
          )}
        </div>
      </div>

      {/* Explanation */}
      <div style={{ marginBottom: '20px', padding: '10px', backgroundColor: '#f0f0f0' }}>
        <h4>Benefits of Custom Hooks</h4>
        <ul style={{ textAlign: 'left' }}>
          <li>Reusable logic across components</li>
          <li>Easier to test in isolation</li>
          <li>Cleaner component code</li>
          <li>Better separation of concerns</li>
          <li>Composable - hooks can use other hooks</li>
        </ul>
      </div>
    </div>
  );
}

export default CustomHooksExample;
