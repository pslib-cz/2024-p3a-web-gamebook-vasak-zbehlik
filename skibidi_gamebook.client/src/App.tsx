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
  charName?: string;
  charImg?: string;
  chartext?: string;
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

interface Item {
  iId: number;
  name: string;
  count: number;
  description?: string;
  img: string;
  locationId: number;
}
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
            const jsonData = await response.json();
            setRoom(jsonData);
           const response2 = await fetch(`https://localhost:7160/api/Connections/from/${roomId}`);
            const jsonData2 = await response2.json();
            setConnections(jsonData2);
            const response3 = await fetch(`https://localhost:7160/api/Items/room/${roomId}`);
            const jsonData3 = await response3.json();
            setItems(jsonData3);
          navigate(`/Rooms/${jsonData.rId}`);
          console.log(jsonData);
          console.log(jsonData2);
          console.log('Background Image URL:', `https://localhost:7160/Images/bg/${room?.img}`);
          console.log('character Image URL:', `https://localhost:7160/Images/char/${room?.img}`);
          console.log('Item Image URL:', `https://localhost:7160/Images/item/${room?.img}`);
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

            {room.charName && room.charImg && room.chartext && (
            <div>
              <h2>{room.charName}</h2>
              <img src={`https://localhost:7160/Images/char/${room.charImg}`} alt={room.charName} />
                <p>{room.chartext}</p>
            </div>)}

            {items.length > 0 && (
            <div>
              <ul>
                {items.map((item) => (
                  <li key={item.iId}>
                    <img src={`https://localhost:7160/Images/item/${item.img}`} alt={item.name} />
                    {item.name} ({item.description})
                  </li>
                ))}
              </ul>
            </div>)}

          </div>
          {connections.map((connection) => (
            <ConnectionChanger
              key={connection.cId}
              onChangeRoom={(newRoomId: number) => setRoomId(newRoomId)}
              targetRoomId={connection.roomId}
              name={connection.name}
            />
          ))}
        </div>
      )}
      </>
      
    


      

  );
};

export default App;