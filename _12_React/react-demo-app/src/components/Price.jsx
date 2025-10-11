import React from 'react';

export default function Price({ amount = 0, taxRate = 0.1 }) {
  const total = (amount * (1 + taxRate)).toFixed(2);

  return (
    <div>
      Total: ${total} = ({amount} + {taxRate})
    </div>
  );
}
