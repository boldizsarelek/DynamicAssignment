// Felvi_CEMS_EF_CORV_2022.cpp : This file contains the 'main' function. Program execution begins and ends there.


//#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <sstream>
//using namespace System;
//#include <stdio.h>
#include <new>
#include <algorithm>

struct korlat {
	long ID;
	char TIPUS;
	int IDEGEN_ID;
	int MINKERET;
	int MAXKERET;
	long SZP_ID;
};

struct jelentkezes {
	long SORREND;
	long ID;
	int SORSZAM;
	int PONTSZAM;
	double PONT2;
	long JEL_ID;
	long ALP_ID;
	long SZP_ID;
	int GS;
	int GS2;
	int KULFOLDI;
};


struct szemely {
	long ALP_ID;
	long START;
	long ACTUAL;
	long END;
	bool FINAL;
};

int main()
//int main(void)
{
	const long korlat_num = 9;
	const long jelentkezes_num = 333;
	korlat korlatok[1 + korlat_num];
	jelentkezes *jelentkezesek = new jelentkezes[1 + jelentkezes_num];
	jelentkezes *jelentkezesek_msd = new jelentkezes[1 + jelentkezes_num];
	//long *indexek = new long[1 + 383520];
	printf("Start \n");
	std::ifstream inputData;
	inputData.open("korlatok_szuk.txt");
	long infeas;

	for (int i = 1; i <= korlat_num; i++)
	{
		//printf("ciklus %i \n", i);
		inputData >> korlatok[i].ID;
		inputData >> korlatok[i].TIPUS;
		inputData >> korlatok[i].IDEGEN_ID;
		inputData >> korlatok[i].MAXKERET;
		inputData >> korlatok[i].MINKERET;
		inputData >> korlatok[i].SZP_ID;
	}
	inputData.close();

	inputData.open("jelentkezesek_szuk.txt");
	for (long j = 1; j <= jelentkezes_num; j++)
	{
		//printf("ciklus %i \n", j);
		inputData >> jelentkezesek[j].ID;
		inputData >> jelentkezesek[j].SORSZAM;
		inputData >> jelentkezesek[j].PONTSZAM;
		inputData >> jelentkezesek[j].PONT2;
		inputData >> jelentkezesek[j].JEL_ID;
		inputData >> jelentkezesek[j].ALP_ID;
		inputData >> jelentkezesek[j].SZP_ID;
		inputData >> jelentkezesek[j].KULFOLDI;
		jelentkezesek[j].GS = 0;
		jelentkezesek[j].GS2 = 0;
		//printf("jelemtkezesek %li %f \n", jelentkezesek[j].ID, jelentkezesek[j].PONT2);

	}
	inputData.close();

	////????????
	printf("korlatok %i %i %li \n", korlatok[korlat_num].ID, korlatok[korlat_num].MAXKERET, korlatok[korlat_num].SZP_ID);
	printf("jelemtkezesek %li %f %li \n", jelentkezesek[jelentkezes_num].ID, jelentkezesek[jelentkezes_num].PONT2, jelentkezesek[jelentkezes_num].SZP_ID);

	std::sort(jelentkezesek + 1, jelentkezesek + jelentkezes_num + 1, [](jelentkezes const &a, jelentkezes const &b) { return a.ALP_ID != b.ALP_ID ? a.ALP_ID < b.ALP_ID : a.SORSZAM < b.SORSZAM; });

	for (long i = 1; i <= jelentkezes_num; i++)
	{
		jelentkezesek[i].SORREND = i;
		jelentkezesek_msd[i].SORREND = jelentkezesek[i].SORREND;
		jelentkezesek_msd[i].ALP_ID = jelentkezesek[i].ALP_ID;
		jelentkezesek_msd[i].ID = jelentkezesek[i].ID;
		jelentkezesek_msd[i].JEL_ID = jelentkezesek[i].JEL_ID;
		jelentkezesek_msd[i].PONT2 = jelentkezesek[i].PONT2;
		jelentkezesek_msd[i].PONTSZAM = jelentkezesek[i].PONTSZAM;
		jelentkezesek_msd[i].SORSZAM = jelentkezesek[i].SORSZAM;
		jelentkezesek_msd[i].SZP_ID = jelentkezesek[i].SZP_ID;
		jelentkezesek_msd[i].KULFOLDI = jelentkezesek[i].KULFOLDI;
		jelentkezesek_msd[i].GS = jelentkezesek[i].GS;
		jelentkezesek_msd[i].GS2 = jelentkezesek[i].GS2;
	}

	printf("ind OK \n");

	//celfuggveny
	printf("Celfuggveny\n");
	std::ofstream LPout;
	std::ofstream CELfgv;
	LPout.open("FELVI.lp");
	CELfgv.open("CELFGV.lp");
	LPout << "min\n";

	long jelentkezo;
	jelentkezo = jelentkezesek[1].ALP_ID;
	long szem_counter = 1;
	for (long i = 1; i <= jelentkezes_num; i++)
	{
		LPout << " + " << jelentkezesek[i].SORSZAM << " X" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek[i].SZP_ID << "\n";
		//LPout << " + X" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek[i].SZP_ID << "\n";
		if (jelentkezesek[i].ALP_ID != jelentkezo)
		{
			szem_counter++;
			jelentkezo = jelentkezesek[i].ALP_ID;
		}
	}

	printf("celf OK \n");

	//korlatok:jelentkezo
	printf("Korlatok: Jelentkezo\n");
	LPout << "\n" << "subject to" << "\n";

	for (long i = 1; i <= jelentkezes_num; i++)
	{
		//LPout << "+X" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek[i].SZP_ID << "\n";
	}


	jelentkezo = jelentkezesek[1].ALP_ID;
	LPout << "kE" << jelentkezo << ":\n";




	for (long i = 1; i <= jelentkezes_num; i++)
	{
		//printf("SZ_P %i\n", jelentkezesek[i].ALP_ID);
		if (jelentkezesek[i].ALP_ID != jelentkezo)
		{
			LPout << " = 1 \n";
			jelentkezo = jelentkezesek[i].ALP_ID;
			LPout << "kE" << jelentkezo << ": \n";
		}
		LPout << " + X" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek[i].SZP_ID << "\n";
	}
	LPout << " = 1\n";

	printf("jel OK \n");


	//korlatok:szak
	printf("Korlatok: Szak felso\n");

	long szak;
	long sorszam = 0;


	std::sort(jelentkezesek_msd + 1, jelentkezesek_msd + jelentkezes_num + 1, [](jelentkezes const &c, jelentkezes const &d) { return c.SZP_ID != d.SZP_ID ? c.SZP_ID < d.SZP_ID : c.ID < d.ID; });
	std::sort(korlatok + 1, korlatok + korlat_num + 1, [](korlat const &a, korlat const &b) { return  a.SZP_ID < b.SZP_ID; });



	szak = jelentkezesek_msd[1].SZP_ID;

	do
	{
		sorszam++;

	} while (korlatok[sorszam].SZP_ID != szak);
	LPout << "kSZP" << szak << ": \n";



	for (long i = 1; i <= jelentkezes_num; i++)
	{
		if (jelentkezesek_msd[i].SZP_ID != szak)
		{
			LPout << " <= " << korlatok[sorszam].MAXKERET << " \n";
			szak = jelentkezesek_msd[i].SZP_ID;


			do
			{
				sorszam++;
			} while (korlatok[sorszam].SZP_ID != szak);

			LPout << "kSZP" << szak << ": \n";
		}
		LPout << " + " << "X" << jelentkezesek_msd[i].ALP_ID << "_" << jelentkezesek_msd[i].SZP_ID << "\n";
	}
	LPout << " <= " << korlatok[sorszam].MAXKERET << " \n";

	printf("szak felso OK \n");


	//korlatok:szak
	printf("Korlatok: Szak also\n");


	szak = jelentkezesek_msd[1].SZP_ID;
	sorszam = 0;

	do
	{
		sorszam++;

	} while (korlatok[sorszam].SZP_ID != szak);
	LPout << "kSZPa" << szak << ": \n";



	for (long i = 1; i <= jelentkezes_num; i++)
	{
		if (jelentkezesek_msd[i].SZP_ID != szak)
		{
			LPout << " >= " << korlatok[sorszam].MINKERET << "\n";
			szak = jelentkezesek_msd[i].SZP_ID;


			do
			{
				sorszam++;
			} while (korlatok[sorszam].SZP_ID != szak);

			LPout << "kSZPa" << szak << ": \n";
		}
		LPout << " + " << "X" << jelentkezesek_msd[i].ALP_ID << "_" << jelentkezesek_msd[i].SZP_ID << "\n";
	}
	LPout << " >= " << korlatok[sorszam].MINKERET << " \n";

	printf("szak also OK \n");


	//korlatok:szak
	printf("Korlatok: Szak kulfoldi\n");


	szak = jelentkezesek_msd[1].SZP_ID;
	sorszam = 0;

	do
	{
		sorszam++;

	} while (korlatok[sorszam].SZP_ID != szak);
	LPout << "kSZPk" << szak << ": \n";



	for (long i = 1; i <= jelentkezes_num; i++)
	{
		if (jelentkezesek_msd[i].SZP_ID != szak)
		{
			LPout << " <= 2 \n";
			szak = jelentkezesek_msd[i].SZP_ID;


			do
			{
				sorszam++;
			} while (korlatok[sorszam].SZP_ID != szak);

			LPout << "kSZPk" << szak << ": \n";
		}
		if (jelentkezesek_msd[i].KULFOLDI == 1)
		{
			LPout << " + " << "X" << jelentkezesek_msd[i].ALP_ID << "_" << jelentkezesek_msd[i].SZP_ID << "\n";
		}

	}
	LPout << " <= 2 \n";

	printf("szak also OK \n");


	//korlatok:stabilitas
	printf("Korlatok: Stabilitas\n");

	long i_viszonyitas;
	long jelentkezo_viszonyitas;
	long k;
	long l;
	std::string sztring = " ";
	std::stringstream ss;



	i_viszonyitas = 1;
	jelentkezo_viszonyitas = jelentkezesek[1].ALP_ID;;
	for (long i = 1; i <= jelentkezes_num; i++)
		//for (long i = 1; i <= 0; i++)
	{

		k = 0;
		l = 0;
		szak = jelentkezesek[i].SZP_ID;
		sorszam = jelentkezesek[i].SORSZAM;
		jelentkezo = jelentkezesek[i].ALP_ID;
		infeas = 0;
		//LPout << "kSt" << jelentkezo << "_" << sorszam << ":\n";
		if (jelentkezo != jelentkezo_viszonyitas)
		{
			jelentkezo_viszonyitas = jelentkezo;
			i_viszonyitas = i;

		}

		k = 0;
		l = 0;
		do
		{
			k++;
		} while (jelentkezesek_msd[k].SZP_ID != szak);


		do
		{
			l++;
		} while (korlatok[l].SZP_ID != szak);

		ss.str("");
		for (long j = i_viszonyitas; j <= i; j++)
		{
			ss << " + X" << jelentkezesek[j].ALP_ID << "_" << jelentkezesek[j].SZP_ID;

		}

		do
		{
			//if ((jelentkezesek_msd[k].PONTSZAM <= jelentkezesek[i].PONTSZAM) && (jelentkezesek_msd[k].ALP_ID != jelentkezesek[i].ALP_ID))
			if ((jelentkezesek_msd[k].PONTSZAM < jelentkezesek[i].PONTSZAM) && (jelentkezesek_msd[k].ALP_ID != jelentkezesek[i].ALP_ID) && (jelentkezesek[i].SORSZAM > 0))
			{
				// envy free mindenkire
				//LPout << ss.str() << " - X" << jelentkezesek_msd[k].ALP_ID << "_" << jelentkezesek_msd[k].SZP_ID << " >= 0\n";

				// envy free csoporton belul
				if (jelentkezesek_msd[k].KULFOLDI == jelentkezesek[i].KULFOLDI)
				{
					//LPout << ss.str() << " - X" << jelentkezesek_msd[k].ALP_ID << "_" << jelentkezesek_msd[k].SZP_ID << " >= 0 \n";
				}
				else
				{
					//LPout << ss.str() << " - X" << jelentkezesek_msd[k].ALP_ID << "_" << jelentkezesek_msd[k].SZP_ID;
					//LPout << " + B" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek_msd[k].ALP_ID << "_" << jelentkezesek[i].SZP_ID << " >= 0\n";

					//blokkolasok szam
					//CELfgv << " + 100 B" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek_msd[k].ALP_ID << "_" << jelentkezesek[i].SZP_ID << "\n";

					//blokkolasok intenzitasa
					//CELfgv << " + " <<100 * (jelentkezesek[i].PONTSZAM - jelentkezesek_msd[k].PONTSZAM)<<" B" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek_msd[k].ALP_ID << "_" << jelentkezesek[i].SZP_ID << "\n";
				}
				// envy free sehol
				LPout << ss.str() << " - X" << jelentkezesek_msd[k].ALP_ID << "_" << jelentkezesek_msd[k].SZP_ID;
				LPout << " + B" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek_msd[k].ALP_ID << "_" << jelentkezesek[i].SZP_ID << " >= 0\n";

				//blokkolasok szam
				CELfgv << " + 100 B" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek_msd[k].ALP_ID << "_" << jelentkezesek[i].SZP_ID << "\n";

				//blokkolasok intenzitasa
				//CELfgv << " + " <<100 * (jelentkezesek[i].PONTSZAM - jelentkezesek_msd[k].PONTSZAM)<<" B" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek_msd[k].ALP_ID << "_" << jelentkezesek[i].SZP_ID << "\n";


			}
			k++;
		} while (jelentkezesek_msd[k].SZP_ID == szak);

	}





	//bounds
	printf("korlatok <=1 \n");
	LPout << "bounds\n";

	for (long i = 1; i <= jelentkezes_num; i++)
	{
		//LPout << "0 <= X" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek[i].SZP_ID << " <= 1\n";
	}

	//egeszertekuse
	printf("Egeszertekuseg\n");

	LPout << "binary\n";

	for (long i = 1; i <= jelentkezes_num; i++)
	{
		LPout << "X" << jelentkezesek[i].ALP_ID << "_" << jelentkezesek[i].SZP_ID << "\n";
	}

	LPout << "end\n";

	LPout.close();
	CELfgv.close();


	return 0;

}
