import React from 'react';

export default function ExampleFunctionsReturnJSX({ comment = { author: 'Bob', time: '2h', text: 'Looks good!' } }) {
  // helper function that accepts parameters and returns JSX
  function Meta(author, time) {
    return (
      <div className="meta" style={{ color: '#666', fontSize: 12 }}>
        {author} • {time}
      </div>
    );
  }

  return (
    <article style={{ border: '1px solid #eee', padding: 8, borderRadius: 6 }}>
      <p style={{ margin: 0 }}>{comment.text}</p>
      {/* call the helper with parameters */}
      {Meta(comment.author, comment.time)}
    </article>
  );
}
