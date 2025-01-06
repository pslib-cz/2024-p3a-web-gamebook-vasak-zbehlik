// App.tsx
import React, { useState, useEffect } from 'react';
import './App.css';
import ConnectionChanger from './Components/ConnectionChanger';
//import RoomDisplay from './Components/RoomDisplay';

interface Room {
  rId: number;
  name: string;
  description: string;
  img?: string;
}

interface Connection {
  cId: number;
  fromId: number;
  roomId: number;
  name: string;
  lock: number;
  itemId?: number;
  achievementId?: number;
}

const App: React.FC = () => {
  const [room, setRoom] = useState<Room | null>(null);
  const [connections, setConnections] = useState<Connection[]>([]);
  const [roomId, setRoomId] = useState<number>(1);

  useEffect(() => {
    (async () => {
        try {
            const response = await fetch(`https://localhost:7160/api/Rooms/${roomId}`);
            const jsonData = await response.json();
            console.log(jsonData);
            setRoom(jsonData);
           const response2 = await fetch(`https://localhost:7160/api/Connections/From/${roomId}`);
            const jsonData2 = await response2.json();
            console.log(jsonData2);
            setConnections(jsonData2);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    })();
  }, [roomId]);


  return (
    <div className="App">
      <h1>Room List</h1>
      <img src={`https://localhost:7160/Images/${room ? room.img : "x"}`} alt="" />
      {connections.map((connection) => (
        <ConnectionChanger
          key={connection.cId}
          onChangeRoom={(newRoomId: number) => setRoomId(newRoomId)}
          targetRoomId={connection.roomId}
        />
      ))}</div>
  );
};

export default App;