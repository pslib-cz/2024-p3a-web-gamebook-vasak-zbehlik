import React, { useState, useEffect } from 'react';
import './App.css';
import ConnectionList from './components/ConnectionList';
import RoomDetails from './components/RoomDetails';
import CharacterDetails from './components/CharacterDetails';
import ItemList from './components/ItemList';
import { Room, Connection, Item } from './types';
import { useNavigate } from "react-router-dom";

const App: React.FC = () => {
  const [room, setRoom] = useState<Room | null>(null);
  const [connections, setConnections] = useState<Connection[]>([]);
  const [roomId, setRoomId] = useState<number>(1);
  const [items, setItems] = useState<Item[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    (async () => {
      try {
        const response = await fetch(`https://localhost:7160/api/Rooms/${roomId}`);
        if (!response.ok) {
          throw new Error(`Failed to fetch room: ${response.statusText}`);
        }
        const jsonData = await response.json();
        setRoom(jsonData);

        const response2 = await fetch(`https://localhost:7160/api/Connections/From/${roomId}`);
        if (!response2.ok) {
          throw new Error(`Failed to fetch connections: ${response2.statusText}`);
        }
        const jsonData2 = await response2.json();
        setConnections(Array.isArray(jsonData2) ? jsonData2 : []);

        const response3 = await fetch(`https://localhost:7160/api/Items/Location/${roomId}`);
        if (!response3.ok) {
          throw new Error(`Failed to fetch items: ${response3.statusText}`);
        }
        const jsonData3 = await response3.json();
        setItems(jsonData3);

        navigate(`/Rooms/${jsonData.rId}`);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    })();
  }, [roomId, navigate]);

  return (
    <div>
      {room && (
        <div className="App">
          <RoomDetails room={room} />
          {room.charName && room.charImg && room.chartext && (
            <CharacterDetails character={{ name: room.charName, img: room.charImg, text: room.chartext }} />
          )}
          {items.length > 0 && <ItemList items={items} />}
          <ConnectionList connections={connections} onChangeRoom={setRoomId} />
        </div>
      )}
    </div>
  );
};

export default App;