// ConnectionChanger.tsx
import React, { useState } from 'react';

interface Connection {
  CId: number;
  fromId: number;
  RoomId: number;
  Name: string;
  Lock: number;
  ItemId?: number;
  AchievementId?: number;
}

interface Room {
  RId: number;
  Name: string;
  Description: string;
  Img?: string;
}

interface ConnectionChangerProps {
  targetRoomId: number;
  onChangeRoom: (roomId: number) => void;
  name: string;
}

const ConnectionChanger: React.FC<ConnectionChangerProps> = (props) => {
  const [error, setError] = useState<string | null>(null);

  const handleChangeRoom = () => {
    props.onChangeRoom(props.targetRoomId);
  };

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <button onClick={handleChangeRoom}>{(props.name)}</button>
    </div>
  );
};

export default ConnectionChanger;