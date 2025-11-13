import { createContext, useState } from 'react';
import '../useContext.css';
import Phrase from './Phrase';
import Container from './Container';

// Create Context at module level
export const PhraseContext = createContext();

// MainPage - Provider component that owns the state
function MainPage() {
  const [phrase, setPhrase] = useState('Hello World from React Context');

  const updatePhrase = (newPhrase) => {
    setPhrase(newPhrase);
  };

  const value = {
    phrase,
    updatePhrase
  };

  return (
    <PhraseContext.Provider value={value}>
      <div className="example-container">
        <Phrase />
        <Container />
      </div>
    </PhraseContext.Provider>
  );
}

export default MainPage;
