import { useContext } from 'react';
import { PhraseContext } from './MainPage';

// CharactersFrequency - Analyzes and displays character frequency
function CharactersFrequency() {
  const { phrase, updatePhrase } = useContext(PhraseContext);

  // Calculate character frequency (excluding spaces)
  const chars = phrase.toLowerCase().replace(/\s/g, '').split('');
  const charFrequency = {};
  chars.forEach(char => {
    if (char.match(/[a-z]/)) {  // Only letters
      charFrequency[char] = (charFrequency[char] || 0) + 1;
    }
  });

  const totalChars = Object.values(charFrequency).reduce((sum, count) => sum + count, 0);
  const uniqueChars = Object.keys(charFrequency).length;

  return (
    <div className="frequency-card characters-frequency">
      <h3>Characters Frequency</h3>

      <textarea
        value={phrase}
        onChange={(e) => updatePhrase(e.target.value)}
        placeholder="Edit phrase..."
        rows="4"
      />

      <p><strong>Total:</strong> {totalChars} | <strong>Unique:</strong> {uniqueChars}</p>

      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>Letter</th>
              <th className="align-right">Count</th>
            </tr>
          </thead>
          <tbody>
            {totalChars === 0 ? (
              <tr>
                <td colSpan="2" className="empty-state">
                  No letters
                </td>
              </tr>
            ) : (
              Object.entries(charFrequency)
                .sort(([, a], [, b]) => b - a)
                .map(([char, count]) => (
                  <tr key={char}>
                    <td>{char.toUpperCase()}</td>
                    <td className="align-right">{count}</td>
                  </tr>
                ))
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default CharactersFrequency;
