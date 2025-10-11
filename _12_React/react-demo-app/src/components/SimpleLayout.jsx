import React from 'react';

export default function SimpleLayout() {
  const header = <h1>My Header</h1>;
  const content = (
    <div>
      <ul>
        <li>Apples</li>
        <li>Bananas</li>
        <li>Cherries</li>
        <li>Oranges</li>
      </ul>
    </div>
  );
  const footer = (
    <div>
      <small>Static Footer — © 2025</small>
    </div>
  );

  return (
    <>
      {header}
      {content}
      {footer}
    </>
  );
}
