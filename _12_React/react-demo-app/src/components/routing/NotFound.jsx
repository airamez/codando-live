import { Link } from 'react-router-dom';
import './Routing.css';

function NotFound() {
  return (
    <div className="home-welcome">
      <h2>404 - Page Not Found</h2>
      <p>The page you're looking for doesn't exist.</p>
      <Link to="/routing">
        <button className="nav-button">Go back to Home</button>
      </Link>
    </div>
  );
}

export default NotFound;
