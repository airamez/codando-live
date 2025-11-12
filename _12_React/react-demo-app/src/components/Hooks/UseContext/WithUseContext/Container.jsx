import WordsFrequency from './WordsFrequency';
import CharactersFrequency from './CharactersFrequency';

// Container - Holds two analysis components
function Container() {
  return (
    <div className="container-layout">
      <h3>Analysis Container</h3>
      <div className="frequency-container">
        <WordsFrequency />
        <CharactersFrequency />
      </div>
    </div>
  );
}

export default Container;
