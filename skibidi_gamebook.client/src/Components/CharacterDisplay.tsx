import React, { useEffect, useState } from 'react';

interface Character {
  characterId: number;
  name: string;
  text: string;
  img: string;
  whereId: number;
}

interface CharacterDisplayProps {
  roomId: number;
  updateCurrency: (characterId: number) => void;
}

const CharacterDisplay: React.FC<CharacterDisplayProps> = ({ roomId, updateCurrency }) => {
  const [character, setCharacter] = useState<Character | null>(null);
  const [error, setError] = useState<string | null>(null);
  const [isLocked, setIsLocked] = useState<boolean>(false);

  useEffect(() => {
    (async () => {
      try {
        const response = await fetch(`/api/Characters/where/${roomId}`);
        const jsonData = await response.json();
        setCharacter(jsonData);
        updateCurrency(jsonData.characterId);
      } catch {
        setError('Error fetching character');
      }
    })();
  }, [roomId, updateCurrency]);

const handleCharacterClick = () => {
  if (!isLocked && character) {
    updateCurrency(character.characterId);
    setIsLocked(true);
  }
};
    

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {character && (
        <div onClick={handleCharacterClick} style={{ cursor: isLocked ? 'not-allowed' : 'pointer' }}>
          <h2>{character.name}</h2>
          <img src={`/Images/char/${character.img}`} alt={character.name}             style={{ opacity: isLocked ? 0.5 : 1 }} // Dim the character if locked
          />
          <p>{character.text}</p>
        </div>
      )}
    </div>
  );
};

export default CharacterDisplay;