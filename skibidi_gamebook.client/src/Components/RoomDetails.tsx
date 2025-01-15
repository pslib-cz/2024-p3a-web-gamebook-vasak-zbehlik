import React from 'react';
import { Room } from '../types';

interface RoomDetailsProps {
  room: Room | null;
}

const RoomDetails: React.FC<RoomDetailsProps> = ({ room }) => {
  if (!room) return null;

  return (
    <div
      className="RoomDetails"
      style={{
        backgroundImage: `url(https://localhost:7160/Images/bg/${room.img})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        height: '100vh',
        color: 'white',
        padding: '20px'
      }}
    >
      <h1>{room.name}</h1>
      <p>{room.description}</p>
    </div>
  );
};

export default RoomDetails;