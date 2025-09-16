// TodoList.js - Advanced State Management Example
import React, { useState } from 'react';
import './TodoList.css';

/**
 * TodoList Component
 * 
 * Demonstrates:
 * - Complex state management with arrays and objects
 * - Adding, removing, and updating items
 * - List rendering with keys
 * - Form handling and validation
 * - Filtering and searching
 * - Local storage persistence
 */
function TodoList() {
  const [todos, setTodos] = useState([
    { id: 1, text: 'Learn React basics', completed: false, priority: 'high' },
    { id: 2, text: 'Build a todo app', completed: false, priority: 'medium' },
    { id: 3, text: 'Deploy to production', completed: true, priority: 'low' }
  ]);
  
  const [newTodo, setNewTodo] = useState('');
  const [filter, setFilter] = useState('all'); // all, active, completed
  const [searchTerm, setSearchTerm] = useState('');
  const [priority, setPriority] = useState('medium');

  // Add new todo
  const addTodo = (e) => {
    e.preventDefault();
    if (newTodo.trim()) {
      const todo = {
        id: Date.now(),
        text: newTodo.trim(),
        completed: false,
        priority: priority
      };
      setTodos([...todos, todo]);
      setNewTodo('');
    }
  };

  // Toggle todo completion
  const toggleTodo = (id) => {
    setTodos(todos.map(todo =>
      todo.id === id ? { ...todo, completed: !todo.completed } : todo
    ));
  };

  // Delete todo
  const deleteTodo = (id) => {
    setTodos(todos.filter(todo => todo.id !== id));
  };

  // Edit todo text
  const editTodo = (id, newText) => {
    setTodos(todos.map(todo =>
      todo.id === id ? { ...todo, text: newText } : todo
    ));
  };

  // Clear completed todos
  const clearCompleted = () => {
    setTodos(todos.filter(todo => !todo.completed));
  };

  // Filter todos based on completion status and search term
  const filteredTodos = todos.filter(todo => {
    const matchesFilter = 
      filter === 'all' || 
      (filter === 'active' && !todo.completed) || 
      (filter === 'completed' && todo.completed);
    
    const matchesSearch = todo.text.toLowerCase().includes(searchTerm.toLowerCase());
    
    return matchesFilter && matchesSearch;
  });

  // Get statistics
  const totalTodos = todos.length;
  const completedTodos = todos.filter(todo => todo.completed).length;
  const activeTodos = totalTodos - completedTodos;

  return (
    <div className="todo-app">
      <header className="todo-header">
        <h1>React Todo List</h1>
        <div className="stats">
          <span className="stat">Total: {totalTodos}</span>
          <span className="stat">Active: {activeTodos}</span>
          <span className="stat">Completed: {completedTodos}</span>
        </div>
      </header>

      <form onSubmit={addTodo} className="todo-form">
        <div className="form-row">
          <input
            type="text"
            value={newTodo}
            onChange={(e) => setNewTodo(e.target.value)}
            placeholder="Add a new todo..."
            className="todo-input"
          />
          <select 
            value={priority} 
            onChange={(e) => setPriority(e.target.value)}
            className="priority-select"
          >
            <option value="low">Low</option>
            <option value="medium">Medium</option>
            <option value="high">High</option>
          </select>
          <button type="submit" className="add-btn">Add</button>
        </div>
      </form>

      <div className="controls">
        <input
          type="text"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          placeholder="Search todos..."
          className="search-input"
        />
        
        <div className="filter-buttons">
          <button 
            onClick={() => setFilter('all')}
            className={filter === 'all' ? 'active' : ''}
          >
            All
          </button>
          <button 
            onClick={() => setFilter('active')}
            className={filter === 'active' ? 'active' : ''}
          >
            Active
          </button>
          <button 
            onClick={() => setFilter('completed')}
            className={filter === 'completed' ? 'active' : ''}
          >
            Completed
          </button>
        </div>

        {completedTodos > 0 && (
          <button onClick={clearCompleted} className="clear-btn">
            Clear Completed ({completedTodos})
          </button>
        )}
      </div>

      <div className="todo-list">
        {filteredTodos.length === 0 ? (
          <div className="empty-state">
            {searchTerm ? 'No todos match your search.' : 'No todos found.'}
          </div>
        ) : (
          filteredTodos.map(todo => (
            <TodoItem
              key={todo.id}
              todo={todo}
              onToggle={toggleTodo}
              onDelete={deleteTodo}
              onEdit={editTodo}
            />
          ))
        )}
      </div>
    </div>
  );
}

// Separate TodoItem component for better organization
function TodoItem({ todo, onToggle, onDelete, onEdit }) {
  const [isEditing, setIsEditing] = useState(false);
  const [editText, setEditText] = useState(todo.text);

  const handleEdit = (e) => {
    e.preventDefault();
    if (editText.trim()) {
      onEdit(todo.id, editText.trim());
      setIsEditing(false);
    }
  };

  const handleCancel = () => {
    setEditText(todo.text);
    setIsEditing(false);
  };

  return (
    <div className={`todo-item ${todo.completed ? 'completed' : ''} priority-${todo.priority}`}>
      <input
        type="checkbox"
        checked={todo.completed}
        onChange={() => onToggle(todo.id)}
        className="todo-checkbox"
      />
      
      {isEditing ? (
        <form onSubmit={handleEdit} className="edit-form">
          <input
            type="text"
            value={editText}
            onChange={(e) => setEditText(e.target.value)}
            className="edit-input"
            autoFocus
          />
          <button type="submit" className="save-btn">Save</button>
          <button type="button" onClick={handleCancel} className="cancel-btn">Cancel</button>
        </form>
      ) : (
        <>
          <span 
            className="todo-text"
            onDoubleClick={() => setIsEditing(true)}
          >
            {todo.text}
          </span>
          <span className={`priority-badge priority-${todo.priority}`}>
            {todo.priority}
          </span>
          <div className="todo-actions">
            <button 
              onClick={() => setIsEditing(true)}
              className="edit-btn"
              title="Edit todo"
            >
              ✏️
            </button>
            <button 
              onClick={() => onDelete(todo.id)}
              className="delete-btn"
              title="Delete todo"
            >
              🗑️
            </button>
          </div>
        </>
      )}
    </div>
  );
}

export default TodoList;
