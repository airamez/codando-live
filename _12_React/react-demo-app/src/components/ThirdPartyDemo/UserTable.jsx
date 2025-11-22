import {
  Button,
  Checkbox,
  Table,
  TableBody,
  TableCell,
  TableRow,
  TableHeader,
  TableHeaderCell,
  Spinner,
  Body1,
  TableCellLayout,
  Avatar,
  Badge,
} from '@fluentui/react-components';
import {
  DeleteRegular,
  PersonRegular,
  MailRegular,
  PhoneRegular,
  GlobeRegular,
  EditRegular,
  ArrowUpRegular,
  ArrowDownRegular,
} from '@fluentui/react-icons';
import { useStyles } from './styles';

function UserTable({
  users,
  loading,
  selectedUsers,
  onCheckboxChange,
  onSelectAll,
  onDeleteSelected,
  onEditUser,
  sortColumn,
  sortDirection,
  onSort,
}) {
  const styles = useStyles();

  const allSelected = users.length > 0 && users.every(user => selectedUsers.has(user.id));
  const someSelected = users.some(user => selectedUsers.has(user.id)) && !allSelected;

  const getSortIcon = (column) => {
    if (sortColumn !== column) return null;
    return sortDirection === 'ascending' ? <ArrowUpRegular /> : <ArrowDownRegular />;
  };

  const getInitials = (name) => {
    return name
      .split(' ')
      .map(word => word[0])
      .join('')
      .toUpperCase()
      .substring(0, 2);
  };

  if (loading) {
    return (
      <div className={styles.loadingContainer}>
        <Spinner label="Loading users..." />
      </div>
    );
  }

  return (
    <>
      <div className={styles.tableHeaderContainer}>
        <h3>Users Table ({users.length} users)</h3>
        <Button
          appearance="primary"
          icon={<DeleteRegular />}
          onClick={onDeleteSelected}
          disabled={selectedUsers.size === 0}
        >
          Delete Selected ({selectedUsers.size})
        </Button>
      </div>

      <div className={`${styles.table} ${styles.tableWrapper}`}>
        <Table size="small">
          <colgroup>
            <col className={styles.colCheckbox} />
            <col className={styles.colName} />
            <col className={styles.colUsername} />
            <col className={styles.colEmail} />
            <col className={styles.colPhone} />
            <col className={styles.colWebsite} />
            <col className={styles.colActions} />
          </colgroup>
          <TableHeader>
            <TableRow>
              <TableHeaderCell className={styles.tableHeaderCell}>
                <Checkbox
                  checked={allSelected}
                  indeterminate={someSelected}
                  onChange={(e, data) => onSelectAll(data.checked)}
                />
              </TableHeaderCell>
              <TableHeaderCell
                className={`${styles.tableHeaderCell} ${styles.sortableHeader}`}
                onClick={() => onSort('name')}
              >
                <TableCellLayout media={<PersonRegular />}>
                  Name {getSortIcon('name')}
                </TableCellLayout>
              </TableHeaderCell>
              <TableHeaderCell
                className={`${styles.tableHeaderCell} ${styles.sortableHeader}`}
                onClick={() => onSort('username')}
              >
                Username {getSortIcon('username')}
              </TableHeaderCell>
              <TableHeaderCell
                className={`${styles.tableHeaderCell} ${styles.sortableHeader}`}
                onClick={() => onSort('email')}
              >
                <TableCellLayout media={<MailRegular />}>
                  Email {getSortIcon('email')}
                </TableCellLayout>
              </TableHeaderCell>
              <TableHeaderCell
                className={`${styles.tableHeaderCell} ${styles.sortableHeader}`}
                onClick={() => onSort('phone')}
              >
                <TableCellLayout media={<PhoneRegular />}>
                  Phone {getSortIcon('phone')}
                </TableCellLayout>
              </TableHeaderCell>
              <TableHeaderCell
                className={`${styles.tableHeaderCell} ${styles.sortableHeader}`}
                onClick={() => onSort('website')}
              >
                <TableCellLayout media={<GlobeRegular />}>
                  Website {getSortIcon('website')}
                </TableCellLayout>
              </TableHeaderCell>
              <TableHeaderCell className={styles.tableHeaderCell}>
                Actions
              </TableHeaderCell>
            </TableRow>
          </TableHeader>
          <TableBody>
            {users.map((user) => (
              <TableRow key={user.id} className={styles.tableRow}>
                <TableCell className={styles.tableCell}>
                  <Checkbox
                    checked={selectedUsers.has(user.id)}
                    onChange={(e, data) => onCheckboxChange(user.id, data.checked)}
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
                    onClick={() => onEditUser(user)}
                    size="small"
                  >
                    Edit
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
        {users.length === 0 && (
          <div className={styles.emptyState}>
            <Body1>No users found</Body1>
          </div>
        )}
      </div>
    </>
  );
}

export default UserTable;
