import React, { useState } from 'react';

export default function Counter() {
  const [n, setN] = useState(0);

  function sayHello() {
    // show a user-visible alert when clicked
    alert('Hello from Counter');
  }

  return (
    <div>
      <button onClick={() => setN((s) => s + 1)}>+1</button>
      <span style={{ marginLeft: 8 }}>Count: {n}</span>
      <button onClick={sayHello} style={{ marginLeft: 12 }}>Log Hello</button>
    </div>
  );
}
