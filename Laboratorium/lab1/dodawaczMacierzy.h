//
// Created by Radek Grzywacz on 09/10/2023.
//

#ifndef INC_4C668C11_GR03_REPO_DODAWACZMACIERZY_H
#define INC_4C668C11_GR03_REPO_DODAWACZMACIERZY_H

#include <iostream>
#include "macierz.h"

template <class T>
class DodawaczMacierzy
        : public Macierz<T>{
private:
    T suma = 0;
    T macierz[maxWiersz][maxKolumn];
public:

    DodawaczMacierzy(T macierz2[maxWiersz][maxKolumn]) : Macierz<T>(macierz2){
        for (int i = 0; i < maxWiersz; i++){
            for (int j = 0; j < maxKolumn; j++){
                macierz[i][j] = macierz2[i][j];
            }
        }
    }

    int dodajElementy() {
        for(int i = 0; i < maxWiersz; i++){
            for(int j = 0; j < maxKolumn; j++){
                suma += macierz[i][j];
            }
        }

        return suma;
    }



};


#endif //INC_4C668C11_GR03_REPO_DODAWACZMACIERZY_H
