import { Input } from '@fluentui/react-components';
import { SearchRegular } from '@fluentui/react-icons';
import { useStyles } from './styles';

function SearchBar({ searchTerm, onSearchChange }) {
  const styles = useStyles();

  return (
    <div className={styles.inputGroup}>
      <Input
        placeholder="Search users..."
        contentBefore={<SearchRegular />}
        value={searchTerm}
        onChange={(e) => onSearchChange(e.target.value)}
        style={{ minWidth: '300px', flex: 1 }}
      />
    </div>
  );
}

export default SearchBar;
