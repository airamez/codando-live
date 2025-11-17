# 15. Routing

**What is Routing in Front-End Development?**

* Routing is the mechanism that allows single-page applications (SPAs) to navigate between different views or pages without triggering a full browser reload.
* When a user clicks a link or enters a URL, the router intercepts the request, updates the browser's URL, and renders the appropriate component without requesting a new HTML document from the server.
* This creates a fast, seamless user experience similar to native applications.

**React and Routing:**

* Unlike frameworks such as **Angular** (which includes a built-in router as part of the framework), **React does not include routing functionality out of the box**.
* React is a UI library focused solely on building user interfaces, leaving architectural decisions like routing to developers.
* This design philosophy gives developers flexibility to choose their own routing solution or build applications without routing altogether.

**React Router** is the most popular routing library for React applications. It enables navigation between different views/pages in a single-page application (SPA) without full page reloads, creating a seamless user experience.

* **Important Note:**:
  * While React itself is developed by Meta (Facebook), React does **not** include built-in routing functionality.
  * React Router is an independent third-party library created and maintained by **Remix Software Inc.** (founded by Ryan Florence and Michael Jackson).
  * Despite being third-party, React Router has become the de facto industry standard for client-side routing in React applications.

**Alternative Routing Approaches:**

While React Router is the most common choice for standalone React apps, the React team recommends using full-stack frameworks that include integrated routing solutions:

* **Next.js** (Vercel) - File-based routing system
* **Remix** (same team as React Router) - Enhanced routing with data loading
* **Gatsby** - Static site generation with routing
* **Expo** - For React Native mobile apps

For traditional single-page React applications without a framework, React Router remains the standard choice.

**Documentation:**

* [React Router Documentation](https://reactrouter.com/) - Official React Router documentation
* [Tutorial](https://reactrouter.com/en/main/start/tutorial) - Step-by-step guide to React Router
* [API Reference](https://reactrouter.com/en/main/route/route) - Complete API documentation

**Key Concepts:**

* **Single Page Application (SPA)**: Only the initial page loads from the server; subsequent navigation updates the view without page reloads
* **Client-Side Routing**: JavaScript handles URL changes and renders appropriate components
* **Browser History API**: React Router uses the browser's History API to manipulate the URL
* **Declarative Routing**: Define routes as React components using JSX
* **Nested Routes**: Routes can be nested to create hierarchical layouts

**Why Use React Router:**

* **Navigation without page reloads**: Faster, smoother user experience
* **Bookmarkable URLs**: Users can bookmark and share specific views
* **Browser back/forward**: Standard browser navigation works
* **URL parameters**: Pass data through URLs (e.g., `/user/123`)
* **Nested layouts**: Reusable layouts with nested content areas
* **Programmatic navigation**: Navigate from code (after form submission, etc.)

---

##### Installation

Install React Router for web applications:

```bash
npm install react-router-dom
```

##### Basic Setup

**Step 1: Wrap your app with BrowserRouter**

The `BrowserRouter` component provides the routing context to your entire application. Wrap your app's root component:

```jsx
// main.jsx or index.jsx
import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { BrowserRouter } from 'react-router-dom'
import App from './App.jsx'
import './index.css'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </StrictMode>,
)
```

**Step 2: Define routes in your App component**

Use `Routes` and `Route` components to define which component renders for each URL:

```jsx
// App.jsx
import { Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import About from './pages/About';
import Contact from './pages/Contact';

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/about" element={<About />} />
      <Route path="/contact" element={<Contact />} />
    </Routes>
  );
}

export default App;
```

**What each component does:**

| Component | Purpose | Usage |
|-----------|---------|-------|
| `<BrowserRouter>` | Provides routing context | Wrap root component once |
| `<Routes>` | Container for route definitions | Contains all `<Route>` elements |
| `<Route>` | Defines a route | `path` + `element` pair |

---

##### Navigation with Link

Use the `Link` component instead of `<a>` tags to navigate without page reloads:

```jsx
import { Link } from 'react-router-dom';

function Navigation() {
  return (
    <nav>
      <Link to="/">Home</Link>
      <Link to="/about">About</Link>
      <Link to="/contact">Contact</Link>
    </nav>
  );
}
```

**Link vs `<a>` tag:**

| Feature | `<Link>` | `<a>` tag |
|---------|----------|-----------|
| **Page reload** | No - SPA navigation | Yes - full reload |
| **Speed** | Fast - only updates components | Slow - reloads everything |
| **State preservation** | Yes - React state persists | No - state is lost |
| **Usage** | Internal navigation | External links only |

---

##### Routes and Route

```jsx
import { Routes, Route } from 'react-router-dom';

<Routes>
  {/* Basic route */}
  <Route path="/" element={<Home />} />
  
  {/* Route with parameter */}
  <Route path="/user/:id" element={<UserProfile />} />
  
  {/* Nested routes */}
  <Route path="/products" element={<ProductsLayout />}>
    <Route index element={<ProductList />} />
    <Route path=":id" element={<ProductDetails />} />
  </Route>
  
  {/* Catch-all route (404) */}
  <Route path="*" element={<NotFound />} />
</Routes>
```

##### Link and NavLink

```jsx
import { Link, NavLink } from 'react-router-dom';

// Link - Basic navigation
<Link to="/about">About Us</Link>
<Link to="/user/123">View User</Link>

// NavLink - Adds 'active' class when route matches
<NavLink 
  to="/about"
  className={({ isActive }) => isActive ? 'nav-link active' : 'nav-link'}
>
  About
</NavLink>

// NavLink with style function
<NavLink
  to="/contact"
  style={({ isActive }) => ({
    color: isActive ? 'red' : 'black',
    fontWeight: isActive ? 'bold' : 'normal'
  })}
>
  Contact
</NavLink>
```

##### Navigate Component (Redirects)

```jsx
import { Navigate } from 'react-router-dom';

// Redirect from one route to another
<Route path="/old-path" element={<Navigate to="/new-path" replace />} />

// Conditional redirect
function ProtectedRoute({ isAuthenticated, children }) {
  if (!isAuthenticated) {
    return <Navigate to="/login" replace />;
  }
  return children;
}
```

---

##### URL Parameters

**Reading URL Parameters with useParams Hook:**

```jsx
import { useParams } from 'react-router-dom';

// Route definition
<Route path="/user/:userId/post/:postId" element={<UserPost />} />

// Component
function UserPost() {
  const { userId, postId } = useParams();
  
  return (
    <div>
      <h2>User ID: {userId}</h2>
      <p>Post ID: {postId}</p>
    </div>
  );
}

// URL: /user/42/post/7
// Result: userId = "42", postId = "7"
```

**Important:** URL parameters are always strings. Convert to numbers if needed:

```jsx
const { userId } = useParams();
const userIdNumber = parseInt(userId);
```

---

##### Query Parameters (Search Params)

**Reading and Setting Query Params with useSearchParams Hook:**

```jsx
import { useSearchParams } from 'react-router-dom';

function ProductList() {
  const [searchParams, setSearchParams] = useSearchParams();
  
  // Read query parameters
  const category = searchParams.get('category'); // ?category=electronics
  const sortBy = searchParams.get('sort'); // ?sort=price
  const page = searchParams.get('page') || '1'; // Default to '1'
  
  // Set/update query parameters
  const handleCategoryChange = (newCategory) => {
    setSearchParams({ category: newCategory, sort: sortBy });
  };
  
  return (
    <div>
      <h2>Products - Category: {category || 'All'}</h2>
      <button onClick={() => handleCategoryChange('electronics')}>
        Electronics
      </button>
      <button onClick={() => handleCategoryChange('books')}>
        Books
      </button>
      <p>Page: {page}</p>
    </div>
  );
}

// URL: /products?category=electronics&sort=price&page=2
// category = "electronics"
// sort = "price"
// page = "2"
```

---

##### Programmatic Navigation

**Navigate programmatically using the useNavigate hook:**

```jsx
import { useNavigate } from 'react-router-dom';

function LoginForm() {
  const navigate = useNavigate();
  
  const handleLogin = async (credentials) => {
    const success = await loginUser(credentials);
    
    if (success) {
      // Navigate to dashboard after successful login
      navigate('/dashboard');
    }
  };
  
  const handleCancel = () => {
    // Go back to previous page
    navigate(-1);
  };
  
  return (
    <form onSubmit={handleLogin}>
      {/* form fields */}
      <button type="submit">Login</button>
      <button type="button" onClick={handleCancel}>Cancel</button>
    </form>
  );
}
```

**Navigate Options:**

```jsx
const navigate = useNavigate();

// Navigate to specific path
navigate('/home');

// Navigate with state (data passed to destination)
navigate('/user/profile', { state: { from: 'login' } });

// Replace current history entry (can't go back)
navigate('/home', { replace: true });

// Go back/forward in history
navigate(-1); // Back one page
navigate(-2); // Back two pages
navigate(1);  // Forward one page
```

---

##### Nested Routes and Outlets

**Nested routes allow you to create layouts with child routes that render inside the parent:**

```jsx
// App.jsx - Define nested routes
import { Routes, Route } from 'react-router-dom';

function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home />} />
        <Route path="about" element={<About />} />
        <Route path="products" element={<ProductsLayout />}>
          <Route index element={<ProductList />} />
          <Route path=":id" element={<ProductDetails />} />
        </Route>
      </Route>
    </Routes>
  );
}
```

```jsx
// Layout.jsx - Parent layout with Outlet
import { Outlet, Link } from 'react-router-dom';

function Layout() {
  return (
    <div>
      <header>
        <nav>
          <Link to="/">Home</Link>
          <Link to="/about">About</Link>
          <Link to="/products">Products</Link>
        </nav>
      </header>https://www.youtube.com/live/zrCNTf95p7g
      
      <main>
        {/* Child routes render here */}
        <Outlet />
      </main>
      
      <footer>
        <p>&copy; 2025 My App</p>
      </footer>
    </div>
  );
}
```

**How Nested Routes Work:**

1. **Parent Route**: Defines the layout structure (header, nav, footer)
2. **`<Outlet />`**: Placeholder where child route components render
3. **Child Routes**: Render inside the parent's `<Outlet />`
4. **Index Route**: Default child route when parent path matches exactly

---

##### Protected Routes (Authentication)

**Create a wrapper component to protect routes that require authentication:**

Protected routes prevent unauthorized users from accessing certain pages. When a user tries to access a protected page without being authenticated, they're redirected to the login page.

**How ProtectedRoute Works:**

The `ProtectedRoute` component is a **wrapper component** that conditionally renders its children based on authentication status:

1. **Receives Props**:
   - `isAuthenticated`: Boolean indicating if user is logged in
   - `children`: The protected component/page to render if authenticated

2. **Checks Authentication**:
   - If `isAuthenticated` is `false` → Returns `<Navigate>` component (redirects to login)
   - If `isAuthenticated` is `true` → Returns `children` (renders the protected page)

3. **Wrapping Pattern**: You wrap protected routes like this:
   ```jsx
   <Route path="/dashboard" element={
     <ProtectedRoute isAuthenticated={isAuthenticated}>
       <Dashboard />
     </ProtectedRoute>
   } />
   ```
   
   - If authenticated: Renders `<Dashboard />`
   - If not authenticated: Redirects to `/login`

**Key Implementation Details:**

* **`state={{ from: location }}`**: Saves the page the user tried to access so they can be redirected there after successful login
* **`replace`**: Replaces the current history entry instead of adding a new one, so clicking the browser's back button won't return to the protected page (which would just redirect again)
* **`children` prop**: Special React prop that contains whatever is nested inside the component tags

```jsx
import { Navigate, useLocation } from 'react-router-dom';

function ProtectedRoute({ isAuthenticated, children }) {
  const location = useLocation();
  
  if (!isAuthenticated) {
    // Redirect to login, save attempted location
    return <Navigate to="/login" state={{ from: location }} replace />;
  }
  
  return children;
}

// Usage in App.jsx
function App() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  
  return (
    <Routes>
      <Route path="/login" element={<Login setAuth={setIsAuthenticated} />} />
      
      {/* Protected routes */}
      <Route 
        path="/dashboard" 
        element={
          <ProtectedRoute isAuthenticated={isAuthenticated}>
            <Dashboard />
          </ProtectedRoute>
        } 
      />
      
      <Route 
        path="/profile" 
        element={
          <ProtectedRoute isAuthenticated={isAuthenticated}>
            <Profile />
          </ProtectedRoute>
        } 
      />
    </Routes>
  );
}
```

**Login Component with Redirect:**

```jsx
import { useNavigate, useLocation } from 'react-router-dom';

function Login({ setAuth }) {
  const navigate = useNavigate();
  const location = useLocation();
  
  // Get the page user tried to access
  const from = location.state?.from?.pathname || '/dashboard';
  
  const handleLogin = (e) => {
    e.preventDefault();
    // Perform authentication...
    setAuth(true);
    
    // Redirect to original destination or dashboard
    navigate(from, { replace: true });
  };
  
  return <form onSubmit={handleLogin}>{/* login form */}</form>;
}
```

---

##### 404 Not Found Page

**Catch-all route for handling non-existent paths:**

```jsx
import { Routes, Route, Link } from 'react-router-dom';

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/about" element={<About />} />
      <Route path="/contact" element={<Contact />} />
      
      {/* Catch-all route - must be last */}
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
}

function NotFound() {
  return (
    <div style={{ textAlign: 'center', padding: '50px' }}>
      <h1>404 - Page Not Found</h1>
      <p>The page you're looking for doesn't exist.</p>
      <Link to="/">Go back to Home</Link>
    </div>
  );
}
```

**Important:** The `path="*"` route must be the **last** route, as it matches any unmatched path.

---

##### Lazy Loading Routes

**Code splitting and lazy loading improve performance by loading route components only when needed:**

```jsx
import { lazy, Suspense } from 'react';
import { Routes, Route } from 'react-router-dom';

// Lazy load route components
const Home = lazy(() => import('./pages/Home'));
const About = lazy(() => import('./pages/About'));
const Products = lazy(() => import('./pages/Products'));
const Dashboard = lazy(() => import('./pages/Dashboard'));

function App() {
  return (
    <Suspense fallback={<div>Loading...</div>}>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/products" element={<Products />} />
        <Route path="/dashboard" element={<Dashboard />} />
      </Routes>
    </Suspense>
  );
}
```

**Benefits:**

* **Smaller initial bundle**: App loads faster
* **On-demand loading**: Components load when user navigates to them
* **Better performance**: Especially important for large applications

---

#### Routing Example

* This example demonstrates a complete routing implementation with authentication using React Router and the JSONPlaceholder API.
* The demo includes protected routes, nested routing, URL parameters, and login/logout functionality.

**Features Demonstrated:**

* **Protected Routes**: Users, Posts, and Dashboard pages require authentication
* **Authentication Flow**: Login with any username and password "react"
* **Nested Routes**: Users section has nested routes for user list and individual user posts
* **URL Parameters**: Dynamic routes for viewing specific posts and user details
* **Programmatic Navigation**: Redirect after login/logout
* **API Integration**: Fetches data from JSONPlaceholder API (users, posts, comments)
* **Conditional Rendering**: Navigation buttons change based on authentication state

**Component Structure:**

```
RoutingApp (Main container with auth state)
├── Login (Authentication form)
├── Dashboard (Protected - statistics page)
├── ProtectedRoute (Wrapper for protected routes)
├── Users (Nested routes container)
│   ├── UsersList (Display all users)
│   └── UserPosts (Display posts for specific user)
├── AllPosts (Display all posts)
└── PostComments (Display post details and comments)
```

**Example Files:**

* **Main App**: `_12_React/react-demo-app/src/components/routing/RoutingApp.jsx`
  * **Note**: The routing to the RoutingApp was added to the main `App.jsx`:
    ```jsx
    import RoutingApp from './components/routing/RoutingApp';
    
    <Route path="/routing/*" element={<RoutingApp />} />
    ```
* **Authentication Components**:
  * `_12_React/react-demo-app/src/components/routing/Login.jsx` - Login form
  * `_12_React/react-demo-app/src/components/routing/ProtectedRoute.jsx` - Route protection wrapper
* **Protected Pages**:
  * `_12_React/react-demo-app/src/components/routing/Dashboard.jsx` - Protected dashboard page
* **User Routes**:
  * `_12_React/react-demo-app/src/components/routing/Users.jsx` - Nested routes container
  * `_12_React/react-demo-app/src/components/routing/UsersList.jsx` - List all users
  * `_12_React/react-demo-app/src/components/routing/UserPosts.jsx` - User's posts
* **Post Routes**:
  * `_12_React/react-demo-app/src/components/routing/AllPosts.jsx` - List all posts
  * `_12_React/react-demo-app/src/components/routing/PostComments.jsx` - Post details with comments
* **Styling**: `_12_React/react-demo-app/src/components/routing/Routing.css`

**How to Use:**

1. Navigate to `/routing` to see the home page
2. Try accessing Users, Posts, or Dashboard - you'll be redirected to login
3. Login with any username and password "react"
4. After login, you'll be redirected back to the page you tried to access
5. Explore user posts, view post details with comments
6. Click Logout to clear authentication and return to home

---

**Key Code Snippets from the Example:**

**1. ProtectedRoute Component (ProtectedRoute.jsx)**

The core component that protects routes by checking authentication:

```jsx
import { Navigate, useLocation } from 'react-router-dom';

function ProtectedRoute({ isAuthenticated, children }) {
  const location = useLocation();
  
  // Check if user is authenticated
  if (!isAuthenticated) {
    // Not authenticated: Redirect to login and save attempted location
    return <Navigate to="/routing/login" state={{ from: location }} replace />;
  }
  
  // Authenticated: Render the protected component
  return children;
}
```

**How it works:**
- Receives `isAuthenticated` (boolean) and `children` (the protected component)
- If `isAuthenticated` is **false**: Returns `<Navigate>` component → redirects to login
- If `isAuthenticated` is **true**: Returns `children` → renders the protected page
- Saves the current location in state so user can be redirected back after login

**2. Authentication State Management (RoutingApp.jsx)**

Managing authentication state and logout functionality:

```jsx
function RoutingApp() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const navigate = useNavigate();

  const handleLogout = () => {
    setIsAuthenticated(false);
    navigate('/routing');
  };

  // Pass authentication state to routes
  return (
    <Routes>
      <Route path="login" element={<Login setAuth={setIsAuthenticated} />} />
      <Route path="dashboard" element={
        <ProtectedRoute isAuthenticated={isAuthenticated}>
          <Dashboard />
        </ProtectedRoute>
      } />
    </Routes>
  );
}
```

**3. Login with Redirect (Login.jsx)**

Authenticating and redirecting to the originally requested page:

```jsx
function Login({ setAuth }) {
  const [password, setPassword] = useState('');
  const navigate = useNavigate();
  const location = useLocation();

  // Get the page user tried to access
  const from = location.state?.from?.pathname || '/routing/dashboard';

  const handleLogin = (e) => {
    e.preventDefault();
    
    if (password === 'react') {
      setAuth(true);
      // Redirect to original destination
      navigate(from, { replace: true });
    }
  };

  return <form onSubmit={handleLogin}>{/* form fields */}</form>;
}
```

**3. Protected Routes (RoutingApp.jsx)**

Wrapping routes that require authentication:

```jsx
<Route 
  path="users/*" 
  element={
    <ProtectedRoute isAuthenticated={isAuthenticated}>
      <Users users={users} loading={loading} />
    </ProtectedRoute>
  } 
/>

<Route 
  path="dashboard" 
  element={
    <ProtectedRoute isAuthenticated={isAuthenticated}>
      <Dashboard />
    </ProtectedRoute>
  } 
/>
```

**4. Nested Routes (Users.jsx)**

Creating sub-routes within a parent route:

```jsx
function Users({ users, loading }) {
  return (
    <Routes>
      {/* /routing/users - shows user list */}
      <Route index element={<UsersList users={users} loading={loading} />} />
      
      {/* /routing/users/5 - shows posts for user 5 */}
      <Route path=":userId" element={<UserPosts users={users} />} />
    </Routes>
  );
}
```

**5. URL Parameters (UserPosts.jsx)**

Accessing dynamic URL parameters:

```jsx
import { useParams } from 'react-router-dom';

function UserPosts({ users }) {
  const { userId } = useParams();  // Get userId from URL
  
  useEffect(() => {
    // Fetch posts for specific user
    fetch(`https://jsonplaceholder.typicode.com/users/${userId}/posts`)
      .then(response => response.json())
      .then(data => setPosts(data));
  }, [userId]);
  
  return <div>{/* Display posts */}</div>;
}
```

**6. Conditional Navigation (RoutingApp.jsx)**

Showing different navigation based on authentication state:

```jsx
{isAuthenticated ? (
  <button onClick={handleLogout} className="nav-button logout-button">
    🚪 Logout
  </button>
) : (
  <Link to="/routing/login">
    <button className="nav-button">
      🔑 Login
    </button>
  </Link>
)}
```

**7. Data Fetching on Mount (RoutingApp.jsx)**

Fetching data when component mounts:

```jsx
function RoutingApp() {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(false);

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
  }, []); // Empty array = run once on mount
  
  return <div>{/* Use users data */}</div>;
}
```

**8. Dynamic Route Matching (PostComments.jsx)**

Using URL parameters to fetch specific data:

```jsx
import { useParams } from 'react-router-dom';

function PostComments({ users }) {
  const { postId } = useParams();  // Get postId from URL
  const [post, setPost] = useState(null);
  const [comments, setComments] = useState([]);

  useEffect(() => {
    // Fetch post and comments based on postId
    Promise.all([
      fetch(`https://jsonplaceholder.typicode.com/posts/${postId}`).then(r => r.json()),
      fetch(`https://jsonplaceholder.typicode.com/posts/${postId}/comments`).then(r => r.json())
    ]).then(([postData, commentsData]) => {
      setPost(postData);
      setComments(commentsData);
    });
  }, [postId]);
  
  return <div>{/* Display post and comments */}</div>;
}
```

---

**Key Patterns Demonstrated:**

* `useState` for managing authentication and data state
* `useNavigate` for programmatic navigation after login/logout
* `useLocation` to save and redirect to attempted page after login
* `useParams` for accessing URL parameters (userId, postId)
* `useEffect` for fetching data on component mount
* Protected route wrapper component pattern
* Nested routing with `<Routes>` inside child components
* Conditional UI rendering based on authentication state
* API integration with JSONPlaceholder

---
