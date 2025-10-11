import React from 'react';

export default function ChoiceContent({ choice = 1 }) {
  const content = (() => {
    switch (choice) {
      case 1:
        return <p>Tip: Break large tasks into 25-minute focused blocks to stay productive.</p>;
      case 2:
        return <p>Quote: "Simplicity is the soul of efficiency." — keep your components small.</p>;
      case 3:
        return <p>News: The build finished successfully — check the dev server at http://localhost:5173.</p>;
      case 4:
        return <p>Reminder: Commit early and often with clear messages to keep history useful.</p>;
      case 5:
        return <p>Suggestion: Add unit tests for edge cases like empty arrays and null props.</p>;
      default:
        return <p>Nothing to show.</p>;
    }
  })();

  return (
    <section>
      <h3>Selected content ({choice})</h3>
      {content}
    </section>
  );
}
