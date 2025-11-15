import './Routing.css';

function Dashboard({ username }) {
  return (
    <div className="dashboard-container">
      <h2>🔒 Dashboard</h2>
      <div className="dashboard-content">
        <p>Welcome to your dashboard! This is a protected page.</p>
        <p>Only authenticated users can see this content.</p>

        <div className="dashboard-info">
          <h3>Protected Content</h3>
          <ul>
            <li>✅ You are successfully authenticated</li>
            <li>✅ This page requires login to access</li>
            <li>✅ If you weren't logged in, you would be redirected to the login page</li>
            <li>✅ After logout, you won't be able to access this page</li>
          </ul>
        </div>

        <div className="dashboard-stats">
          <div className="stat-card">
            <h4>Total Users</h4>
            <p className="stat-number">10</p>
          </div>
          <div className="stat-card">
            <h4>Total Posts</h4>
            <p className="stat-number">100</p>
          </div>
          <div className="stat-card">
            <h4>Active Sessions</h4>
            <p className="stat-number">1</p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Dashboard;
