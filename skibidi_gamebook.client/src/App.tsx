import React, { useState, useEffect } from 'react';
import './App.css';
import ConnectionChanger from './Components/ConnectionChanger';
import ItemDisplay from './Components/ItemDisplay';
import CharacterDisplay from './Components/CharacterDisplay';
import { useNavigate } from "react-router-dom";
import InventoryMenu from './Components/InventoryDisplay';

interface Room {
  rId: number;
  name: string;
  description: string;
  img?: string;
}

const App: React.FC = () => {
  const [room, setRoom] = useState<Room | null>(null);
  const [roomId, setRoomId] = useState<number>(1);
  const navigate = useNavigate();

  useEffect(() => {
    (async () => {
      try {
        const response = await fetch(`https://localhost:7160/api/Rooms/${roomId}`);
        const jsonData = await response.json();
        setRoom(jsonData);
        navigate(`/Rooms/${jsonData.rId}`);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    })();
  }, [roomId, navigate]);

  return (
    <>
      {room && (
        <div
          className="App"
          style={{
            backgroundImage: `url(https://localhost:7160/Images/bg/${room.img})`,
            backgroundSize: 'cover',
            backgroundPosition: 'center',
            height: '100vh',
            color: 'white',
            backgroundColor: 'lightblue',
            padding: '20px'
          }}
        >
          <h1>{room.name}</h1>
          <p>{room.description}</p>
          <div>
            <CharacterDisplay roomId={roomId} />
            <ItemDisplay roomId={roomId} />
          </div>
          <ConnectionChanger
            roomId={roomId}
            onChangeRoom={(newRoomId: number) => setRoomId(newRoomId)}
          />
        </div>
      )}
    </>
  );
};

export default App;