import React, { useState } from 'react';
import ChildAdd from './ChildAdd';
import ChildRemove from './ChildRemove';
import './Parent.css';

function Parent() {
  // State to hold the array of entries
  const [entries, setEntries] = useState([]);

  /**
   * Adds a new entry to the array
   * Uses spread operator [...entries, entry] to create a new array
   * This is immutable - doesn't modify the original array
   */
  const handlerAdd = (entry) => {

    debugger;

    setEntries([...entries, entry]);
  }

  /**
   * Removes an entry from the array by index
   * Uses filter() to create a new array without the specified index
   * filter() returns a new array, keeping immutability
   */
  const handlerRemove = (index) => {

    debugger;

    setEntries(entries.filter((_, i) => i !== index));
  }

  return (
    <div className="container">
      <h1 className="title">Parent/Child communication</h1>
      <div className="childrenContainer">
        <ChildAdd entries={entries} addEntry={handlerAdd}></ChildAdd>
        <ChildRemove entries={entries} removeEntry={handlerRemove}></ChildRemove>
      </div>
    </div>
  );
}

export default Parent;