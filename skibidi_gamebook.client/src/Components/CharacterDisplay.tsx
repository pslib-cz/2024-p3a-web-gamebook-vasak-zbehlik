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
    const fetchCharacter = async () => {
      try {
        const response = await fetch(`/api/Characters/where/${roomId}`);
        if (!response.ok) {
          throw new Error(`Failed to fetch character: ${response.statusText}`);
        }
        const jsonData = await response.json();

   /*     if (jsonData && jsonData.characterId && jsonData.name && jsonData.img) {
          setCharacter(jsonData);
          updateCurrency(jsonData.characterId);
        } else {
          throw new Error('Invalid character data received');
        }*/
      } catch (err: any) {
        console.error(err.message);
        setError('Error fetching character');
      }
    };

    fetchCharacter();
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