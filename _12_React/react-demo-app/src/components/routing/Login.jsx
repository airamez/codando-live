import { useState } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import './Routing.css';

function Login({ setAuth }) {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();
  const location = useLocation();

  // Get the page user tried to access
  const from = location.state?.from?.pathname || '/routing/dashboard';

  const handleLogin = (e) => {
    e.preventDefault();

    // Simple authentication: accept any username with password "react"
    if (password === 'react') {
      setAuth(true);
      // Redirect to original destination or dashboard
      navigate(from, { replace: true });
    } else {
      setError('Invalid password. Use "react" as password.');
    }
  };

  return (
    <div className="login-container">
      <h2>Login</h2>
      <form onSubmit={handleLogin} className="login-form">
        <div className="form-group">
          <label>Username:</label>
          <input
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            required
            placeholder="Enter any username"
          />
        </div>

        <div className="form-group">
          <label>Password:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
            placeholder="Enter password: React"
          />
        </div>

        {error && (
          <div className="error-message">{error}</div>
        )}

        <button type="submit" className="login-button">
          Login
        </button>
      </form>

      <p className="login-hint">
        💡 Hint: Use any username with password "react"
      </p>
    </div>
  );
}

export default Login;
