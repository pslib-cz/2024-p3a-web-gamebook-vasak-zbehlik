import React, { useEffect, useState } from 'react';

interface Item {
  itemId: number;
  name: string;
  description: string;
  img: string;
  roomId: number;
  connection: number;
}

const InventoryMenu: React.FC = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [inventory, setInventory] = useState<Item[]>([]);

  useEffect(() => {
    const fetchItems = async () => {
      const storedItemIds = JSON.parse(localStorage.getItem('inventory') || '[]');
      const items = await Promise.all(
        storedItemIds.map(async (itemId: number) => {
          const response = await fetch(`/api/Items/${itemId}`);
          return response.json();
        })
      );
      setInventory(items);
    };

    if (isOpen){
    fetchItems();
  }
  }, [isOpen]);

  const toggleMenu = () => {
    setIsOpen(!isOpen);
  };

  return (
    <div className="inventory-menu">
      <button onClick={toggleMenu}>
        ☰
      </button>
      {isOpen && (
        <div>
          <h3>Inventory</h3>
          <ul>
            {inventory.map((item) => (
              <li key={item.itemId}>
                <img src={`/Images/item/${item.img}`} alt={item.name} />
                {item.name} ({item.description})
              </li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
};

export default InventoryMenu;