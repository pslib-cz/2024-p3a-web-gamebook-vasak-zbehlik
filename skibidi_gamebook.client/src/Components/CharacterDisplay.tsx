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
}

const CharacterDisplay: React.FC<CharacterDisplayProps> = ({ roomId }) => {
  const [character, setCharacter] = useState<Character | null>(null);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    (async () => {
      try {
        const response = await fetch(`/api/Characters/where/${roomId}`);
        const jsonData = await response.json();
        setCharacter(jsonData);
      } catch (error) {
        setError('Error fetching character');
      }
    })();
  }, [roomId]);

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {character && (
        <div>
          <h2>{character.name}</h2>
          <img src={`https://localhost:7160/Images/char/${character.img}`} alt={character.name} />
          <p>{character.text}</p>
        </div>
      )}
    </div>
  );
};

export default CharacterDisplay;