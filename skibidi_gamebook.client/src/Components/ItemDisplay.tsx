import React, { useEffect, useState } from 'react';

interface Item {
  iId: number;
  name: string;
  count: number;
  description?: string;
  img: string;
  locationId: number;
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
        const response = await fetch(`https://localhost:7160/api/Items/room/${roomId}`);
        const jsonData = await response.json();
        setItems(jsonData);
      } catch (error) {
        setError('Error fetching items');
        console.error('Error fetching items:', error);
      }
    })();
  }, [roomId]);

  const handleItemClick = (item: Item) => {
    const storedItems = JSON.parse(localStorage.getItem('inventory') || '[]');
    storedItems.push(item);
    localStorage.setItem('inventory', JSON.stringify(storedItems));
  };

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {items.length > 0 && (
        <div>
          <ul>
            {items.map((item) => (
              <li key={item.iId} onClick={() => handleItemClick(item)}>
                <img src={`https://localhost:7160/Images/item/${item.img}`} alt={item.name} />
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

const InventoryMenu: React.FC = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [inventory, setInventory] = useState<Item[]>([]);

  useEffect(() => {
    const storedItems = JSON.parse(localStorage.getItem('inventory') || '[]');
    setInventory(storedItems);
  }, []);

  const toggleMenu = () => {
    setIsOpen(!isOpen);
  };

  return (
    <div style={{ position: 'fixed', top: 0, right: 0 }}>
      <button onClick={toggleMenu} style={{ padding: '10px', backgroundColor: 'gray', color: 'white' }}>
        ☰
      </button>
      {isOpen && (
        <div style={{ backgroundColor: 'white', color: 'black', padding: '10px', border: '1px solid black' }}>
          <h3>Inventory</h3>
          <ul>
            {inventory.map((item) => (
              <li key={item.iId}>
                <img src={`https://localhost:7160/Images/item/${item.img}`} alt={item.name} />
                {item.name} ({item.description})
              </li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
};

export default ItemDisplay;