import { Navigate, useLocation } from 'react-router-dom';

function ProtectedRoute({ isAuthenticated, children }) {
  const location = useLocation();

  if (!isAuthenticated) {
    // Redirect to login, save attempted location
    return <Navigate to="/routing/login" state={{ from: location }} replace />;
  }

  return children;
}

export default ProtectedRoute;
