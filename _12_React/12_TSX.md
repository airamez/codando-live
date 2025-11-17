# TSX: TypeScript XML

TSX is the TypeScript equivalent of JSX - it allows you to write type-safe React components using TypeScript syntax. While JSX files use the `.jsx` extension, TSX files use `.tsx`.

**Key Differences: JSX vs TSX**

| Aspect | JSX (JavaScript) | TSX (TypeScript) |
|--------|------------------|------------------|
| **File Extension** | `.jsx` | `.tsx` |
| **Type Safety** | No type checking | Full TypeScript type checking |
| **Props Typing** | Optional (PropTypes) | Required TypeScript interfaces/types |
| **Errors** | Runtime errors | Compile-time errors |
| **IDE Support** | Basic autocomplete | Advanced IntelliSense with types |

**Why Use TSX?**

* **Type Safety**: Catch errors during development, not runtime
* **Better IDE Support**: Autocomplete, refactoring, inline documentation
* **Self-Documenting Code**: Types serve as documentation
* **Refactoring Confidence**: TypeScript catches breaking changes
* **Team Collaboration**: Clear contracts between components

---

##### **Simple Component with Props:**

```tsx
interface ProductProps {
  id: number;
  description: string;
  price: number;
  expirationDate: Date;
  discount: number;
}

function Product(props: ProductProps) {
  return (
    <div>
      <h3>Product #{props.id}</h3>
      <p>{props.description}</p>
      <p>Price: ${props.price.toFixed(2)}</p>
      <p>Expires: {props.expirationDate.toLocaleDateString()}</p>
      <p>Discount: {props.discount}%</p>
    </div>
  );
}

// Pass full object using spread operator
const product: ProductProps = {
  id: 1,
  description: "Wireless Mouse",
  price: 29.99,
  expirationDate: new Date('2026-12-31'),
  discount: 10
};
<Product {...product} />

// Pass props individually
<Product 
  id={1} 
  description="Wireless Mouse" 
  price={29.99} 
  expirationDate={new Date('2026-12-31')}
  discount={10}
/>

```

##### **Event Handlers with Proper Types:**

```tsx
import { useState, ChangeEvent, FormEvent } from 'react';

function MyForm() {
  const [email, setEmail] = useState<string>('');
  
  // Typed event handler for input
  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setEmail(e.target.value);
  };
  
  // Typed event handler for form submit
  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log('Email:', email);
  };
  
  return (
    <form onSubmit={handleSubmit}>
      <input type="email" value={email} onChange={handleChange} />
      <button type="submit">Submit</button>
    </form>
  );
}
```

##### **Common TypeScript Types for React**

```tsx
import {
  ReactNode,           // Any valid React content
  ReactElement,        // React element (JSX)
  CSSProperties,       // Inline style object
  ChangeEvent,         // Input change events
  FormEvent,           // Form events
  MouseEvent,          // Mouse events
  KeyboardEvent,       // Keyboard events
  HTMLInputElement,    // Input element type
  HTMLButtonElement,   // Button element type
  HTMLFormElement,     // Form element type
} from 'react';
```

##### **Props with Optional Properties:**

```tsx
interface ProductCardProps {
  id: number;
  description: string;
  price: number;
  expirationDate?: Date;  // Optional property
  discount?: number;      // Optional property
}

function ProductCard(props: ProductCardProps) {
  return (
    <div>
      <h3>Product #{props.id}</h3>
      <p>{props.description}</p>
      <p>Price: ${props.price.toFixed(2)}</p>
      
      {/* Conditional rendering for optional properties */}
      {props.expirationDate && (
        <p>Expires: {props.expirationDate.toLocaleDateString()}</p>
      )}
      
      {props.discount && (
        <p>Discount: {props.discount}%</p>
      )}
    </div>
  );
}

// Usage examples:

// Minimal - only required props
<ProductCard id={1} description="Mouse" price={29.99} />

// With optional expiration
<ProductCard 
  id={2} 
  description="Keyboard" 
  price={89.99} 
  expirationDate={new Date('2026-12-31')}
/>

// With all properties
<ProductCard 
  id={3} 
  description="Monitor" 
  price={299.99} 
  expirationDate={new Date('2027-06-30')}
  discount={15}
/>

// Using spread operator
const product: ProductCardProps = {
  id: 4,
  description: "USB Hub",
  price: 49.99,
  discount: 10
};
<ProductCard {...product} />
```

##### React Hooks with TypeScript

**useState with explicit types:**

```tsx
import { useState } from 'react';

// Explicit type (when initial value is null/undefined)
interface User {
  name: string;
  email: string;
}
const [user, setUser] = useState<User | null>(null);

// Array state
const [items, setItems] = useState<string[]>([]);

// Object state
interface FormData {
  name: string;
  email: string;
}
const [formData, setFormData] = useState<FormData>({
  name: '',
  email: ''
});
```

**useEffect**

```tsx
import { useState, useEffect } from 'react';

interface User {
  id: number;
  name: string;
  email: string;
}

function UserList() {
  const [users, setUsers] = useState<User[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    // Fetch users from API
    const fetchUsers = async () => {
      try {
        const response = await fetch('https://jsonplaceholder.typicode.com/users');
        const data: User[] = await response.json();
        setUsers(data);
      } catch (error) {
        console.error('Error fetching users:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchUsers();
  }, []); // Empty array = runs once on mount

  if (loading) return <div>Loading...</div>;

  return (
    <ul>
      {users.map(user => (
        <li key={user.id}>
          {user.name} - {user.email}
        </li>
      ))}
    </ul>
  );
}
```

**useContext**

```tsx
import { createContext, useContext, ReactNode } from 'react';

interface User {
  name: string;
  email: string;
}

interface AuthContextType {
  user: User | null;
  login: (user: User) => void;
  logout: () => void;
}

// Create context with type
const AuthContext = createContext<AuthContextType | undefined>(undefined);

// Provider component
interface AuthProviderProps {
  children: ReactNode;
}

function AuthProvider({ children }: AuthProviderProps) {
  const [user, setUser] = useState<User | null>(null);

  const login = (user: User) => setUser(user);
  const logout = () => setUser(null);

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

// Custom hook to use context
function useAuth() {
  const context = useContext(AuthContext);
  if (context === undefined) {
    throw new Error('useAuth must be used within AuthProvider');
  }
  return context;
}
```

---

**Key Takeaways:**

* TSX = JSX + TypeScript type safety
* All React code remains the same, just add types
* Props, state, and events need type definitions
* TypeScript catches errors before runtime
* Better developer experience with autocomplete and documentation
* Gradual migration: Convert files one at a time from `.jsx` to `.tsx`
---
