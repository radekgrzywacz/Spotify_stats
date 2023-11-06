//Zad. 1 (1 pkt) Za pomocą iteratora plikowego odczytaj pliki.
//Zad. 2 (1 pkt) Następnie za pomocą operatora zwykłego wyświetl zawartość tych plików.
//Zad. 3 (2 pkt) Za pomocą iteratora wstawiającego dodaj trzy kolejne elementy Ciągu
//Fibonacciego i wyświetl elementy ciągu wykorzystując iterator odwrotny.

#include <iostream>
#include <fstream>
#include <iterator>
using namespace std;

int main() {
    ifstream ss("/Users/radek/CLionProjects/4c668c11-gr03-repo/Laboratorium/lab3/text1.txt");

    istream_iterator<string> loremIterator(ss);
    istream_iterator<string> eos;

    string word;


    while (loremIterator != eos) {
        word = *loremIterator;
        if (word.at(word.length() - 1) == '.') {
            cout << endl;
        }
        cout << *loremIterator << " ";
        ++loremIterator;
    }


    cout << "\n ----ZADANIE 3-----" << endl;

    vector<int> fib = {0, 1, 1};

    back_insert_iterator<vector<int>> fibBackIt(fib);



    *fibBackIt = fib[fib.size() - 1] + fib[fib.size() - 2];

    *fibBackIt = fib[fib.size() - 1] + fib[fib.size() - 2];


    cout << "Ostatnia wstawiona cyfra: " << fib[fib.size() - 1] << endl;

    *fibBackIt = fib[fib.size() - 1] + fib[fib.size() - 2];

    cout << "Ostatnia wstawiona cyfra: " << fib[fib.size() - 2] << endl;

    cout << "Twój fibonacci: {";
    for (int i = 0; i < fib.size(); i++){
        if(i == fib.size() - 1){
            cout << fib[i] << "}";
        } else{
            cout << fib[i] << ", ";
        }
    }

    vector<int>::reverse_iterator it;
    cout << "\nOdwrócony ciąg to:";
    for( it=fib.rbegin(); it!=fib.rend(); ++it )
    {
        cout << *it << " ";
    }




}