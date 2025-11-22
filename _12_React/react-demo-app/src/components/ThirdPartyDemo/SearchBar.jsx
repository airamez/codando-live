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
        className={styles.searchInput}
      />
    </div>
  );
}

export default SearchBar;
