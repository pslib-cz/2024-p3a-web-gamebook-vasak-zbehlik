import React from 'react';

interface ConnectionChangerProps {
  onChangeRoom: (newRoomId: number) => void;
  targetRoomId: number;
  name: string;
}

const ConnectionChanger: React.FC<ConnectionChangerProps> = ({ onChangeRoom, targetRoomId, name }) => {
  const handleChangeRoom = () => {
    onChangeRoom(targetRoomId);
  };

  return (
    <button onClick={handleChangeRoom}>
      {name}
    </button>
  );
};

export default ConnectionChanger;