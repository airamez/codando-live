// HelloWorld.js - Basic React Component Example
import React from 'react';
import './HelloWorld.css';

/**
 * HelloWorld Component
 * 
 * This is a simple functional component that demonstrates:
 * - Basic JSX syntax
 * - Component structure
 * - CSS styling
 * - Props usage
 */
function HelloWorld({ name = "React World", showTime = false }) {
  const currentTime = new Date().toLocaleTimeString();
  
  return (
    <div className="hello-world">
      <h1>Hello, {name}!</h1>
      <p className="welcome-message">
        Welcome to your first React component!
      </p>
      
      {showTime && (
        <p className="time-display">
          Current time: {currentTime}
        </p>
      )}
      
      <div className="features">
        <h3>What you're learning:</h3>
        <ul>
          <li>JSX syntax and JavaScript expressions</li>
          <li>Component props and default values</li>
          <li>Conditional rendering with &&</li>
          <li>CSS styling in React</li>
        </ul>
      </div>
    </div>
  );
}

export default HelloWorld;
