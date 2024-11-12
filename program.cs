char[,] matrix = new char[3, 3];
char player = 'X';

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        matrix[i, j] = ' ';
    }
}

for (int num = 0; num < 9; num++)
{
    // Вывод поля
    Console.Clear();
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(matrix[i, j]);
            if (j < 2) Console.Write(" | ");
        }
        Console.WriteLine();
        if (i < 2) Console.WriteLine("---------");
    }

    // Запрос хода
    Console.WriteLine($"Игрок {player}, введите ваш ход (строка и колонка): ");
    int row = int.Parse(Console.ReadLine()) - 1;
    int col = int.Parse(Console.ReadLine()) - 1;

    // Проверка
    if (row < 0 || row > 2 || col < 0 || col > 2 || matrix[row, col] != ' ')
    {
        Console.WriteLine("Недопустимый ход, попробуйте снова.");
        num--; // недопустимый ход поэтоиу повтор
        continue;
    }

    matrix[row, col] = player;

    // Проверка на победу
    bool win = false;
    for (int i = 0; i < 3; i++)
    {
        if ((matrix[i, 0] == player && matrix[i, 1] == player && matrix[i, 2] == player) || // проверка по строкам
            (matrix[0, i] == player && matrix[1, i] == player && matrix[2, i] == player))
        {
            win = true;
            break;
        }
    }

    //Наискось
    if ((matrix[0, 0] == player && matrix[1, 1] == player && matrix[2, 2] == player) ||
        (matrix[0, 2] == player && matrix[1, 1] == player && matrix[2, 0] == player))
    {
        win = true;
    }

    if (win)
    {
        Console.Clear();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrix[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("---------");
        }
        Console.WriteLine($"Игрок {player} выиграл!");
        return; //Завершаем если победа
    }

    // Смена игрока
    if(player == 'X')
    {
        player = 'O';
    }
    else
    {
        player = 'X';
    }
}

// Ничья
Console.Clear();
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(matrix[i, j]);
        if (j < 2) Console.Write(" | ");
    }
    Console.WriteLine();
    if (i < 2) Console.WriteLine("---------");
}
Console.WriteLine("Ничья!");
