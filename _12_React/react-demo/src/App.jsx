import React, { useState } from 'react';
import './App.css';

// Import all example components
import HelloWorld from './HelloWorld.jsx';
import Counter from './Counter.jsx';
import TodoList from './TodoList.jsx';
import UserProfile from './UserProfile.jsx';
import LifecycleDemo from './LifecycleDemo.jsx';
import ActionsDemo from './ActionsDemo.jsx';

function App() {
  const [currentExample, setCurrentExample] = useState('home');

  const examples = [
    { 
      id: 'home', 
      name: 'Home', 
      component: <HomePage onNavigate={setCurrentExample} />,
      description: 'Welcome and overview of all React examples'
    },
    { 
      id: 'hello-world', 
      name: 'Hello World', 
      component: <HelloWorld name="Student" showTime={true} />,
      description: 'Basic components, JSX syntax, and props'
    },
    { 
      id: 'counter', 
      name: 'Counter App', 
      component: <Counter />,
      description: 'useState hook and event handling'
    },
    { 
      id: 'todo-list', 
      name: 'Todo List', 
      component: <TodoList />,
      description: 'Complex state management, arrays, and forms'
    },
    { 
      id: 'user-profile', 
      name: 'User Profile', 
      component: <UserProfile />,
      description: 'Form validation and controlled components'
    },
    { 
      id: 'lifecycle', 
      name: 'Lifecycle Demo', 
      component: <LifecycleDemo />,
      description: 'useEffect hook and side effects'
    },
    { 
      id: 'actions', 
      name: 'React 19 Actions', 
      component: <ActionsDemo />,
      description: 'React 19 Actions, useActionState, and useOptimistic'
    },
  ];

  const currentExampleData = examples.find(ex => ex.id === currentExample);

  return (
    <div className="demo-app">
      <header className="demo-header">
        <h1>React 19 Training Demo</h1>
        <p className="demo-subtitle">Interactive examples for learning React concepts</p>
        <nav className="demo-nav">
          {examples.map(example => (
            <button
              key={example.id}
              onClick={() => setCurrentExample(example.id)}
              className={currentExample === example.id ? 'active' : ''}
              title={example.description}
            >
              {example.name}
            </button>
          ))}
        </nav>
      </header>
      
      <main className="demo-content">
        <div className="example-header">
          <h2>{currentExampleData?.name}</h2>
          <p className="example-description">{currentExampleData?.description}</p>
        </div>
        {currentExampleData?.component}
      </main>
    </div>
  );
}

function HomePage({ onNavigate }) {
  const examples = [
    {
      id: 'hello-world',
      title: 'Hello World',
      description: 'Learn the basics of React components, JSX syntax, and props',
      concepts: ['Components', 'JSX', 'Props', 'Conditional Rendering'],
      difficulty: 'Beginner',
      color: '#3498db'
    },
    {
      id: 'counter',
      title: 'Counter App',
      description: 'Explore state management with the useState hook and event handling',
      concepts: ['useState', 'Event Handling', 'State Updates', 'Dynamic Styling'],
      difficulty: 'Beginner',
      color: '#2ecc71'
    },
    {
      id: 'todo-list',
      title: 'Todo List',
      description: 'Build a complete todo application with complex state management',
      concepts: ['Arrays in State', 'Forms', 'List Rendering', 'Filtering'],
      difficulty: 'Intermediate',
      color: '#f39c12'
    },
    {
      id: 'user-profile',
      title: 'User Profile',
      description: 'Create forms with validation and controlled components',
      concepts: ['Form Handling', 'Validation', 'Controlled Components', 'Object State'],
      difficulty: 'Intermediate',
      color: '#9b59b6'
    },
    {
      id: 'lifecycle',
      title: 'Lifecycle Demo',
      description: 'Master side effects and component lifecycle with useEffect',
      concepts: ['useEffect', 'Side Effects', 'Cleanup', 'Data Fetching'],
      difficulty: 'Intermediate',
      color: '#e74c3c'
    },
    {
      id: 'actions',
      title: 'React 19 Actions',
      description: 'Explore React 19\'s new Actions feature for modern form handling',
      concepts: ['useActionState', 'useOptimistic', 'Actions', 'Modern Forms'],
      difficulty: 'Advanced',
      color: '#1abc9c'
    }
  ];

  return (
    <div className="home-page">
      <div className="welcome-section">
        <h2>Welcome to React 19 Training</h2>
        <p className="welcome-text">
          This interactive demo contains comprehensive examples covering React fundamentals 
          through advanced React 19 features. Each example is designed to teach specific 
          concepts with hands-on, runnable code.
        </p>
      </div>

      <div className="examples-grid">
        {examples.map(example => (
          <div key={example.id} className="example-card" style={{ borderLeftColor: example.color }}>
            <div className="example-header">
              <h3>{example.title}</h3>
              <span className={`difficulty ${example.difficulty.toLowerCase()}`}>
                {example.difficulty}
              </span>
            </div>
            <p className="example-desc">{example.description}</p>
            <div className="concepts">
              {example.concepts.map(concept => (
                <span key={concept} className="concept-tag" style={{ backgroundColor: example.color + '20', color: example.color }}>
                  {concept}
                </span>
              ))}
            </div>
            <button 
              className="try-example-btn" 
              onClick={() => onNavigate(example.id)}
              style={{ backgroundColor: example.color }}
            >
              Try Example →
            </button>
          </div>
        ))}
      </div>

      <div className="learning-path">
        <h3>Recommended Learning Path</h3>
        <div className="path-steps">
          <div className="path-step">
            <span className="step-number">1</span>
            <div className="step-content">
              <strong>Start with Hello World</strong>
              <p>Learn basic component structure and JSX</p>
            </div>
          </div>
          <div className="path-step">
            <span className="step-number">2</span>
            <div className="step-content">
              <strong>Build the Counter</strong>
              <p>Understand state and event handling</p>
            </div>
          </div>
          <div className="path-step">
            <span className="step-number">3</span>
            <div className="step-content">
              <strong>Create Todo List</strong>
              <p>Master complex state and forms</p>
            </div>
          </div>
          <div className="path-step">
            <span className="step-number">4</span>
            <div className="step-content">
              <strong>Build User Profile</strong>
              <p>Learn form validation patterns</p>
            </div>
          </div>
          <div className="path-step">
            <span className="step-number">5</span>
            <div className="step-content">
              <strong>Explore Lifecycle</strong>
              <p>Understand useEffect and side effects</p>
            </div>
          </div>
          <div className="path-step">
            <span className="step-number">6</span>
            <div className="step-content">
              <strong>Try React 19 Actions</strong>
              <p>Experience the latest React features</p>
            </div>
          </div>
        </div>
      </div>

      <div className="quick-tips">
        <h3>Quick Tips for Teaching</h3>
        <div className="tips-grid">
          <div className="tip">
            <h4>🔍 Show the Code</h4>
            <p>Use your IDE to show the source code alongside the running demo</p>
          </div>
          <div className="tip">
            <h4>🎯 Focus on Concepts</h4>
            <p>Each example highlights specific React concepts - explain them step by step</p>
          </div>
          <div className="tip">
            <h4>🛠️ Encourage Experimentation</h4>
            <p>Have students modify the code and see immediate results</p>
          </div>
          <div className="tip">
            <h4>📝 Use the Console</h4>
            <p>Open browser dev tools to show React Developer Tools and console logs</p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
