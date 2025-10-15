import React from 'react';

export default function Price({ amount = 0, taxRate = 0.1 }) {
  const total = (amount * (1 + taxRate)).toFixed(2);

  return (
    <table style={{ borderCollapse: 'collapse', borderWidth: '2px', borderColor: 'yellow', borderStyle: 'solid', marginBottom: 12 }}>
      <tbody>
        <tr>
          <td>Amount:</td>
          <td>Tax:</td>
          <td>Total:</td>
        </tr>
        <tr>
          <td>${amount.toFixed(2)}</td>
          <td>${(amount * taxRate).toFixed(2)}</td>
          <td>${total}</td>
        </tr>
      </tbody>
    </table>
  );
}
