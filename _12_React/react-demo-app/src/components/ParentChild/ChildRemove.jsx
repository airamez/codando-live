import React, { useState } from 'react';
import './ChildRemove.css';

function ChildRemove({ entries = [], removeEntry }) {
  // Local state to track which entry is selected in the dropdown
  const [selectedIndex, setSelectedIndex] = useState('');

  /**
   * Handles removing the selected entry from the parent's array
   * Converts selectedIndex from string to integer
   * Clears the selection after removal
   */
  const handleRemove = () => {

    debugger;

    if (selectedIndex !== '') {
      removeEntry(parseInt(selectedIndex));
      setSelectedIndex('');
    }
  };

  return (
    <div className="container">
      <h2 className="title">Remove Entry</h2>
      <div className="selectContainer">
        <select
          value={selectedIndex}
          onChange={(e) => setSelectedIndex(e.target.value)}
          className="select"
        >
          <option value="">Select an entry to remove...</option>
          {entries.map((entry, index) => (
            <option key={index} value={index}>
              {entry}
            </option>
          ))}
        </select>
        <button
          onClick={handleRemove}
          disabled={selectedIndex === ''}
          className="button"
        >
          Remove
        </button>
      </div>
    </div>
  );
}

export default ChildRemove;