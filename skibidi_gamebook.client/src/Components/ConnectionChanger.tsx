import React, { useEffect, useState } from 'react';

interface Connection {
  connectionId: number;
  name: string;
  lock: number;
  requieremenId: number;
  fromId: number;
  toId: number;
}

interface ConnectionChangerProps {
  roomId: number;
  onChangeRoom: (roomId: number) => void;
}

const ConnectionChanger: React.FC<ConnectionChangerProps> = (props) => {
  const [connections, setConnections] = useState<Connection[]>([]);
  const [error, setError] = useState<string | null>(null);

  const handleChangeRoom = (targetRoomId: number) => {
    props.onChangeRoom(targetRoomId);
  };

  useEffect(() => {
    (async () => {
      try {
        const response = await fetch(`https://localhost:7160/api/Connections/from/${props.roomId}`);
        const jsonData = await response.json();
        setConnections(jsonData);
      } catch (error) {
        setError('Error fetching connections');
        console.error('Error fetching connections:', error);
      }
    })();
  }, [props.roomId]);

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {connections.map((connection) => (
        <button key={connection.connectionId} onClick={() => handleChangeRoom(connection.toId)}>
          {connection.name}
        </button>
      ))}
    </div>
  );
};

export default ConnectionChanger;