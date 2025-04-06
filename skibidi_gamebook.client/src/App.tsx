import React, { useState, useEffect } from 'react';
import './App.css';
import ConnectionChanger from './Components/ConnectionChanger';
import ItemDisplay from './Components/ItemDisplay';
import CharacterDisplay from './Components/CharacterDisplay';
import InventoryMenu from './Components/InventoryMenu';
import { useNavigate } from "react-router-dom";

const ServerUrl = '62.pslib.cloud'
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

  const updateCurrency = (characterId: number) => {
    if (characterId % 8 === 0) {
      setCurrency(currency + 1);
    } else if (characterId % 8 === 1) {
      setCurrency(currency - 1);
    } else if (characterId % 8 === 2) {
      setCurrency(currency + 3);
    }
    else if (characterId % 8 === 3) {
      setCurrency(currency - 3);
    }
    else if (characterId % 8 === 4) {
      setCurrency(currency + 5);
    }
    else if (characterId % 8 === 5) {
      setCurrency(currency - 5);
    }
    else if (characterId % 8 === 6) {
      setCurrency(currency + 10);
    }
    else if (characterId % 8 === 7) {
      setCurrency(currency - 10);
    }
  }

  return (
    <>
      {room && (
        <div
          className="App"
          style={{
            backgroundImage: `url(https://localhost:7160/wwwroot/Images/bg/${room.img})`,
            backgroundSize: 'cover',
            backgroundPosition: 'center',
            height: '100vh',
            color: 'white',
            backgroundColor: 'lightblue',
            padding: '20px',
            position: 'relative'
          }}
        >
          <InventoryMenu />
          <div className="currency-display">
            {currency}
          </div>
          <div className="room-info">
            <h1>{room.name}</h1>
            <p>{room.description}</p>
          </div>
          <div className="character-display">
            {room?.character && (
            <CharacterDisplay roomId={roomId} updateCurrency={updateCurrency}/>)}
          </div>
          <div className="item-display">
            {room?.items && room.items.length > 0 && (
            <ItemDisplay roomId={roomId} />)}
          </div>
          <div className="connection-buttons">
            <ConnectionChanger
              roomId={roomId}
              currency={currency}
              onChangeRoom={handleChangeRoom}
            />
          </div>
        </div>
      )}
    </>
  );
};

export default App;