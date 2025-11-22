import { useState, useEffect } from 'react';
import {
  Button,
  Dialog,
  DialogSurface,
  DialogTitle,
  DialogBody,
  DialogActions,
  DialogContent,
  Field,
  Input,
} from '@fluentui/react-components';
import { useStyles } from './styles';

function EditUserDialog({ isOpen, user, onSave, onCancel }) {
  const styles = useStyles();
  const [editUserName, setEditUserName] = useState('');
  const [editUserUsername, setEditUserUsername] = useState('');
  const [editUserEmail, setEditUserEmail] = useState('');
  const [editUserPhone, setEditUserPhone] = useState('');
  const [editUserWebsite, setEditUserWebsite] = useState('');

  useEffect(() => {
    if (user) {
      setEditUserName(user.name);
      setEditUserUsername(user.username);
      setEditUserEmail(user.email);
      setEditUserPhone(user.phone);
      setEditUserWebsite(user.website);
    }
  }, [user]);

  const isFormValid = editUserName.trim() && editUserUsername.trim() && editUserEmail.trim();

  const handleSave = () => {
    if (isFormValid) {
      const updatedUser = {
        ...user,
        name: editUserName.trim(),
        username: editUserUsername.trim(),
        email: editUserEmail.trim(),
        phone: editUserPhone.trim() || 'N/A',
        website: editUserWebsite.trim() || 'N/A',
      };
      onSave(updatedUser);
    }
  };

  return (
    <Dialog open={isOpen} onOpenChange={(e, data) => !data.open && onCancel()}>
      <DialogSurface>
        <DialogBody>
          <DialogTitle>Edit User</DialogTitle>
          <DialogContent>
            <div className={styles.dialogFormContainer}>
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
            <Button appearance="secondary" onClick={onCancel}>
              Cancel
            </Button>
            <Button appearance="primary" onClick={handleSave} disabled={!isFormValid}>
              Save Changes
            </Button>
          </DialogActions>
        </DialogBody>
      </DialogSurface>
    </Dialog>
  );
}

export default EditUserDialog;
