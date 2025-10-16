import React from 'react';

export default function UserStatus({ user }) {
  if (!user) {
    return <div>Please sign in.</div>;
  } else {
    return (
      <div>
        {user.name}: {user.isAdmin ? <strong>Admin</strong> : <span>User</span>}
        {user.notifications && user.notifications.length > 0 && (
          <span> ({user.notifications.length})</span>
        )}
      </div>
    );
  }
}
