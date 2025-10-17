export default function TodoListWithLoop({ todos = [] }) {

  // List
  const listItems = [];
  for (let i = 0; i < todos.length; i++) {
    const todo = todos[i];
    // example: skip hidden items or apply per-item logic
    if (todo.hidden) continue;
    const key = todo.id ?? i;
    listItems.push(<li key={key}>{todo.title}</li>);
  }
  const list = <ul>{listItems}</ul>;

  // Select (dropdown)
  const selectItems = [];
  for (let i = 0; i < todos.length; i++) {
    const todo = todos[i];
    // example: skip hidden items or apply per-item logic
    if (todo.hidden) continue;
    const key = todo.id ?? i;
    selectItems.push(
      <option key={key} value={todo.id}>
        {todo.title}
      </option>
    );
  }
  const select = <select>{selectItems}</select>;

  return (
    <>
      {list}
      {select}
    </>
  );
}
