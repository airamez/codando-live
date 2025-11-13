import { useState } from 'react';
import '../useContext.css';
import Phrase from './Phrase';
import Container from './Container';

// MainPage - Owns state and must pass props through all levels
function MainPage() {
  const [phrase, setPhrase] = useState('Hello World from React Context world');

  const updatePhrase = (newPhrase) => {
    setPhrase(newPhrase);
  };

  return (
    <div className="example-container">
      <Phrase phrase={phrase} updatePhrase={updatePhrase} />
      <Container phrase={phrase} updatePhrase={updatePhrase} />
    </div>
  );
}

export default MainPage;

