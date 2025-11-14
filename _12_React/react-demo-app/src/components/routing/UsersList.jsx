import { Link } from 'react-router-dom';

function UsersList({ users, loading }) {
  if (loading) {
    return <div>Loading users...</div>;
  }

  return (
    <div>
      <h2>Users List</h2>
      <p>Click on the "Show Posts" button to view user posts:</p>
      <table className="data-table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Username</th>
            <th>Email</th>
            <th>Company</th>
            <th>City</th>
            <th className="center">Actions</th>
          </tr>
        </thead>
        <tbody>
          {users.map(user => (
            <tr key={user.id}>
              <td className="bold">{user.name}</td>
              <td>{user.username}</td>
              <td>{user.email}</td>
              <td>{user.company.name}</td>
              <td>{user.address.city}</td>
              <td className="center">
                <Link to={`/routing/users/${user.id}`}>
                  <button className="btn btn-primary">
                    Show Posts
                  </button>
                </Link>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default UsersList;
