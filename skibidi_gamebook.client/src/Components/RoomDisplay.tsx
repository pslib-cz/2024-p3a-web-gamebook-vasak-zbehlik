// RoomDisplay.tsx
import React from 'react';

interface Room {
  RId: number;
  Name: string;
  Description: string;
  Img?: string;
}

interface RoomDisplayProps {
  room: Room | null;
  loading: boolean;
  error: string | null;
}

const RoomDisplay: React.FC<RoomDisplayProps> = ({ room, loading, error }) => {
  return (
    <div>
      {loading && <p>Loading...</p>}
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {room && (
        <div
          style={{
            backgroundImage: `url(https://localhost:7160/Images/${room.Img})`,
            backgroundSize: 'cover',
            backgroundPosition: 'center',
            height: '100vh',
            color: 'white',
            padding: '20px'
          }}
        >
          <h2>{room.Name}</h2>
          <p>{room.Description}</p>
        </div>
      )}
    </div>
  );
};

export default RoomDisplay;