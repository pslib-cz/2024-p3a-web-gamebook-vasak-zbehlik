import React from 'react';

interface Character {
  name: string;
  img: string;
  text: string;
}

interface CharacterDetailsProps {
  character: Character;
}

const CharacterDetails: React.FC<CharacterDetailsProps> = ({ character }) => {
  return (
    <div>
      <h2>{character.name}</h2>
      <img src={`https://localhost:7160/Images/char/${character.img}`} alt={character.name} />
      <p>{character.text}</p>
    </div>
  );
};

export default CharacterDetails;