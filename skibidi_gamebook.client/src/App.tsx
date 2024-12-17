import React, { useEffect, useState } from 'react';
import './App.css'; // Optional styling import

const App: React.FC = () => {
  const [rooms, setRooms] = useState<Room[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState<boolean>(true);

  // Fetch data from the API
  useEffect(() => {
    const fetchRooms = async () => {
      try {
        const response = await fetch('http://localhost:5000/api/Locations'); // Replace with your API endpoint
        if (!response.ok) {
          throw new Error(`Error: ${response.status} - ${response.statusText}`);
        }
        const data: Location[] = await response.json();
        setRooms(data);
      } catch (err: unknown) {
        setError((err as Error).message || 'Something went wrong.');
      } finally {
        setLoading(false);
      }
    };

    fetchRooms();
  }, []);

  // Render the component
  return (
    <div className="App">
      <h1>Room List</h1>
      {loading && <p>Loading...</p>}
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {!loading && !error && (
        <ul>
          {rooms.map((room) => (
            <li key={room.RId}>
              <h2>{room.Name}</h2>
              <p>{room.Description}</p>
              {room.Img && <img src={room.Img} alt={room.Name} style={{ width: '200px' }} />}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default App;
