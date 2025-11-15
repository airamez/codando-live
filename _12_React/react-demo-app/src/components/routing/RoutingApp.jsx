import { useState, useEffect } from 'react';
import { Routes, Route, Link, useLocation, useNavigate } from 'react-router-dom';
import Users from './Users';
import AllPosts from './AllPosts';
import PostComments from './PostComments';
import Login from './Login';
import Dashboard from './Dashboard';
import ProtectedRoute from './ProtectedRoute';
import './Routing.css';

function RoutingApp() {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(false);
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const location = useLocation();
  const navigate = useNavigate();

  // Fetch all users on mount
  useEffect(() => {
    setLoading(true);
    fetch('https://jsonplaceholder.typicode.com/users')
      .then(response => response.json())
      .then(data => {
        setUsers(data);
        setLoading(false);
      })
      .catch(error => {
        console.error('Error fetching users:', error);
        setLoading(false);
      });
  }, []);

  const handleLogout = () => {
    setIsAuthenticated(false);
    navigate('/routing');
  };

  return (
    <div className="routing-container">
      <div className="routing-header">
        <h3>Routing Demo with JSONPlaceholder API</h3>
        <p className="routing-header-route">Route: {location.pathname}</p>
        <nav className="routing-nav">
          <Link to="/routing">
            <button className={`nav-button ${location.pathname === '/routing' ? 'nav-button-active' : 'nav-button-inactive'}`}>
              🏠 Home
            </button>
          </Link>
          <Link to="/routing/users">
            <button className={`nav-button ${location.pathname.includes('/routing/users') ? 'nav-button-active' : 'nav-button-inactive'}`}>
              👥 Users
            </button>
          </Link>
          <Link to="/routing/posts">
            <button className={`nav-button ${location.pathname.startsWith('/routing/posts') ? 'nav-button-active' : 'nav-button-inactive'}`}>
              📝 Posts
            </button>
          </Link>
          <Link to="/routing/dashboard">
            <button className={`nav-button ${location.pathname === '/routing/dashboard' ? 'nav-button-active' : 'nav-button-inactive'}`}>
              🔒 Dashboard
            </button>
          </Link>

          {isAuthenticated ? (
            <button onClick={handleLogout} className="nav-button logout-button">
              🚪 Logout
            </button>
          ) : (
            <Link to="/routing/login">
              <button className={`nav-button ${location.pathname === '/routing/login' ? 'nav-button-active' : 'nav-button-inactive'}`}>
                🔑 Login
              </button>
            </Link>
          )}
        </nav>
      </div>

      <div className="routing-content">
        <Routes>
          <Route index element={
            <div className="home-welcome">
              <h2>Welcome to the Routing Demo</h2>
              <p>This example demonstrates React Router features with authentication:</p>
              <ul>
                <li>🔒 <strong>Protected Routes</strong> - Login required to access Users, Posts, and Dashboard</li>
                <li>🔑 <strong>Authentication</strong> - Use any username with password "react"</li>
                <li>📍 <strong>URL Parameters</strong> - Dynamic routes for users and posts</li>
                <li>🔄 <strong>Nested Routes</strong> - Users section has sub-routes</li>
                <li>🌐 <strong>API Integration</strong> - Fetches data from JSONPlaceholder</li>
              </ul>
              <p>Click on the navigation buttons above to explore!</p>
            </div>
          } />
          <Route
            path="users/*"
            element={
              <ProtectedRoute isAuthenticated={isAuthenticated}>
                <Users users={users} loading={loading} />
              </ProtectedRoute>
            }
          />
          <Route
            path="posts"
            element={
              <ProtectedRoute isAuthenticated={isAuthenticated}>
                <AllPosts users={users} />
              </ProtectedRoute>
            }
          />
          <Route
            path="posts/:postId"
            element={
              <ProtectedRoute isAuthenticated={isAuthenticated}>
                <PostComments users={users} />
              </ProtectedRoute>
            }
          />
          <Route
            path="user-posts/:postId"
            element={
              <ProtectedRoute isAuthenticated={isAuthenticated}>
                <PostComments users={users} />
              </ProtectedRoute>
            }
          />
          <Route path="login" element={<Login setAuth={setIsAuthenticated} />} />
          <Route
            path="dashboard"
            element={
              <ProtectedRoute isAuthenticated={isAuthenticated}>
                <Dashboard />
              </ProtectedRoute>
            }
          />
        </Routes>
      </div>
    </div>
  );
}

export default RoutingApp;
