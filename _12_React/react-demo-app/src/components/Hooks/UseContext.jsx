import { createContext, useContext, useState } from 'react';
import './hooks.css';

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

  return (
    <button onClick={toggleTheme} className="use-context-themed-button" data-theme={theme}>
      Toggle Theme (Current: {theme})
    </button>
  );
}

// Component using multiple contexts
function UserProfile() {
  const { theme } = useContext(ThemeContext);
  const { user, login, logout } = useContext(UserContext);

  return (
    <div className="use-context-user-profile" data-theme={theme}>
      {user ? (
        <div>
          <h4>Welcome, {user.username}!</h4>
          <button onClick={logout}>Logout</button>
        </div>
      ) : (
        <div>
          <h4>Please log in</h4>
          <button onClick={() => login('JohnDoe')} className="hook-button-spacing">Login as JohnDoe</button>
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
    <div className="use-context-nested" data-theme={theme}>
      <p>This is a deeply nested component</p>
      <p>Theme: {theme}</p>
      <p>User: {user ? user.username : 'Not logged in'}</p>
      <p><small>No props drilling needed! 🎉</small></p>
    </div>
  );
}

// Main component with providers
function UseContext() {
  return (
    <ThemeProvider>
      <UserProvider>
        <div className="hook-example-section">
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

export default UseContext;
