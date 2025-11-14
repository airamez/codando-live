import { Routes, Route } from 'react-router-dom';
import UsersList from './UsersList';
import UserPosts from './UserPosts';

function Users({ users, loading }) {
  return (
    <Routes>
      <Route index element={<UsersList users={users} loading={loading} />} />
      <Route path=":userId" element={<UserPosts users={users} />} />
    </Routes>
  );
}

export default Users;
