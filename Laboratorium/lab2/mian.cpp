#include <iostream>
#include <list>
#include <random>

using namespace std;

list<int> generateAndSort(int N, int min, int max){
    list<int> numbers;
    int number;
    for(int i =0; i < N; i++){
        number = rand() % 100;
        numbers.push_back(number);
    }
    cout << "Wygenerowane: ";
    for(int num: numbers){
        cout << num << ", ";
    }
    cout << endl;
    numbers.sort();
    cout << "Posortowane: ";
    for(int num: numbers){
        cout << num << ", ";
    }
    cout << endl;

    return numbers;
}

int main(){

    srand(time(0));
    list<int> numbers = generateAndSort(10, 0, 100);

    auto removeEvensWithRemoveMethod = [](list<int>& numbers){
        list<int> buff;
        buff = numbers;
        for(int num : buff){
            if(num %2 == 0){
                numbers.remove(num);
                continue;
            }
        }
    };



    removeEvensWithRemoveMethod(numbers);
    cout << "Ostateczne 1: " ;

    for(int num: numbers){
        cout << num << ", ";
    }
    cout << endl;

    srand(time(0));
    list<int> numbers2 = generateAndSort(10, 0, 100);

    auto removeEvensWithAlgorithm = [](list<int>& numbers2){
        list<int> buff;
        for(int num : numbers2){
            if(num %2 != 0){
                buff.push_back(num);
            }
        }
        numbers2 = buff;
        buff.clear();
    };

    removeEvensWithAlgorithm(numbers2);
    cout << "Ostateczne 2: " ;

    for(int num: numbers){
        cout << num << ", ";
    }
    cout << endl;



}

//#include <iostream>
//#include<list>
//using namespace std;
//int main() {
//    int n = 10;
//    list<int>Liczby;
//    list<int>Liczby2;
//    for (int i = 0; i < n; i++) {
//        Liczby.push_back(rand() % 100);
//    }
//    cout << "Wygenerowana lista1:";
//    for (const int& num : Liczby) {
//        cout << num << " ";
//    }
//    cout << endl;
//    for (int i = 0; i < n; i++) {
//        Liczby2.push_back(rand() % 100);
//    }
//    cout << "Wygenerowana lista2:";
//    for (const int& num : Liczby2) {
//        cout << num << " ";
//    }
//    cout << endl;
//    Liczby.sort();
//    Liczby2.sort();
//    cout << "Posortowana lista1:";
//    for (const int& num : Liczby) {
//        cout << num << " ";
//    }
//    cout << endl;
//    cout << "Posortowana lista2:";
//    for (const int& num : Liczby2) {
//        cout << num << " ";
//    }
//    cout << endl;
//    Liczby.remove_if([](int num) {
//        return num % 2 == 0; });
//    cout << "Lista 1 bez parzystych algorytm:";
//    for (const int& num : Liczby) {
//        cout << num << " ";
//    }
//    cout << endl;
//    auto Usunparzyste = [](list<int>& Liczby2) {
//        list<int> zmienna;
//        zmienna = Liczby2;
//        for (int num : zmienna) {
//            if (num % 2 == 0) {
//                Liczby2.remove(num);
//                continue;
//            }
//        }
//    };
//    Usunparzyste(Liczby2);
//    cout << "Lista 2 bez parzystych remove:";
//    for (const int& num : Liczby2) {
//        cout << num << " ";
//    }
//    cout << endl;
//}
