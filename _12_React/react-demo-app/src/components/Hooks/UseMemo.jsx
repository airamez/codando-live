import { useState, useEffect, useMemo } from 'react';
import './hooks.css';

function UseMemo() {
  const [todos, setTodos] = useState([]);
  const [loading, setLoading] = useState(true);
  const [refreshTrigger, setRefreshTrigger] = useState(0);
  const [renderCount, setRenderCount] = useState(0);

  // Fetch todos from API on component mount or when refreshTrigger changes
  useEffect(() => {
    const fetchTodos = async () => {
      setLoading(true);
      try {
        const response = await fetch('https://jsonplaceholder.typicode.com/todos');
        const data = await response.json();
        setTodos(data);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching todos:', error);
        setLoading(false);
      }
    };

    fetchTodos();
  }, [refreshTrigger]); // Re-fetch when refreshTrigger changes

  // useMemo: Process todos to generate statistics
  // This expensive calculation only runs when todos change, not on every render
  const todoStats = useMemo(() => {
    console.log('📊 Processing todo statistics...');
    const completed = todos.filter(todo => todo.completed).length;
    const pending = todos.length - completed;
    const completionRate = todos.length > 0 ? ((completed / todos.length) * 100).toFixed(1) : 0;

    // Group todos by userId using reduce
    // acc (accumulator) starts as an empty object {}
    // For each todo, we create/update a user entry with their stats
    const byUser = todos.reduce((summary, todo) => {
      // If this user doesn't exist in accumulator yet, initialize their stats
      if (!summary[todo.userId]) {
        summary[todo.userId] = { completed: 0, pending: 0, total: 0 };
      }
      // Increment total count for this user
      summary[todo.userId].total++;
      // Increment either completed or pending count based on todo status
      if (todo.completed) {
        summary[todo.userId].completed++;
      } else {
        summary[todo.userId].pending++;
      }
      // Return accumulator for next iteration
      return summary;
    }, {}); // Initial value: empty object

    return {
      total: todos.length,
      completed,
      pending,
      completionRate,
      byUser
    };
  }, [todos]); // Only recalculate when todos change

  if (loading) return <div className="hook-example-section">Loading todos...</div>;

  return (
    <div className="hook-example-section">
      <h3>useMemo Example - Todo Statistics</h3>
      <div className="hook-example-section">
        <button onClick={() => setRefreshTrigger(refreshTrigger + 1)}>
          Refresh Todos
        </button>
        <button onClick={() => setRenderCount(renderCount + 1)} style={{ marginLeft: '10px' }}>
          Force Re-render ({renderCount})
        </button>
        <div className="use-memo-stats-grid">
          <div className="use-memo-stat-card total">
            <div className="use-memo-stat-value">{todoStats.total}</div>
            <div className="use-memo-stat-label">Total Todos</div>
          </div>
          <div className="use-memo-stat-card completed">
            <div className="use-memo-stat-value">{todoStats.completed}</div>
            <div className="use-memo-stat-label">Completed</div>
          </div>
          <div className="use-memo-stat-card pending">
            <div className="use-memo-stat-value">{todoStats.pending}</div>
            <div className="use-memo-stat-label">Pending</div>
          </div>
          <div className="use-memo-stat-card rate">
            <div className="use-memo-stat-value">{todoStats.completionRate}%</div>
            <div className="use-memo-stat-label">Completion Rate</div>
          </div>
        </div>

        <h4>Statistics by User</h4>
        <div className="use-memo-todos-container use-memo-table-container">
          <table className="use-memo-table">
            <thead>
              <tr>
                <th>User ID</th>
                <th>Total</th>
                <th>Completed</th>
                <th>Pending</th>
                <th>Completion %</th>
              </tr>
            </thead>
            <tbody>
              {Object.entries(todoStats.byUser).map(([userId, stats]) => (
                <tr key={userId}>
                  <td>User {userId}</td>
                  <td className="center">{stats.total}</td>
                  <td className="center completed-text">{stats.completed}</td>
                  <td className="center pending-text">{stats.pending}</td>
                  <td className="center">
                    {((stats.completed / stats.total) * 100).toFixed(1)}%
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

export default UseMemo;
