import { useState, useEffect } from 'react';
import {
  FluentProvider,
  webDarkTheme,
  Button,
  Input,
  Checkbox,
  Card,
  Table,
  TableBody,
  TableCell,
  TableRow,
  TableHeader,
  TableHeaderCell,
  Spinner,
  Title3,
  Body1,
  makeStyles,
  tokens,
  Dialog,
  DialogTrigger,
  DialogSurface,
  DialogTitle,
  DialogBody,
  DialogActions,
  DialogContent,
  Field,
  Label,
  TableCellLayout,
  Avatar,
  Badge,
} from '@fluentui/react-components';
import {
  AddRegular,
  DeleteRegular,
  SearchRegular,
  PersonRegular,
  MailRegular,
  PhoneRegular,
  GlobeRegular,
  EditRegular,
} from '@fluentui/react-icons';

const useStyles = makeStyles({
  container: {
    padding: tokens.spacingVerticalXXL,
    maxWidth: '1400px',
    margin: '0 auto',
  },
  section: {
    marginBottom: tokens.spacingVerticalXXL,
  },
  buttonGroup: {
    display: 'flex',
    gap: tokens.spacingHorizontalM,
    marginTop: tokens.spacingVerticalM,
    flexWrap: 'wrap',
  },
  inputGroup: {
    display: 'flex',
    gap: tokens.spacingHorizontalM,
    marginTop: tokens.spacingVerticalM,
    alignItems: 'center',
    flexWrap: 'wrap',
  },
  checkboxGroup: {
    display: 'flex',
    flexDirection: 'column',
    gap: tokens.spacingVerticalS,
    marginTop: tokens.spacingVerticalM,
  },
  table: {
    marginTop: tokens.spacingVerticalM,
    borderRadius: tokens.borderRadiusMedium,
    overflow: 'hidden',
  },
  tableHeaderCell: {
    fontWeight: tokens.fontWeightSemibold,
    backgroundColor: tokens.colorNeutralBackground3,
    paddingTop: tokens.spacingVerticalM,
    paddingBottom: tokens.spacingVerticalM,
    ':hover': {
      backgroundColor: tokens.colorNeutralBackground3Hover,
    },
  },
  tableRow: {
    transition: 'background-color 0.2s ease',
    ':hover': {
      backgroundColor: tokens.colorNeutralBackground1Hover,
    },
  },
  tableCell: {
    paddingTop: tokens.spacingVerticalM,
    paddingBottom: tokens.spacingVerticalM,
  },
  loadingContainer: {
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
    padding: tokens.spacingVerticalXXL,
  },
  card: {
    padding: tokens.spacingVerticalL,
  },
  nameCell: {
    fontWeight: tokens.fontWeightSemibold,
  },
  emailCell: {
    color: tokens.colorBrandForeground1,
  },
});

function FluentUIDemo() {
  const styles = useStyles();
  const [searchTerm, setSearchTerm] = useState('');
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [selectedUsers, setSelectedUsers] = useState(new Set());
  const [sortColumn, setSortColumn] = useState('name');
  const [sortDirection, setSortDirection] = useState('ascending');
  const [isDialogOpen, setIsDialogOpen] = useState(false);
  const [isEditDialogOpen, setIsEditDialogOpen] = useState(false);
  const [editingUser, setEditingUser] = useState(null);

  // New user form fields
  const [newUserName, setNewUserName] = useState('');
  const [newUserUsername, setNewUserUsername] = useState('');
  const [newUserEmail, setNewUserEmail] = useState('');
  const [newUserPhone, setNewUserPhone] = useState('');
  const [newUserWebsite, setNewUserWebsite] = useState('');

  // Edit user form fields
  const [editUserName, setEditUserName] = useState('');
  const [editUserUsername, setEditUserUsername] = useState('');
  const [editUserEmail, setEditUserEmail] = useState('');
  const [editUserPhone, setEditUserPhone] = useState('');
  const [editUserWebsite, setEditUserWebsite] = useState('');

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

  const handleAddUser = () => {
    if (newUserName.trim() && newUserUsername.trim() && newUserEmail.trim()) {
      const newUser = {
        id: Math.max(...users.map(u => u.id), 0) + 1,
        name: newUserName.trim(),
        username: newUserUsername.trim(),
        email: newUserEmail.trim(),
        phone: newUserPhone.trim() || 'N/A',
        website: newUserWebsite.trim() || 'N/A',
      };
      setUsers([...users, newUser]);

      // Reset form
      setNewUserName('');
      setNewUserUsername('');
      setNewUserEmail('');
      setNewUserPhone('');
      setNewUserWebsite('');
      setIsDialogOpen(false);
    }
  };

  const handleCancelAddUser = () => {
    // Reset form
    setNewUserName('');
    setNewUserUsername('');
    setNewUserEmail('');
    setNewUserPhone('');
    setNewUserWebsite('');
    setIsDialogOpen(false);
  };

  const isFormValid = newUserName.trim() && newUserUsername.trim() && newUserEmail.trim();

  const handleEditUser = (user) => {
    setEditingUser(user);
    setEditUserName(user.name);
    setEditUserUsername(user.username);
    setEditUserEmail(user.email);
    setEditUserPhone(user.phone);
    setEditUserWebsite(user.website);
    setIsEditDialogOpen(true);
  };

  const handleSaveEditUser = () => {
    if (editUserName.trim() && editUserUsername.trim() && editUserEmail.trim()) {
      const updatedUsers = users.map(user =>
        user.id === editingUser.id
          ? {
            ...user,
            name: editUserName.trim(),
            username: editUserUsername.trim(),
            email: editUserEmail.trim(),
            phone: editUserPhone.trim() || 'N/A',
            website: editUserWebsite.trim() || 'N/A',
          }
          : user
      );
      setUsers(updatedUsers);
      handleCancelEditUser();
    }
  };

  const handleCancelEditUser = () => {
    setEditingUser(null);
    setEditUserName('');
    setEditUserUsername('');
    setEditUserEmail('');
    setEditUserPhone('');
    setEditUserWebsite('');
    setIsEditDialogOpen(false);
  };

  const isEditFormValid = editUserName.trim() && editUserUsername.trim() && editUserEmail.trim();

  const handleSort = (column) => {
    if (sortColumn === column) {
      // Toggle direction if clicking the same column
      setSortDirection(sortDirection === 'ascending' ? 'descending' : 'ascending');
    } else {
      // New column, default to ascending
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

  const allSelected = filteredUsers.length > 0 && filteredUsers.every(user => selectedUsers.has(user.id));
  const someSelected = filteredUsers.some(user => selectedUsers.has(user.id)) && !allSelected;

  const getSortIcon = (column) => {
    if (sortColumn !== column) return '';
    return sortDirection === 'ascending' ? ' ▲' : ' ▼';
  };

  const getInitials = (name) => {
    return name
      .split(' ')
      .map(word => word[0])
      .join('')
      .toUpperCase()
      .substring(0, 2);
  };

  return (
    <FluentProvider theme={webDarkTheme}>
      <div className={styles.container}>
        <Title3>Fluent UI React Components Demo</Title3>

        {/* Add User and Search Section */}
        <Card className={styles.card}>
          <div className={styles.section}>
            <Title3>User Management</Title3>
            <div className={styles.inputGroup}>
              <Input
                placeholder="Search users..."
                contentBefore={<SearchRegular />}
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                style={{ minWidth: '300px', flex: 1 }}
              />

              <Dialog open={isDialogOpen} onOpenChange={(e, data) => setIsDialogOpen(data.open)}>
                <DialogTrigger disableButtonEnhancement>
                  <Button
                    appearance="primary"
                    icon={<AddRegular />}
                  >
                    Add User
                  </Button>
                </DialogTrigger>
                <DialogSurface>
                  <DialogBody>
                    <DialogTitle>Add New User</DialogTitle>
                    <DialogContent>
                      <div style={{ display: 'flex', flexDirection: 'column', gap: '16px' }}>
                        <Field label="Name" required>
                          <Input
                            value={newUserName}
                            onChange={(e) => setNewUserName(e.target.value)}
                            placeholder="Enter full name"
                          />
                        </Field>

                        <Field label="Username" required>
                          <Input
                            value={newUserUsername}
                            onChange={(e) => setNewUserUsername(e.target.value)}
                            placeholder="Enter username"
                          />
                        </Field>

                        <Field label="Email" required>
                          <Input
                            type="email"
                            value={newUserEmail}
                            onChange={(e) => setNewUserEmail(e.target.value)}
                            placeholder="Enter email address"
                          />
                        </Field>

                        <Field label="Phone">
                          <Input
                            value={newUserPhone}
                            onChange={(e) => setNewUserPhone(e.target.value)}
                            placeholder="Enter phone number (optional)"
                          />
                        </Field>

                        <Field label="Website">
                          <Input
                            value={newUserWebsite}
                            onChange={(e) => setNewUserWebsite(e.target.value)}
                            placeholder="Enter website (optional)"
                          />
                        </Field>
                      </div>
                    </DialogContent>
                    <DialogActions>
                      <Button appearance="secondary" onClick={handleCancelAddUser}>
                        Cancel
                      </Button>
                      <Button
                        appearance="primary"
                        onClick={handleAddUser}
                        disabled={!isFormValid}
                      >
                        Add User
                      </Button>
                    </DialogActions>
                  </DialogBody>
                </DialogSurface>
              </Dialog>
            </div>
          </div>
        </Card>

        {/* Table Section */}
        <Card className={styles.card}>
          <div className={styles.section}>
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '16px' }}>
              <Title3>Users Table ({sortedUsers.length} users)</Title3>
              <Button
                appearance="primary"
                icon={<DeleteRegular />}
                onClick={handleDeleteSelected}
                disabled={selectedUsers.size === 0}
              >
                Delete Selected ({selectedUsers.size})
              </Button>
            </div>

            {loading ? (
              <div className={styles.loadingContainer}>
                <Spinner label="Loading users..." />
              </div>
            ) : (
              <div className={styles.table}>
                <Table size="small">
                  <TableHeader>
                    <TableRow>
                      <TableHeaderCell className={styles.tableHeaderCell}>
                        <Checkbox
                          checked={allSelected}
                          indeterminate={someSelected}
                          onChange={(e, data) => handleSelectAll(data.checked)}
                        />
                      </TableHeaderCell>
                      <TableHeaderCell
                        className={styles.tableHeaderCell}
                        onClick={() => handleSort('name')}
                        style={{ cursor: 'pointer', userSelect: 'none' }}
                      >
                        <TableCellLayout media={<PersonRegular />}>
                          Name{getSortIcon('name')}
                        </TableCellLayout>
                      </TableHeaderCell>
                      <TableHeaderCell
                        className={styles.tableHeaderCell}
                        onClick={() => handleSort('username')}
                        style={{ cursor: 'pointer', userSelect: 'none' }}
                      >
                        Username{getSortIcon('username')}
                      </TableHeaderCell>
                      <TableHeaderCell
                        className={styles.tableHeaderCell}
                        onClick={() => handleSort('email')}
                        style={{ cursor: 'pointer', userSelect: 'none' }}
                      >
                        <TableCellLayout media={<MailRegular />}>
                          Email{getSortIcon('email')}
                        </TableCellLayout>
                      </TableHeaderCell>
                      <TableHeaderCell
                        className={styles.tableHeaderCell}
                        onClick={() => handleSort('phone')}
                        style={{ cursor: 'pointer', userSelect: 'none' }}
                      >
                        <TableCellLayout media={<PhoneRegular />}>
                          Phone{getSortIcon('phone')}
                        </TableCellLayout>
                      </TableHeaderCell>
                      <TableHeaderCell
                        className={styles.tableHeaderCell}
                        onClick={() => handleSort('website')}
                        style={{ cursor: 'pointer', userSelect: 'none' }}
                      >
                        <TableCellLayout media={<GlobeRegular />}>
                          Website{getSortIcon('website')}
                        </TableCellLayout>
                      </TableHeaderCell>
                      <TableHeaderCell className={styles.tableHeaderCell}>
                        Actions
                      </TableHeaderCell>
                    </TableRow>
                  </TableHeader>
                  <TableBody>
                    {sortedUsers.map((user) => (
                      <TableRow key={user.id} className={styles.tableRow}>
                        <TableCell className={styles.tableCell}>
                          <Checkbox
                            checked={selectedUsers.has(user.id)}
                            onChange={(e, data) => handleCheckboxChange(user.id, data.checked)}
                          />
                        </TableCell>
                        <TableCell className={styles.tableCell}>
                          <TableCellLayout
                            media={
                              <Avatar
                                name={user.name}
                                color="colorful"
                                initials={getInitials(user.name)}
                              />
                            }
                          >
                            <span className={styles.nameCell}>{user.name}</span>
                          </TableCellLayout>
                        </TableCell>
                        <TableCell className={styles.tableCell}>
                          <Badge appearance="outline" color="informative">
                            @{user.username}
                          </Badge>
                        </TableCell>
                        <TableCell className={styles.tableCell}>
                          <span className={styles.emailCell}>{user.email}</span>
                        </TableCell>
                        <TableCell className={styles.tableCell}>{user.phone}</TableCell>
                        <TableCell className={styles.tableCell}>{user.website}</TableCell>
                        <TableCell className={styles.tableCell}>
                          <Button
                            appearance="subtle"
                            icon={<EditRegular />}
                            onClick={() => handleEditUser(user)}
                            size="small"
                          >
                            Edit
                          </Button>
                        </TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
                {filteredUsers.length === 0 && (
                  <div style={{ textAlign: 'center', padding: '24px' }}>
                    <Body1>No users found matching "{searchTerm}"</Body1>
                  </div>
                )}
              </div>
            )}
          </div>
        </Card>

        {/* Edit User Dialog */}
        <Dialog open={isEditDialogOpen} onOpenChange={(e, data) => setIsEditDialogOpen(data.open)}>
          <DialogSurface>
            <DialogBody>
              <DialogTitle>Edit User</DialogTitle>
              <DialogContent>
                <div style={{ display: 'flex', flexDirection: 'column', gap: '16px' }}>
                  <Field label="Name" required>
                    <Input
                      value={editUserName}
                      onChange={(e) => setEditUserName(e.target.value)}
                      placeholder="Enter full name"
                    />
                  </Field>

                  <Field label="Username" required>
                    <Input
                      value={editUserUsername}
                      onChange={(e) => setEditUserUsername(e.target.value)}
                      placeholder="Enter username"
                    />
                  </Field>

                  <Field label="Email" required>
                    <Input
                      type="email"
                      value={editUserEmail}
                      onChange={(e) => setEditUserEmail(e.target.value)}
                      placeholder="Enter email address"
                    />
                  </Field>

                  <Field label="Phone">
                    <Input
                      value={editUserPhone}
                      onChange={(e) => setEditUserPhone(e.target.value)}
                      placeholder="Enter phone number (optional)"
                    />
                  </Field>

                  <Field label="Website">
                    <Input
                      value={editUserWebsite}
                      onChange={(e) => setEditUserWebsite(e.target.value)}
                      placeholder="Enter website (optional)"
                    />
                  </Field>
                </div>
              </DialogContent>
              <DialogActions>
                <Button appearance="secondary" onClick={handleCancelEditUser}>
                  Cancel
                </Button>
                <Button
                  appearance="primary"
                  onClick={handleSaveEditUser}
                  disabled={!isEditFormValid}
                >
                  Save Changes
                </Button>
              </DialogActions>
            </DialogBody>
          </DialogSurface>
        </Dialog>
      </div>
    </FluentProvider>
  );
}

export default FluentUIDemo;
