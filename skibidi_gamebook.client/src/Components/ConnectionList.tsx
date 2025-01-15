import React from 'react';
import ConnectionChanger from './ConnectionChanger';
import { Connection } from '../types';

interface ConnectionListProps {
  connections: Connection[];
  onChangeRoom: (newRoomId: number) => void;
}

const ConnectionList: React.FC<ConnectionListProps> = ({ connections, onChangeRoom }) => {
  return (
    <div>
      {connections.map((connection) => (
        <ConnectionChanger
          key={connection.cId}
          onChangeRoom={onChangeRoom}
          targetRoomId={connection.roomId}
          name={connection.name}
        />
      ))}
    </div>
  );
};

export default ConnectionList;