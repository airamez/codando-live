import { useState } from 'react';
import {
  Button,
  Dialog,
  DialogTrigger,
  DialogSurface,
  DialogTitle,
  DialogBody,
  DialogActions,
  DialogContent,
  Field,
  Input,
} from '@fluentui/react-components';
import { AddRegular } from '@fluentui/react-icons';
import { useStyles } from './styles';

function AddUserDialog({ onAddUser }) {
  const styles = useStyles();
  const [isDialogOpen, setIsDialogOpen] = useState(false);
  const [newUserName, setNewUserName] = useState('');
  const [newUserUsername, setNewUserUsername] = useState('');
  const [newUserEmail, setNewUserEmail] = useState('');
  const [newUserPhone, setNewUserPhone] = useState('');
  const [newUserWebsite, setNewUserWebsite] = useState('');

  const isFormValid = newUserName.trim() && newUserUsername.trim() && newUserEmail.trim();

  const handleAddUser = () => {
    if (isFormValid) {
      const newUser = {
        name: newUserName.trim(),
        username: newUserUsername.trim(),
        email: newUserEmail.trim(),
        phone: newUserPhone.trim() || 'N/A',
        website: newUserWebsite.trim() || 'N/A',
      };
      onAddUser(newUser);
      handleCancel();
    }
  };

  const handleCancel = () => {
    setNewUserName('');
    setNewUserUsername('');
    setNewUserEmail('');
    setNewUserPhone('');
    setNewUserWebsite('');
    setIsDialogOpen(false);
  };

  return (
    <Dialog open={isDialogOpen} onOpenChange={(e, data) => setIsDialogOpen(data.open)}>
      <DialogTrigger disableButtonEnhancement>
        <Button appearance="primary" icon={<AddRegular />}>
          Add User
        </Button>
      </DialogTrigger>
      <DialogSurface>
        <DialogBody>
          <DialogTitle>Add New User</DialogTitle>
          <DialogContent>
            <div className={styles.dialogFormContainer}>
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
            <Button appearance="secondary" onClick={handleCancel}>
              Cancel
            </Button>
            <Button appearance="primary" onClick={handleAddUser} disabled={!isFormValid}>
              Add User
            </Button>
          </DialogActions>
        </DialogBody>
      </DialogSurface>
    </Dialog>
  );
}

export default AddUserDialog;
