// App.tsx
import React, { useState, useEffect } from 'react';
import './App.css';
import ConnectionChanger from './Components/ConnectionChanger';
import {
  useNavigate
} from "react-router-dom";
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
  const navigate = useNavigate();

  useEffect(() => {
    (async () => {
        try {
            const response = await fetch(`https://localhost:7160/api/Rooms/${roomId}`);
            const jsonData = await response.json();
            setRoom(jsonData);
           const response2 = await fetch(`https://localhost:7160/api/Connections/From/${roomId}`);
            const jsonData2 = await response2.json();
            setConnections(jsonData2);
          navigate(`/Rooms/${jsonData.rId}`);
          console.log(jsonData);
          console.log(jsonData2);
          console.log('Background Image URL:', `https://localhost:7160/Images/${room?.img}`);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    })();

  }, [roomId, navigate]);


  return (
    
    <div>
      {room && (
        <div
          className="App"
          style={{
            backgroundImage: `url(https://localhost:7160/Images/${room.img})`,
            backgroundSize: 'cover',
            backgroundPosition: 'center',
            height: '100vh',
            color: 'white',
            backgroundColor: 'lightblue',
            padding: '20px'
          }}
        >
          {connections.map((connection) => (
            <ConnectionChanger
              key={connection.cId}
              onChangeRoom={(newRoomId: number) => setRoomId(newRoomId)}
              targetRoomId={connection.roomId}
            />
          ))}
        </div>
      )}
    </div>
  );
};

export default App;