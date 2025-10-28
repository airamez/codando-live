import React, { useState } from 'react';
import './ChildAdd.css';

function ChildAdd({ entries = [], addEntry }) {
  // Local state for the input field
  const [inputValue, setInputValue] = useState('');

  /**
   * Handles adding a new entry to the parent's array
   * Validates input is not empty before adding
   * Clears the input field after adding
   */
  const handleAdd = () => {

    debugger;

    if (inputValue.trim()) {
      addEntry(inputValue);
      setInputValue('');
    }
  };

  /**
   * Allows adding entry by pressing Enter key
   */
  const handleKeyPress = (e) => {
    if (e.key === 'Enter') {
      handleAdd();
    }
  };

  return (
    <div className="container">
      <h2 className="title">Add Entry</h2>
      <div className="inputContainer">
        <input
          type="text"
          value={inputValue}
          onChange={(event) => setInputValue(event.target.value)}
          onKeyUp={handleKeyPress}
          placeholder="New Entry value..."
          className="input"
        />
        <button onClick={handleAdd} className="button">Add</button>
      </div>
      <h3 className="listTitle">Entries ({entries.length})</h3>
      <ul className="list">
        {entries.map((entry, index) => (
          <li key={index} className="listItem">{entry}</li>
        ))}
      </ul>
    </div>
  );
}

export default ChildAdd;