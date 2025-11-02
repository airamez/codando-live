import { useReducer, useState } from 'react';

// Example 1: Counter with reducer
function counterReducer(state, action) {
  switch (action.type) {
    case 'INCREMENT':
      return { count: state.count + 1 };
    case 'DECREMENT':
      return { count: state.count - 1 };
    case 'RESET':
      return { count: 0 };
    case 'SET':
      return { count: action.payload };
    default:
      throw new Error(`Unknown action: ${action.type}`);
  }
}

// Example 2: Todo list with reducer
function todoReducer(state, action) {
  switch (action.type) {
    case 'ADD_TODO':
      return {
        ...state,
        todos: [...state.todos, { id: Date.now(), text: action.payload, completed: false }]
      };
    case 'TOGGLE_TODO':
      return {
        ...state,
        todos: state.todos.map(todo =>
          todo.id === action.payload ? { ...todo, completed: !todo.completed } : todo
        )
      };
    case 'DELETE_TODO':
      return {
        ...state,
        todos: state.todos.filter(todo => todo.id !== action.payload)
      };
    case 'SET_FILTER':
      return {
        ...state,
        filter: action.payload
      };
    default:
      return state;
  }
}

function UseReducerExamples() {
  // Counter example
  const [counterState, counterDispatch] = useReducer(
    counterReducer,
    { count: 0 }
  );

  // Todo example
  const [todoState, todoDispatch] = useReducer(
    todoReducer,
    { todos: [], filter: 'all' }
  );

  const [newTodo, setNewTodo] = useState('');

  const handleAddTodo = () => {
    if (newTodo.trim()) {
      todoDispatch({ type: 'ADD_TODO', payload: newTodo });
      setNewTodo('');
    }
  };

  const filteredTodos = todoState.todos.filter(todo => {
    if (todoState.filter === 'completed') return todo.completed;
    if (todoState.filter === 'active') return !todo.completed;
    return true;
  });

  return (
    <div>
      <h3>useReducer Examples</h3>

      {/* Counter */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Counter with useReducer</h4>
        <p>Count: {counterState.count}</p>
        <button onClick={() => counterDispatch({ type: 'INCREMENT' })}>
          +1
        </button>
        <button onClick={() => counterDispatch({ type: 'DECREMENT' })} style={{ marginLeft: '8px' }}>
          -1
        </button>
        <button onClick={() => counterDispatch({ type: 'SET', payload: 10 })} style={{ marginLeft: '8px' }}>
          Set to 10
        </button>
        <button onClick={() => counterDispatch({ type: 'RESET' })} style={{ marginLeft: '8px' }}>
          Reset
        </button>
      </div>

      {/* Todo List */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Todo List with useReducer</h4>
        <div style={{ marginBottom: '10px' }}>
          <input
            type="text"
            value={newTodo}
            onChange={(e) => setNewTodo(e.target.value)}
            onKeyPress={(e) => e.key === 'Enter' && handleAddTodo()}
            placeholder="Add a todo..."
            style={{ marginRight: '8px', padding: '4px' }}
          />
          <button onClick={handleAddTodo}>Add</button>
        </div>

        <div style={{ marginBottom: '10px' }}>
          <button
            onClick={() => todoDispatch({ type: 'SET_FILTER', payload: 'all' })}
            style={{
              fontWeight: todoState.filter === 'all' ? 'bold' : 'normal',
              marginRight: '8px'
            }}
          >
            All ({todoState.todos.length})
          </button>
          <button
            onClick={() => todoDispatch({ type: 'SET_FILTER', payload: 'active' })}
            style={{
              fontWeight: todoState.filter === 'active' ? 'bold' : 'normal',
              marginRight: '8px'
            }}
          >
            Active ({todoState.todos.filter(t => !t.completed).length})
          </button>
          <button
            onClick={() => todoDispatch({ type: 'SET_FILTER', payload: 'completed' })}
            style={{
              fontWeight: todoState.filter === 'completed' ? 'bold' : 'normal'
            }}
          >
            Completed ({todoState.todos.filter(t => t.completed).length})
          </button>
        </div>

        <ul style={{ listStyle: 'none', padding: 0 }}>
          {filteredTodos.length === 0 ? (
            <li>No todos to display</li>
          ) : (
            filteredTodos.map(todo => (
              <li key={todo.id} style={{ marginBottom: '8px' }}>
                <input
                  type="checkbox"
                  checked={todo.completed}
                  onChange={() => todoDispatch({ type: 'TOGGLE_TODO', payload: todo.id })}
                  style={{ marginRight: '8px' }}
                />
                <span style={{ textDecoration: todo.completed ? 'line-through' : 'none' }}>
                  {todo.text}
                </span>
                <button
                  onClick={() => todoDispatch({ type: 'DELETE_TODO', payload: todo.id })}
                  style={{ marginLeft: '8px', color: 'red' }}
                >
                  Delete
                </button>
              </li>
            ))
          )}
        </ul>
      </div>

      {/* Explanation */}
      <div style={{ marginBottom: '20px', padding: '10px', backgroundColor: '#f0f0f0' }}>
        <h4>Why use useReducer?</h4>
        <ul style={{ textAlign: 'left' }}>
          <li>Complex state logic with multiple sub-values</li>
          <li>State updates depend on previous state</li>
          <li>Multiple ways to update the same state</li>
          <li>Easier to test (pure reducer functions)</li>
          <li>Better for managing related state together</li>
        </ul>
      </div>
    </div>
  );
}

export default UseReducerExamples;
