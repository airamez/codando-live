export default function TodoList({ todos = [] }) {
  return (
    <div>
      <ul>
        {todos.map((todo) => (
          <li key={todo.id}>{todo.title} Due: {todo.due}</li>
        ))}
      </ul>
      <select>
        {todos.map((todo) => (
          <option key={todo.id} value={todo.id}>
            {todo.title}
          </option>
        ))}
      </select>
    </div>
  );
}
