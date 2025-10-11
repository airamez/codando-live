import React from 'react';

export default function TodoListWithLoop({ todos = [] }) {
  const items = [];
  for (let i = 0; i < todos.length; i++) {
    const todo = todos[i];
    // example: skip hidden items or apply per-item logic
    if (todo.hidden) continue;
    const key = todo.id ?? i;
    items.push(<li key={key}>{todo.title}</li>);
  }
  return <ul>{items}</ul>;
}
