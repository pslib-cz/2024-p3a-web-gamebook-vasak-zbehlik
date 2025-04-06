import React, { useEffect, useState } from 'react';
import InventoryMenu from './InventoryMenu';

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

interface ItemDisplayProps {
  roomId: number;
}

const ItemDisplay: React.FC<ItemDisplayProps> = ({ roomId }) => {
  const [items, setItems] = useState<Item[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    (async () => {
      try {
        const response = await fetch(`/api/Items/room/${roomId}`);
        const jsonData = await response.json();
        setItems(jsonData);
      } catch (error) {
        setError('Error fetching items');
        console.error('Error fetching items:', error);
      }
    })();
  }, [roomId]);

  const handleItemClick = (item: Item) => {
    const storedItemIds = JSON.parse(localStorage.getItem('inventory') || '[]');
    if (!storedItemIds.includes(item.itemId)) {
      storedItemIds.push(item.itemId);
      localStorage.setItem('inventory', JSON.stringify(storedItemIds));
    }
  };

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {items.length > 0 && (
        <div>
          <ul>
            {items.map((item) => (
              <li key={item.itemId} onClick={() => handleItemClick(item)}>
                <img src={`/Images/item/${item.img}`} alt={item.name} />
                {item.name} ({item.description})
              </li>
            ))}
          </ul>
        </div>
      )}
      <InventoryMenu />
    </div>
  );
};

export default ItemDisplay;