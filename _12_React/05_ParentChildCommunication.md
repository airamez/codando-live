# 10. Parent/Child communication

Parent/Child communication demonstrates how data and functions flow between components in React's unidirectional architecture. Parents pass data and callback functions to children via props, and children notify parents of user actions by invoking those callbacks.

**Key Concepts:**
- **Props down**: Parent passes data (state) and functions to children
- **Callbacks up**: Children call parent functions to trigger state changes
- **Shared state**: Parent maintains state that multiple children need to access or modify
- **Array operations**: Demonstrates immutable array manipulation (spread operator, filter)
- **Single source of truth**: Parent owns the state, children display and interact with it

**Communication Pattern:**
```
Parent (owns state)
  ↓ props (data + callbacks)
Child 1 (displays + modifies)    Child 2 (displays + modifies)
  ↑ callbacks (notify parent)      ↑ callbacks (notify parent)
```

Example (component: `Parent.jsx`, `ChildAdd.jsx`, `ChildRemove.jsx`):

**Parent Component** - Manages shared state and provides handlers:

```jsx
import React, { useState } from 'react';
import ChildAdd from './ChildAdd';
import ChildRemove from './ChildRemove';
import './Parent.css';

function Parent() {
  // State to hold the array of entries (shared between children)
  const [entries, setEntries] = useState([]);

  /**
   * Adds a new entry to the array
   * Uses spread operator [...entries, entry] to create a new array
   * This is immutable - doesn't modify the original array
   */
  const handlerAdd = (entry) => {
    setEntries([...entries, entry]);
  }

  /**
   * Removes an entry from the array by index
   * Uses filter() to create a new array without the specified index
   * filter() returns a new array, keeping immutability
   */
  const handlerRemove = (index) => {
    setEntries(entries.filter((_, i) => i !== index));
  }

  return (
    <div className="container">
      <h1 className="title">Parent/Child communication</h1>
      <div className="childrenContainer">
        {/* Pass state and callbacks to children */}
        <ChildAdd entries={entries} addEntry={handlerAdd} />
        <ChildRemove entries={entries} removeEntry={handlerRemove} />
      </div>
    </div>
  );
}

export default Parent;
```

**Child Component 1** - Adds entries by calling parent's callback:

```jsx
import React, { useState } from 'react';
import './ChildAdd.css';

function ChildAdd({ entries = [], addEntry }) {
  // Local state for the input field (child's own state)
  const [inputValue, setInputValue] = useState('');

  /**
   * Handles adding a new entry to the parent's array
   * Validates input is not empty before adding
   * Clears the input field after adding
   */
  const handleAdd = () => {
    if (inputValue.trim()) {
      addEntry(inputValue);  // Call parent's function
      setInputValue('');     // Clear local state
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
        {/* Display parent's data */}
        {entries.map((entry, index) => (
          <li key={index} className="listItem">{entry}</li>
        ))}
      </ul>
    </div>
  );
}

export default ChildAdd;
```

**Child Component 2** - Removes entries by calling parent's callback:

```jsx
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
    if (selectedIndex !== '') {
      removeEntry(parseInt(selectedIndex));  // Call parent's function
      setSelectedIndex('');                  // Clear local state
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
          {/* Display parent's data in dropdown */}
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
```

**How It Works:**

1. **Parent owns the state**: `entries` array is stored in Parent component
2. **Parent passes data down**: Both children receive `entries` via props
3. **Parent passes callbacks**: `handlerAdd` and `handlerRemove` passed as props
4. **Children have local state**: Each child manages its own UI state (input value, selected index)
5. **Children notify parent**: When user acts, children call parent's callback functions
6. **Parent updates state**: Parent's setState triggers re-render
7. **Children re-render**: With new props, both children display updated data

**Why This Pattern:**
- **Single source of truth**: Parent owns the data, avoiding sync issues
- **Separation of concerns**: Each child handles its own UI logic
- **Reusability**: Children don't care who their parent is
- **Predictability**: Data flows one direction, making debugging easier
- **Immutability**: Array operations create new arrays, following React best practices
