#include <iostream>
#include <string>
#include "macierz.h"
#include "dodawaczMacierzy.h"

using namespace std;

// ZADANIE 1
template <typename T> T GetMin(T a, T b){
    if(a < b){
        return a;
    } else {
        return b;
    }
}
string GetMin(string a, string b){
    if(a.length() < b.length()){
        return a;
    } else return b;
}

int main() {
    int i = 3;
    int j = 1;
    int k = GetMin(i, j);
    cout << "Najmniejsza: " << k << endl;

    double d = 3.1;
    double e = 9.7;
    double f = GetMin(d,e);
    cout << "Najmniejsza: " << k << endl;


    string s = "ul";
    string u = "pszczola";
    string r = GetMin(s, u);
    cout << "Najmniejsza: " << r << endl;


    // ZADANIE 2
    int macierzInt[maxWiersz][maxKolumn] = {{9,2,6}, {12,5,6},
                                            {10,1,0}};

    double macierzDouble[maxWiersz][maxKolumn] = {{9.3,2.3,6.1}, {12.6,5.4,6.9},
                                                  {10.5,1.1,0.2}};
    Macierz<int> m1(macierzInt);
    Macierz<double> m2(macierzDouble);

    m1.wyswietlMacierz();
    m2.ustElement(1,3,5.4);
    m2.wyswietlMacierz();

    Macierz<int> m3(macierzInt);
    m3.odejTablice(macierzInt);
    m3.wyswietlMacierz();

    DodawaczMacierzy<double> m4(macierzDouble);
    m4.wyswietlMacierz();

    m4.dodajElementy();
    cout << "Suma macierzy: " << m4.dodajElementy() << endl;

    m4.wyswietlMacierz();


}