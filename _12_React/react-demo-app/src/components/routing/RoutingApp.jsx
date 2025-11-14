import { useState, useEffect } from 'react';
import { Routes, Route, Link, useLocation } from 'react-router-dom';
import Users from './Users';
import AllPosts from './AllPosts';
import PostComments from './PostComments';
import './Routing.css';

function RoutingApp() {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(false);
  const location = useLocation();

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
        </nav>
      </div>

      <div className="routing-content">
        <Routes>
          <Route index element={<div>
            Welcome to the Routing Demo
          </div>} />
          <Route path="users/*" element={<Users users={users} loading={loading} />} />
          <Route path="posts" element={<AllPosts users={users} />} />
          <Route path="posts/:postId" element={<PostComments users={users} />} />
          <Route path="user-posts/:postId" element={<PostComments users={users} />} />
        </Routes>
      </div>
    </div>
  );
}

export default RoutingApp;
