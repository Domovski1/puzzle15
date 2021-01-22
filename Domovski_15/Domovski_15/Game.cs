using System;

namespace Domovski_15
{
    class Game
    {
        int spaceX, spaceY, size;
        int[,] map;
        static Random rand = new Random();

        public void shift(int position)
        {
            int x, y;
            position_to_coords(position, out x, out y);
            if (Math.Abs(spaceX - x) + Math.Abs(spaceY - y) != 1)
                return;
            map[spaceX, spaceY] = map[x, y];
            map[x, y] = 0;
            spaceX = x; spaceY = y;

        } // Выполняет перещение цифр по полю

        public void shift_random()
        {
            // простая версия игры
            //shift(rand.Next(0, size * size));

            int a = rand.Next(0, 4);
            int x = spaceX;
            int y = spaceY;
            switch(a)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            shift (coords_to_position(x, y));

        } // логика перемещений для функии shift()

        public Game(int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            map = new int[size, size];
        } // Генерирует игровое поле для игры

        public bool Check()
        {
            if (!(spaceX == size - 1 && spaceY == size - 1))
                return false;

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (!(x == size - 1 && y == size - 1))
                        if (map[x, y] != coords_to_position(x, y) + 1)
                        return false;
            return true;
            
        } // Проверяет условия для окончания игры

        public void start ()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x, y] = coords_to_position(x, y) + 1;
            spaceX = size - 1;
            spaceY = size - 1;
            map[spaceX, spaceY] = 0;
        } // начинает игру

        public int getNumber (int position)
        {
            int x, y;
            position_to_coords(position, out x, out y);

            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;

            return map[x, y];

        }

        private int coords_to_position(int x, int y)
        {
            if (x < 0) x = 0;
            if (x > size - 1) x = size - 1;
            if (y < 0) y = 0;
            if (y > size - 1) y = size - 1;
            return y * size + x;
        } // Переводит координаты в позицию

        private void position_to_coords (int position, out int x, out int y) {
            if (position < 0) position = 0;
            if (position > size * size - 1) position = size * size - 1;
            x = position % size;
            y = position / size;
        } // Переводит номер кнопки в координаты
    }
}

// Created by Domovski1