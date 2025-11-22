import { makeStyles, tokens } from '@fluentui/react-components';

export const useStyles = makeStyles({
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
    overflow: 'auto',
    width: '100%',
    '& table': {
      tableLayout: 'fixed',
      width: '100%',
    },
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
  checkboxCell: {
    width: '50px !important',
    maxWidth: '50px !important',
    minWidth: '50px !important',
    padding: '8px !important',
  },
  searchInput: {
    minWidth: '300px',
    flex: 1,
  },
  dialogFormContainer: {
    display: 'flex',
    flexDirection: 'column',
    gap: '16px',
  },
  tableHeaderContainer: {
    display: 'flex',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: '16px',
  },
  tableWrapper: {
    overflowX: 'auto',
  },
  sortableHeader: {
    cursor: 'pointer',
  },
  colCheckbox: {
    width: '50px',
  },
  colName: {
    width: '200px',
  },
  colUsername: {
    width: '150px',
  },
  colEmail: {
    width: '250px',
  },
  colPhone: {
    width: '160px',
  },
  colWebsite: {
    width: '170px',
  },
  colActions: {
    width: '100px',
  },
  emptyState: {
    textAlign: 'center',
    padding: '24px',
  },
});
