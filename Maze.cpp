#include "pch.h"
#include <iostream>
#include <time.h>

using namespace std;

class maze {
private:
	int n;
	char **field;
public:
	maze(int dim)
	{
		n = dim;
		if (n % 2 != 0)
		{
			 field = new char*[n];
			for (int i = 0; i < n; i++)
			{
				field[i] = new char[n];
			}
			
		}
		else
			cout << "N должно быть нечетным" << endl;
	}
	~maze()
	{
		for (int i = 0; i < n; i++)
			delete[] field[i];
	}
	void show()
	{
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				if((field[i][j]=='#')||(field[i][j]=='+'))
					cout << field[i][j];
				else 
					cout << ' ';
			}
			cout << endl;
		}
	}
	void gen() 
	{
		srand(time(NULL));
		for (int i = 0; i < n; i++)
		{
			//отрисовка внешних стен комнаты
			field[i][0] = '#';
			field[i][n - 1] = '#';
			field[0][i] = '#';
			field[n - 1][i] = '#';
		}
		for (int i = 1; i < n - 3; i += 2)// счет по 2, т.к за проход обрабатывается 2 строки лабиринта
		{
			int cnt = 0; //переменная, считающая кол-во стенок между комнатами в строке, чтобы посчитать комнаты
			for (int j = 1; j < n - 1; j += 2)
			{
				//каждой комнате присваивается буквенное обозначение. 1 буква-1 комната
				field[i][j] = 'a' + j + cnt;
			}
			for (int j = 1; j < n - 2; j += 2)//генерация внутренних стен
			{
				if (((rand() %2==0) || (field[i][j] == field[i][j + 2])) && (field[i - 1][j+1] != ' '))
				{
					/*если рандом или две ячейки принадлежат одной комнате и над ними
					не заспавнился выход (костыль для увеличения кол-ва ходов)- ставим стену справа
					*/
					field[i][j + 1] = '#';
					cnt++;
				}
				else
				{
					//если не ставим стену, то ячейки в одной комнате
					field[i][j + 2] = field[i][j];
				}
				/*	if (field[1][j + 1] == '#')
						field[1 + 1][j + 1] = '#';*/
			}
			int iterator = 0, cellmin = 0;
			/*
			iterator после каждого прохода указывает на 1-ую ячейку следующей комнаты
			а callmin на 1-ую ячейку текущей. Т.Е последняя ячейка текущей комнаты находится по
			формуле (iterator-1)*2 +1, т.к iterator двигается только по нечетным ячейкам
			*/
			for (int t = 0; t < cnt + 1; t++)//сколько комнат, столько проверок
			{
				int cellmax = 1;//переменная для упрощенного вычисления последней ячейки комнаты
				//bool is_exit = false;
				cellmin = iterator;
				/*
					Я блядь знаю, что это короче делается через while, но т.к я
					изначально хотел сделать алгоритм с более изощренной генерацией
					(комментарий ниже, не доделано), я высрал это:
				*/
				for (int j = iterator * 2 + 1; j < n - 2; j += 2)//подсчет ячеек в комнате
				{
					if (field[i][j] == field[i][j + 2])
					{
						cellmax++;
						iterator++;
					}
					else
					{
						iterator++;
						break;
					}
				}
				// Debug cout
				//cout << cellmax << ' ' << iterator * 2 + 1 << ' ' << cellmin * 2 + 1 << endl;
				/*for (int j = cellmin * 2 + 1; j < (cellmin + cellmax)*2; j += 2)
				{
				БЛЯДЬ
					if ((true)&&(cellmax>1))
					{
						field[1 + 1][j] = '#';
						field[1 + 1][j + 1] = '#';
					}
					else
						is_exit = true;
					if ((j == (cellmin + cellmax) * 2) && (!is_exit))
					{
						field[1 + 1][j] = '#';
						field[1 + 1][j + 1] = '#';
					}
				}
				cellmin += cellmax;
				*/

				/*
				Упрощенная версия:
				В каждой комнате - 1 выход, который случайно определяется размером комнаты:
				*/
				field[i + 1][cellmin * 2 + 1 + rand() % (cellmax * 2 - 1)] = ' ';
			}
			for (int j = 1; j < n - 1; j += 2)
			{
				/*
				В комнатах на местах, где потенциально могли сгенерироваться стены, остаются пустые места
				Их надо присоединить к комнате, в которой они находятся
				*/
				if (field[i][j + 1] != '#')
					field[i][j + 1] = field[i][j];
			}
			for (int j = 1; j < n - 1; j++)
			{
				/*
				Возведение нижних стен везде, кроме найденных ранее выходов из комнат
				*/
				if (field[i + 1][j] != ' ')
					field[i + 1][j] = '#';
			}
			//генерация черных квадратов
			for (int j = 1; j < n - 1; j++)
			{
				if ((field[i + 1][j] == '#') && (field[i + 1][j+1] != ' ') && (field[i + 1][j -1] != ' ') && (rand() % 10 == 0))
					field[i + 1][j] = '+';
			}
			for (int j = 1; j < n - 1; j += 2)
			{
				//копирование текущей строки в следующую для их совмещения
				field[i + 2][j] = field[i][j];
			}
			for (int j = 1; j < n - 1; j++)
			{
				//сносим стены на следующей строке и разгруппируем ячейки, которые имели нижние границы
				if (field[i + 1][j] == '#')
				{
					//	field[1 + 3][j] = field[1 + 1][j];
					field[i + 2][j] = ' ';
				}
			}
		}
		// генерация выхода (ТОЛЬКО НЕЧЕТНЫЕ ЧИСЛА)
		field[1+rand()%(n/2)*2][0] = ' ';
	}
};
int main()
{
	maze mymaze(25);
	mymaze.gen();
	mymaze.show();
}


