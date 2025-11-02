import { createContext, useContext, useState } from 'react';

// Create contexts
const ThemeContext = createContext('light');
const UserContext = createContext(null);

// Theme Provider Component
function ThemeProvider({ children }) {
  const [theme, setTheme] = useState('light');

  const toggleTheme = () => {
    setTheme(prev => prev === 'light' ? 'dark' : 'light');
  };

  return (
    <ThemeContext.Provider value={{ theme, toggleTheme }}>
      {children}
    </ThemeContext.Provider>
  );
}

// User Provider Component
function UserProvider({ children }) {
  const [user, setUser] = useState(null);

  const login = (username) => {
    setUser({ username, loggedIn: true });
  };

  const logout = () => {
    setUser(null);
  };

  return (
    <UserContext.Provider value={{ user, login, logout }}>
      {children}
    </UserContext.Provider>
  );
}

// Component using useContext
function ThemedButton() {
  const { theme, toggleTheme } = useContext(ThemeContext);

  const styles = {
    backgroundColor: theme === 'light' ? '#fff' : '#333',
    color: theme === 'light' ? '#333' : '#fff',
    padding: '10px 20px',
    border: '1px solid',
    borderColor: theme === 'light' ? '#333' : '#fff',
    cursor: 'pointer',
    borderRadius: '4px',
  };

  return (
    <button onClick={toggleTheme} style={styles}>
      Toggle Theme (Current: {theme})
    </button>
  );
}

// Component using multiple contexts
function UserProfile() {
  const { theme } = useContext(ThemeContext);
  const { user, login, logout } = useContext(UserContext);

  const styles = {
    padding: '20px',
    backgroundColor: theme === 'light' ? '#f0f0f0' : '#444',
    color: theme === 'light' ? '#333' : '#fff',
    borderRadius: '8px',
    marginTop: '16px',
  };

  return (
    <div style={styles}>
      {user ? (
        <div>
          <h4>Welcome, {user.username}!</h4>
          <button onClick={logout}>Logout</button>
        </div>
      ) : (
        <div>
          <h4>Please log in</h4>
          <button onClick={() => login('JohnDoe')} style={{ marginRight: '8px' }}>Login as JohnDoe</button>
          <button onClick={() => login('JaneSmith')}>Login as JaneSmith</button>
        </div>
      )}
    </div>
  );
}

// Nested component to show context propagation
function NestedComponent() {
  const { theme } = useContext(ThemeContext);
  const { user } = useContext(UserContext);

  return (
    <div style={{
      padding: '10px',
      margin: '10px 0',
      backgroundColor: theme === 'light' ? '#e0e0e0' : '#555',
      color: theme === 'light' ? '#000' : '#fff',
      borderRadius: '4px'
    }}>
      <p>This is a deeply nested component</p>
      <p>Theme: {theme}</p>
      <p>User: {user ? user.username : 'Not logged in'}</p>
      <p><small>No props drilling needed! 🎉</small></p>
    </div>
  );
}

// Main component with providers
function UseContextExample() {
  return (
    <ThemeProvider>
      <UserProvider>
        <div>
          <h3>useContext Example</h3>
          <p>Context allows sharing data without passing props through every level</p>
          <ThemedButton />
          <UserProfile />
          <NestedComponent />
        </div>
      </UserProvider>
    </ThemeProvider>
  );
}

export default UseContextExample;
