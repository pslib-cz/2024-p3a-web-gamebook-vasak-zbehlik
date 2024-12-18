import React, { useEffect, useState } from 'react';

// Define interfaces
interface Room {
  RId: number;
  Name: string;
  Description: string;
  Img?: string;
}

interface Connection {
  CId: number; // Connection ID
  RoomId: number; // Target Room ID
  Lock: number; // Indicates if a lock exists (0 = no lock, 1 = locked)
  ItemId: number; // Required item for lock (if applicable)
  AchievementId: number; // Required achievement for lock
}

const App: React.FC = () => {
  const [currentRoom, setCurrentRoom] = useState<Room | null>(null);
  const [connections, setConnections] = useState<Connection[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [currentRoomId, setCurrentRoomId] = useState<number>(1); // Starting Room ID

  // Fetch room and connections when currentRoomId changes
  useEffect(() => {
    const fetchRoomData = async () => {
      setLoading(true);
      try {
        // Fetch current room data
        const roomResponse = await fetch(`https://localhost:7160/api/Rooms/${currentRoomId}`);
        if (!roomResponse.ok) {
          throw new Error(`Error: ${roomResponse.status} - ${roomResponse.statusText}`);
        }
        const roomData: Room = await roomResponse.json();

        // Fetch connections for the current room
        const connectionsResponse = await fetch(
          `https://localhost:7160/api/Connections/${currentRoomId}`
        );
        if (!connectionsResponse.ok) {
          throw new Error(
            `Error: ${connectionsResponse.status} - ${connectionsResponse.statusText}`
          );
        }
        const connectionsData: Connection[] = await connectionsResponse.json();

        // Set state
        setCurrentRoom(roomData);
        setConnections(connectionsData);
      } catch (err: unknown) {
        setError((err as Error).message || 'Something went wrong.');
      } finally {
        setLoading(false);
      }
    };

    fetchRoomData();
  }, [currentRoomId]); // Trigger when currentRoomId changes

  // Handle navigating to a new room
  const handleRoomChange = (nextRoomId: number) => {
    setCurrentRoomId(nextRoomId);
  };

  // Loading/Error states
  if (loading) return <div>Loading...</div>;
  if (error) return <div style={{ color: 'red' }}>Error: {error}</div>;

  // Render Room and Navigation
  return (
    <div
      style={{
        backgroundImage: `url(${currentRoom?.Img || 'https://localhost:7160/Images/plovoucka-rub.jpg'})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        height: '100vh',
        color: 'white',
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'space-between',
        padding: '20px',
        textShadow: '1px 1px 3px black',
      }}
    >
      {/* Room Header */}
      <div style={{ textAlign: 'center' }}>
        <h1>{currentRoom?.Name}</h1>
        <p>{currentRoom?.Description}</p>
      </div>

      {/* Navigation Buttons */}
      <div style={{ display: 'flex', justifyContent: 'center', gap: '10px' }}>
        {connections.map((connection) => {
          const isLocked = connection.Lock !== 0;

          return (
            <button
              key={connection.CId}
              onClick={() => !isLocked && handleRoomChange(connection.RoomId)}
              style={{
                backgroundColor: isLocked ? 'rgba(128, 0, 0, 0.7)' : 'rgba(0, 0, 0, 0.7)',
                color: 'white',
                border: '2px solid white',
                padding: '10px 20px',
                borderRadius: '8px',
                cursor: isLocked ? 'not-allowed' : 'pointer',
                opacity: isLocked ? 0.5 : 1,
                fontSize: '1rem',
              }}
              disabled={isLocked}
            >
              {isLocked
                ? `Locked (Item: ${connection.ItemId || 'N/A'})`
                : `Go to Room ${connection.RoomId}`}
            </button>
          );
        })}
      </div>
    </div>
  );
};

export default App;
