import React from 'react';

export default function ExampleComments() {
  // JS-level comments
  const count = 1;
  /*
    Multi-line JS comment:
   */

  return (
    <div>
      {/* JSX comment: explains the header */}
      <h1>Inbox</h1>

      {/* Multi-line JSX comment:
          - used to document groups of elements
          - keeps intent near the markup
       */}
      <ul>
        <li>Message 1</li>
        <li>Message 2</li>
      </ul>

      {/* Commenting out an element */}
      {/* <LegacyBadge /> */}

      <div>Count example: {count}</div>
    </div>
  );
}
