// ActionsDemo.js - React 19 Actions Example
import React, { useActionState, useOptimistic } from 'react';
import './ActionsDemo.css';

/**
 * ActionsDemo Component
 * 
 * Demonstrates React 19 new features:
 * - useActionState hook for form handling
 * - Built-in loading states and error handling
 * - useOptimistic for optimistic updates
 * - Modern form patterns with Actions
 */
function ActionsDemo() {
  return (
    <div className="actions-demo">
      <h2>React 19 Actions Demo</h2>
      <p>This demo showcases React 19's new Actions feature for handling forms and async operations.</p>
      
      <div className="demo-sections">
        <div className="demo-section">
          <h3>Contact Form with Actions</h3>
          <ContactForm />
        </div>
        
        <div className="demo-section">
          <h3>Todo List with Optimistic Updates</h3>
          <OptimisticTodoList />
        </div>
        
        <div className="demo-section">
          <h3>User Registration Form</h3>
          <RegistrationForm />
        </div>
      </div>
    </div>
  );
}

// Contact Form using useActionState
function ContactForm() {
  const [state, submitAction, isPending] = useActionState(
    async (prevState, formData) => {
      const name = formData.get('name');
      const email = formData.get('email');
      const message = formData.get('message');
      
      // Simulate validation
      if (!name || !email || !message) {
        return {
          success: false,
          error: 'All fields are required',
          data: { name, email, message }
        };
      }
      
      if (!/\S+@\S+\.\S+/.test(email)) {
        return {
          success: false,
          error: 'Please enter a valid email address',
          data: { name, email, message }
        };
      }
      
      try {
        // Simulate API call
        await new Promise(resolve => setTimeout(resolve, 2000));
        
        // Simulate random failure for demo purposes
        if (Math.random() < 0.3) {
          throw new Error('Server temporarily unavailable');
        }
        
        return {
          success: true,
          message: `Thank you, ${name}! Your message has been sent successfully.`,
          data: null
        };
      } catch (error) {
        return {
          success: false,
          error: error.message,
          data: { name, email, message }
        };
      }
    },
    { success: false, message: '', error: '', data: null }
  );

  return (
    <div className="contact-form-container">
      <form action={submitAction} className="contact-form">
        <div className="form-group">
          <label htmlFor="contact-name">Name:</label>
          <input
            id="contact-name"
            name="name"
            type="text"
            defaultValue={state.data?.name || ''}
            placeholder="Your full name"
            required
          />
        </div>
        
        <div className="form-group">
          <label htmlFor="contact-email">Email:</label>
          <input
            id="contact-email"
            name="email"
            type="email"
            defaultValue={state.data?.email || ''}
            placeholder="your.email@example.com"
            required
          />
        </div>
        
        <div className="form-group">
          <label htmlFor="contact-message">Message:</label>
          <textarea
            id="contact-message"
            name="message"
            defaultValue={state.data?.message || ''}
            placeholder="Your message here..."
            rows="4"
            required
          />
        </div>
        
        <button type="submit" disabled={isPending} className="submit-btn">
          {isPending ? (
            <>
              <span className="spinner"></span>
              Sending...
            </>
          ) : (
            'Send Message'
          )}
        </button>
      </form>
      
      {state.success && (
        <div className="success-message">
          ✅ {state.message}
        </div>
      )}
      
      {state.error && (
        <div className="error-message">
          ❌ {state.error}
        </div>
      )}
      
      <div className="form-info">
        <h4>React 19 Actions Features:</h4>
        <ul>
          <li>Automatic loading state management</li>
          <li>Built-in error handling</li>
          <li>Form data extraction with FormData</li>
          <li>No manual state management needed</li>
        </ul>
      </div>
    </div>
  );
}

// Todo List with Optimistic Updates
function OptimisticTodoList() {
  const [todos, setTodos] = React.useState([
    { id: 1, text: 'Learn React 19', completed: false },
    { id: 2, text: 'Try Actions', completed: false },
    { id: 3, text: 'Build something awesome', completed: true }
  ]);
  
  const [optimisticTodos, addOptimisticTodo] = useOptimistic(
    todos,
    (state, newTodo) => [...state, newTodo]
  );
  
  const [state, addTodoAction, isPending] = useActionState(
    async (prevState, formData) => {
      const text = formData.get('todo');
      
      if (!text.trim()) {
        return { success: false, error: 'Todo text is required' };
      }
      
      const newTodo = {
        id: Date.now(),
        text: text.trim(),
        completed: false
      };
      
      // Add optimistic update
      addOptimisticTodo(newTodo);
      
      try {
        // Simulate API call
        await new Promise(resolve => setTimeout(resolve, 1500));
        
        // Update actual state
        setTodos(prev => [...prev, newTodo]);
        
        return { success: true, error: '' };
      } catch (error) {
        return { success: false, error: 'Failed to add todo' };
      }
    },
    { success: false, error: '' }
  );
  
  const toggleTodo = async (id) => {
    setTodos(prev => prev.map(todo =>
      todo.id === id ? { ...todo, completed: !todo.completed } : todo
    ));
  };

  return (
    <div className="optimistic-todo-container">
      <form action={addTodoAction} className="add-todo-form">
        <input
          name="todo"
          type="text"
          placeholder="Add a new todo..."
          className="todo-input"
        />
        <button type="submit" disabled={isPending} className="add-btn">
          {isPending ? 'Adding...' : 'Add'}
        </button>
      </form>
      
      {state.error && (
        <div className="error-message">
          {state.error}
        </div>
      )}
      
      <div className="todo-list">
        {optimisticTodos.map(todo => (
          <div key={todo.id} className={`todo-item ${todo.completed ? 'completed' : ''}`}>
            <input
              type="checkbox"
              checked={todo.completed}
              onChange={() => toggleTodo(todo.id)}
            />
            <span className="todo-text">{todo.text}</span>
            {isPending && todo.id === Math.max(...optimisticTodos.map(t => t.id)) && (
              <span className="optimistic-indicator">Adding...</span>
            )}
          </div>
        ))}
      </div>
      
      <div className="optimistic-info">
        <h4>Optimistic Updates:</h4>
        <ul>
          <li>UI updates immediately for better UX</li>
          <li>Reverts if the action fails</li>
          <li>Uses useOptimistic hook</li>
        </ul>
      </div>
    </div>
  );
}

// Registration Form with complex validation
function RegistrationForm() {
  const [state, registerAction, isPending] = useActionState(
    async (prevState, formData) => {
      const userData = {
        username: formData.get('username'),
        email: formData.get('email'),
        password: formData.get('password'),
        confirmPassword: formData.get('confirmPassword'),
        terms: formData.get('terms')
      };
      
      // Validation
      const errors = {};
      
      if (!userData.username || userData.username.length < 3) {
        errors.username = 'Username must be at least 3 characters';
      }
      
      if (!userData.email || !/\S+@\S+\.\S+/.test(userData.email)) {
        errors.email = 'Please enter a valid email address';
      }
      
      if (!userData.password || userData.password.length < 6) {
        errors.password = 'Password must be at least 6 characters';
      }
      
      if (userData.password !== userData.confirmPassword) {
        errors.confirmPassword = 'Passwords do not match';
      }
      
      if (!userData.terms) {
        errors.terms = 'You must accept the terms and conditions';
      }
      
      if (Object.keys(errors).length > 0) {
        return {
          success: false,
          errors,
          data: userData
        };
      }
      
      try {
        // Simulate API call
        await new Promise(resolve => setTimeout(resolve, 2000));
        
        // Simulate username taken
        if (userData.username.toLowerCase() === 'admin') {
          return {
            success: false,
            errors: { username: 'Username is already taken' },
            data: userData
          };
        }
        
        return {
          success: true,
          message: `Welcome, ${userData.username}! Your account has been created successfully.`,
          errors: {},
          data: null
        };
      } catch (error) {
        return {
          success: false,
          errors: { general: 'Registration failed. Please try again.' },
          data: userData
        };
      }
    },
    { success: false, message: '', errors: {}, data: null }
  );

  return (
    <div className="registration-form-container">
      <form action={registerAction} className="registration-form">
        <div className="form-group">
          <label htmlFor="reg-username">Username:</label>
          <input
            id="reg-username"
            name="username"
            type="text"
            defaultValue={state.data?.username || ''}
            className={state.errors.username ? 'error' : ''}
            placeholder="Choose a username"
          />
          {state.errors.username && (
            <span className="field-error">{state.errors.username}</span>
          )}
        </div>
        
        <div className="form-group">
          <label htmlFor="reg-email">Email:</label>
          <input
            id="reg-email"
            name="email"
            type="email"
            defaultValue={state.data?.email || ''}
            className={state.errors.email ? 'error' : ''}
            placeholder="your.email@example.com"
          />
          {state.errors.email && (
            <span className="field-error">{state.errors.email}</span>
          )}
        </div>
        
        <div className="form-group">
          <label htmlFor="reg-password">Password:</label>
          <input
            id="reg-password"
            name="password"
            type="password"
            className={state.errors.password ? 'error' : ''}
            placeholder="Enter a secure password"
          />
          {state.errors.password && (
            <span className="field-error">{state.errors.password}</span>
          )}
        </div>
        
        <div className="form-group">
          <label htmlFor="reg-confirm-password">Confirm Password:</label>
          <input
            id="reg-confirm-password"
            name="confirmPassword"
            type="password"
            className={state.errors.confirmPassword ? 'error' : ''}
            placeholder="Confirm your password"
          />
          {state.errors.confirmPassword && (
            <span className="field-error">{state.errors.confirmPassword}</span>
          )}
        </div>
        
        <div className="form-group checkbox-group">
          <label className="checkbox-label">
            <input
              name="terms"
              type="checkbox"
              defaultChecked={state.data?.terms || false}
            />
            <span className="checkmark"></span>
            I accept the terms and conditions
          </label>
          {state.errors.terms && (
            <span className="field-error">{state.errors.terms}</span>
          )}
        </div>
        
        <button type="submit" disabled={isPending} className="register-btn">
          {isPending ? (
            <>
              <span className="spinner"></span>
              Creating Account...
            </>
          ) : (
            'Create Account'
          )}
        </button>
      </form>
      
      {state.success && (
        <div className="success-message">
          ✅ {state.message}
        </div>
      )}
      
      {state.errors.general && (
        <div className="error-message">
          ❌ {state.errors.general}
        </div>
      )}
    </div>
  );
}

export default ActionsDemo;
