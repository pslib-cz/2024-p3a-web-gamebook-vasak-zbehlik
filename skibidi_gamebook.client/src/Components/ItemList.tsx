import React from 'react';
import { Item } from '../types';

interface ItemListProps {
  items: Item[];
}

const ItemList: React.FC<ItemListProps> = ({ items }) => {
  return (
    <div>
      {items.length > 0 && (
        <ul>
          {items.map((item) => (
            <li key={item.iId}>
              <img src={`https://localhost:7160/Images/item/${item.img}`} alt={item.name} />
              {item.name} ({item.description})
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default ItemList;