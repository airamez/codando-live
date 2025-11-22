import { useState, useEffect } from 'react';
import {
  FluentProvider,
  webDarkTheme,
  Card,
  Title3,
} from '@fluentui/react-components';
import { useStyles } from './styles';
import SearchBar from './SearchBar';
import AddUserDialog from './AddUserDialog';
import EditUserDialog from './EditUserDialog';
import UserTable from './UserTable';

function FluentUIDemo() {
  const styles = useStyles();
  const [searchTerm, setSearchTerm] = useState('');
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [selectedUsers, setSelectedUsers] = useState(new Set());
  const [sortColumn, setSortColumn] = useState('name');
  const [sortDirection, setSortDirection] = useState('ascending');
  const [isEditDialogOpen, setIsEditDialogOpen] = useState(false);
  const [editingUser, setEditingUser] = useState(null);

  // Fetch users from JSONPlaceholder API
  useEffect(() => {
    fetch('https://jsonplaceholder.typicode.com/users')
      .then(response => response.json())
      .then(data => {
        setUsers(data);
        setLoading(false);
      })
      .catch(error => {
        console.error('Error fetching users:', error);
        setLoading(false);
      });
  }, []);

  const handleCheckboxChange = (userId, checked) => {
    const newSelected = new Set(selectedUsers);
    if (checked) {
      newSelected.add(userId);
    } else {
      newSelected.delete(userId);
    }
    setSelectedUsers(newSelected);
  };

  const handleSelectAll = (checked) => {
    if (checked) {
      setSelectedUsers(new Set(filteredUsers.map(user => user.id)));
    } else {
      setSelectedUsers(new Set());
    }
  };

  const handleDeleteSelected = () => {
    const newUsers = users.filter(user => !selectedUsers.has(user.id));
    setUsers(newUsers);
    setSelectedUsers(new Set());
  };

  const handleAddUser = (newUser) => {
    const userWithId = {
      ...newUser,
      id: Math.max(...users.map(u => u.id), 0) + 1,
    };
    setUsers([...users, userWithId]);
  };

  const handleEditUser = (user) => {
    setEditingUser(user);
    setIsEditDialogOpen(true);
  };

  const handleSaveEditUser = (updatedUser) => {
    const updatedUsers = users.map(user =>
      user.id === updatedUser.id ? updatedUser : user
    );
    setUsers(updatedUsers);
    setIsEditDialogOpen(false);
    setEditingUser(null);
  };

  const handleCancelEditUser = () => {
    setIsEditDialogOpen(false);
    setEditingUser(null);
  };

  const handleSort = (column) => {
    if (sortColumn === column) {
      setSortDirection(sortDirection === 'ascending' ? 'descending' : 'ascending');
    } else {
      setSortColumn(column);
      setSortDirection('ascending');
    }
  };

  // Filter users based on search term
  const filteredUsers = users.filter(user =>
    user.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
    user.email.toLowerCase().includes(searchTerm.toLowerCase()) ||
    user.username.toLowerCase().includes(searchTerm.toLowerCase())
  );

  // Sort filtered users
  const sortedUsers = [...filteredUsers].sort((a, b) => {
    const aValue = a[sortColumn].toLowerCase();
    const bValue = b[sortColumn].toLowerCase();

    if (sortDirection === 'ascending') {
      return aValue < bValue ? -1 : aValue > bValue ? 1 : 0;
    } else {
      return aValue > bValue ? -1 : aValue < bValue ? 1 : 0;
    }
  });

  return (
    <FluentProvider theme={webDarkTheme}>
      <div className={styles.container}>
        <Title3>Fluent UI React Components Demo</Title3>

        {/* Add User and Search Section */}
        <Card className={styles.card}>
          <div className={styles.section}>
            <Title3>User Management</Title3>
            <div className={styles.inputGroup}>
              <SearchBar
                searchTerm={searchTerm}
                onSearchChange={setSearchTerm}
              />
              <AddUserDialog onAddUser={handleAddUser} />
            </div>
          </div>
        </Card>

        {/* Table Section */}
        <Card className={styles.card}>
          <div className={styles.section}>
            <UserTable
              users={sortedUsers}
              loading={loading}
              selectedUsers={selectedUsers}
              onCheckboxChange={handleCheckboxChange}
              onSelectAll={handleSelectAll}
              onDeleteSelected={handleDeleteSelected}
              onEditUser={handleEditUser}
              sortColumn={sortColumn}
              sortDirection={sortDirection}
              onSort={handleSort}
            />
          </div>
        </Card>

        {/* Edit User Dialog */}
        <EditUserDialog
          isOpen={isEditDialogOpen}
          user={editingUser}
          onSave={handleSaveEditUser}
          onCancel={handleCancelEditUser}
        />
      </div>
    </FluentProvider>
  );
}

export default FluentUIDemo;
