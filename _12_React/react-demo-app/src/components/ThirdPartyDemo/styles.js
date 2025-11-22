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
});
