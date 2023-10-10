#ifndef INC_4C668C11_GR03_REPO_MACIERZ_H
#define INC_4C668C11_GR03_REPO_MACIERZ_H


//
//  macierz.cpp
//  labolatorium 1
//
//  Created by Radek Grzywacz on 09/10/2023.
//

#include <iostream>
using namespace std;

const int maxWiersz = 3;
const int maxKolumn = 3;

template <class T>
class Macierz {
private:
    T macierz[maxWiersz][maxKolumn];
    int wiersze;
    int kolumny;
public:
    void wyswietlMacierz(){
        for(int i = 0; i < maxWiersz; i++){
            for(int j = 0; j < maxKolumn; j++){
                cout << " " <<  macierz[i][j] << "\t";
            }
            cout << endl;
        }

        cout << endl;
    }

    void ustElement(int w, int k, T wartosc){
        macierz[w][k] = wartosc;
    }

    void odejTablice(T tab[maxWiersz][maxKolumn]) {
        for (int i = 0; i < maxWiersz; i++) {
            for (int j = 0; j < maxKolumn; j++) {
                macierz[i][j] -= macierz[i][j];
            }
        }
    }

    Macierz(T nowaMacierz[maxWiersz][maxKolumn]){
        for(int i = 0; i < maxWiersz; i++){
            for(int j = 0; j < maxKolumn; j++){
                macierz[i][j] = nowaMacierz[i][j];
            }
            cout << endl;
        }

    }


};



#endif //INC_4C668C11_GR03_REPO_MACIERZ_H
