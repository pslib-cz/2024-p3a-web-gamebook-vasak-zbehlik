import React, { useState, useEffect } from 'react';
import './App.css';
import ConnectionChanger from './Components/ConnectionChanger';
import ItemDisplay from './Components/ItemDisplay';
import CharacterDisplay from './Components/CharacterDisplay';
import { useNavigate } from "react-router-dom";

interface Connection {
  connectionId: number;
  name: string;
  lock: number;
  requieremenId: number;
  fromId: number;
  toId: number;
}

interface Item {
  itemId: number;
  name: string;
  description: string;
  img: string;
  roomId: number;
  connection: Connection;
}

interface Character {
  characterId: number;
  name: string;
  text: string;
  img: string;
  whereId: number;
}

interface Room {
  roomId: number;
  name: string;
  description: string;
  img: string;
  connections: Connection[];
  items: Item[];
  connection: Connection;
  character: Character;
}

const App: React.FC = () => {
  const [room, setRoom] = useState<Room | null>(null);
  const [roomId, setRoomId] = useState<number>(1);
  const [currency, setCurrency] = useState<number>(0);
  const navigate = useNavigate();

  useEffect(() => {
    (async () => {
      try {
        const response = await fetch(`https://localhost:7160/api/Rooms/${roomId}`);
        const text = await response.text();
        if (text) {
          const jsonData = JSON.parse(text);
          setRoom(jsonData);
          navigate(`/Rooms/${jsonData.roomId}`);
        } else {
          console.error('Empty response');
        }
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    })();
  }, [roomId, navigate]);

  const handleChangeRoom = (newRoomId: number) => {
    setRoomId(newRoomId);
  };

  const increaseCurrency = (amount: number) => {
    setCurrency(currency + amount);
  };

  const decreaseCurrency = (amount: number) => {
    setCurrency(currency - amount);
  };

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
            padding: '20px',
            position: 'relative'
          }}
        >
          <div style={{ position: 'absolute', top: '10px', left: '10px', backgroundColor: 'rgba(0, 0, 0, 0.5)', padding: '10px', borderRadius: '5px' }}>
            <p>Currency: {currency}</p>
            {/* <button onClick={() => increaseCurrency(10)}>Increase</button>
            <button onClick={() => decreaseCurrency(10)}>Decrease</button> */}
          </div>
          <h1>{room.name}</h1>
          <p>{room.description}</p>
          <div>
            <CharacterDisplay roomId={roomId} />
            <ItemDisplay roomId={roomId} />
          </div>
          <ConnectionChanger
            roomId={roomId}
            currency={currency}
            onChangeRoom={handleChangeRoom}
          />
        </div>
      )}
    </>
  );
};

export default App;