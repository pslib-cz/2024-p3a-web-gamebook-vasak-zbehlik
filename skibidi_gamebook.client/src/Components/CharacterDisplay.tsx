import React, { useEffect, useState } from 'react';

interface Character {
  charName: string;
  charImg: string;
  chartext: string;
}

interface CharacterDisplayProps {
  roomId: number;
}

const CharacterDisplay: React.FC<CharacterDisplayProps> = ({ roomId }) => {
  const [character, setCharacter] = useState<Character | null>(null);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    (async () => {
      try {
        const response = await fetch(`https://localhost:7160/api/Characters/room/${roomId}`);
        const jsonData = await response.json();
        setCharacter(jsonData);
      } catch (error) {
        setError('Error fetching character');
        console.error('Error fetching character:', error);
      }
    })();
  }, [roomId]);

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {character && (
        <div>
          <h2>{character.charName}</h2>
          <img src={`https://localhost:7160/Images/char/${character.charImg}`} alt={character.charName} />
          <p>{character.chartext}</p>
        </div>
      )}
    </div>
  );
};

export default CharacterDisplay;