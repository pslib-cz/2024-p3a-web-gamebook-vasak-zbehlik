export interface Room {
  rId: number;
  name: string;
  description: string;
  img?: string;
  charName?: string;
  charImg?: string;
  chartext?: string;
}

export interface Connection {
  cId: number;
  fromId: number;
  roomId: number;
  name: string;
  lock: number;
  itemId?: number;
  achievementId?: number;
}

export interface Item {
  iId: number;
  name: string;
  count: number;
  description?: string;
  img: string;
  locationId: number;
}