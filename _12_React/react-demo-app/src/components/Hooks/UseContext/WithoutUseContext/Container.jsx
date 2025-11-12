import WordsFrequency from './WordsFrequency';
import CharactersFrequency from './CharactersFrequency';

// Container - Doesn't use phrase/updatePhrase but must pass them down
function Container({ phrase, updatePhrase }) {
  return (
    <div className="container-layout">
      <h3>Analysis Container</h3>
      <div className="frequency-container">
        <WordsFrequency phrase={phrase} updatePhrase={updatePhrase} />
        <CharactersFrequency phrase={phrase} updatePhrase={updatePhrase} />
      </div>
    </div>
  );
}

export default Container;
