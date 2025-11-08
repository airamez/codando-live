import { useState, useMemo } from 'react';
import './hooks.css';

function UseMemo() {
  const [count, setCount] = useState(0);
  const [items] = useState(() =>
    Array.from({ length: 1000 }, (_, i) => ({
      id: i,
      name: `Item ${i}`,
      value: Math.floor(Math.random() * 1000)
    }))
  );
  const [searchTerm, setSearchTerm] = useState('');
  const [sortOrder, setSortOrder] = useState('asc');

  // Example 1: Expensive calculation
  // Without useMemo, this runs on every render (even when count changes)
  const expensiveCalculation = useMemo(() => {
    console.log('Running expensive calculation...');
    let result = 0;
    for (let i = 0; i < 1000000; i++) {
      result += i;
    }
    return result;
  }, []); // Empty array = calculate once

  // Example 2: Filtered list
  const filteredItems = useMemo(() => {
    console.log('Filtering items...');
    return items.filter(item =>
      item.name.toLowerCase().includes(searchTerm.toLowerCase())
    );
  }, [items, searchTerm]);

  // Example 3: Sorted and filtered list
  const sortedAndFilteredItems = useMemo(() => {
    console.log('Sorting and filtering...');
    const filtered = items.filter(item =>
      item.name.toLowerCase().includes(searchTerm.toLowerCase())
    );

    return filtered.sort((a, b) => {
      if (sortOrder === 'asc') {
        return a.value - b.value;
      } else {
        return b.value - a.value;
      }
    });
  }, [items, searchTerm, sortOrder]);

  // Example 4: Derived statistics
  const statistics = useMemo(() => {
    console.log('Calculating statistics...');
    const values = filteredItems.map(item => item.value);
    const sum = values.reduce((acc, val) => acc + val, 0);
    const avg = values.length > 0 ? sum / values.length : 0;
    const max = values.length > 0 ? Math.max(...values) : 0;
    const min = values.length > 0 ? Math.min(...values) : 0;

    return { sum, avg, max, min, count: values.length };
  }, [filteredItems]);

  return (
    <div className="hook-example-section">
      <h3>useMemo Examples</h3>

      {/* Trigger re-renders */}
      <div className="hook-example-section">
        <h4>Trigger Re-render</h4>
        <p>Count: {count} (triggers re-render but not recalculation)</p>
        <button onClick={() => setCount(count + 1)}>Increment Count</button>
        <p><small>Check console - memoized values don't recalculate!</small></p>
      </div>

      {/* Expensive calculation */}
      <div className="hook-example-section">
        <h4>Expensive Calculation (cached)</h4>
        <p>Result: {expensiveCalculation}</p>
        <p><small>This only calculates once, not on every render!</small></p>
      </div>

      {/* Filtered and sorted list */}
      <div className="hook-example-section">
        <h4>Filtered & Sorted Items</h4>
        <input
          type="text"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          placeholder="Search items..."
          className="use-memo-input"
        />
        <button onClick={() => setSortOrder(sortOrder === 'asc' ? 'desc' : 'asc')}>
          Sort: {sortOrder === 'asc' ? '↑ Ascending' : '↓ Descending'}
        </button>

        <div className="use-memo-stats">
          <h5>Statistics</h5>
          <p>Count: {statistics.count}</p>
          <p>Sum: {statistics.sum}</p>
          <p>Average: {statistics.avg.toFixed(2)}</p>
          <p>Max: {statistics.max}</p>
          <p>Min: {statistics.min}</p>
        </div>

        <div className="use-memo-items-container">
          {sortedAndFilteredItems.slice(0, 20).map(item => (
            <div key={item.id} className="use-memo-item">
              {item.name} - Value: {item.value}
            </div>
          ))}
        </div>
        <p>Showing 20 of {sortedAndFilteredItems.length} items</p>
      </div>

      {/* Explanation */}
      <div className="use-memo-explanation">
        <h4>When to use useMemo?</h4>
        <ul style={{ textAlign: 'left' }}>
          <li>Expensive calculations that don't need to run every render</li>
          <li>Filtering or sorting large datasets</li>
          <li>Complex derived state calculations</li>
          <li>Preventing unnecessary child re-renders (pass memoized objects)</li>
          <li><strong>Don't overuse:</strong> Simple calculations are faster without useMemo</li>
        </ul>
      </div>
    </div>
  );
}

export default UseMemo;
