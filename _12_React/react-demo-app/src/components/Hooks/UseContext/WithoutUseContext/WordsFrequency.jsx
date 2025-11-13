// WordsFrequency - Analyzes and displays word frequency (receives props from Container)
function WordsFrequency({ phrase, updatePhrase }) {
  // Calculate word frequency
  const words = phrase.toLowerCase().split(/\s+/).filter(w => w.length > 0);
  const wordFrequency = {};
  words.forEach(word => {
    wordFrequency[word] = (wordFrequency[word] || 0) + 1;
  });

  const totalWords = Object.values(wordFrequency).reduce((sum, count) => sum + count, 0);
  const uniqueWords = Object.keys(wordFrequency).length;

  return (
    <div className="frequency-card words-frequency">
      <h3>Words Frequency</h3>

      <textarea
        value={phrase}
        onChange={(e) => updatePhrase(e.target.value)}
        placeholder="Edit phrase..."
        rows="4"
      />

      <p><strong>Total:</strong> {totalWords} | <strong>Unique:</strong> {uniqueWords}</p>

      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>Word</th>
              <th className="align-right">Count</th>
            </tr>
          </thead>
          <tbody>
            {totalWords === 0 ? (
              <tr>
                <td colSpan="2" className="empty-state">
                  No words
                </td>
              </tr>
            ) : (
              Object.entries(wordFrequency)
                .sort(([, a], [, b]) => b - a)
                .map(([word, count]) => (
                  <tr key={word}>
                    <td>{word}</td>
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

export default WordsFrequency;
