// Phrase - Displays and allows real-time editing of the phrase (receives props from MainPage)
function Phrase({ phrase, updatePhrase }) {
  return (
    <div className="phrase-card">
      <h3>Current Phrase</h3>
      <textarea
        value={phrase}
        onChange={(e) => updatePhrase(e.target.value)}
        placeholder="Enter your phrase here..."
        rows="4"
      />
    </div>
  );
}

export default Phrase;
