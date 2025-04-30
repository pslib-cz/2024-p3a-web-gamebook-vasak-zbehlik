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
  const [isLoading, setIsLoading] = useState<boolean>(true);

  useEffect(() => {
    console.log("CharacterDisplay mounting with roomId:", roomId);
    
    // Make sure we have a valid roomId
    if (!roomId) {
      console.log("Invalid roomId, not fetching character");
      setIsLoading(false);
      return;
    }
    
    setIsLocked(false); // Reset isLocked when roomId changes
    setIsLoading(true); // Set loading state

    const fetchCharacter = async () => {
      try {
        console.log(`Fetching character for roomId: ${roomId}`);
        const response = await fetch(`/api/Characters/where/${roomId}`);
        
        if (!response.ok) {
          throw new Error(`Failed to fetch character: ${response.statusText}`);
        }
        
        const jsonData = await response.json();
        console.log("Character data received:", jsonData);
        
        setCharacter(jsonData);
        setError(null);
      } catch (err: any) {
        console.error("Error in CharacterDisplay:", err.message);
        setError('Error fetching character');
        setCharacter(null);
      } finally {
        setIsLoading(false);
      }
    };

    fetchCharacter();
    
    // Cleanup function
    return () => {
      console.log("CharacterDisplay component unmounting");
    };
  }, [roomId]);

  const handleCharacterClick = () => {
    if (!isLocked && character) {
      updateCurrency(character.characterId);
      setIsLocked(true);
    }
  };

  // If we're still in the initial loading state, show a loading indicator
  if (isLoading) {
    return <div>Loading character information...</div>;
  }

  return (
    <div className="character-display">
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {character ? (
        <div 
          onClick={handleCharacterClick} 
          style={{ 
            cursor: isLocked ? 'not-allowed' : 'pointer',
            padding: '10px',
            border: '1px solid #ccc',
            borderRadius: '5px',
            marginTop: '10px'
          }}
        >
          <h2>{character.name}</h2>
          <img 
            src={`/Images/char/${character.img}`} 
            alt={character.name}
            style={{ 
              opacity: isLocked ? 0.5 : 1,
              maxWidth: '100%',
              height: 'auto'
            }} 
          />
          <p>{character.text}</p>
        </div>
      ) : (
        !error && <p>No character in this room</p>
      )}
    </div>
  );
};

export default CharacterDisplay;