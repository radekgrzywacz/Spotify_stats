//
// Created by Radek Grzywacz on 20/11/2023.
//

#include "Student.h"
#include <fstream>
#include <sstream>
#include <set>
#include <map>
#include <unordered_map>
#include <stack>

int main(){

    vector<Student> students;
    ifstream file("/Users/radek/CLionProjects/4c668c11-gr03-repo/Laboratorium/lab4/students.txt");
    if (file.is_open()){
        string line;

        while(getline(file, line)){
            stringstream ss(line);
            string name;
            string surname;

            getline(ss, name, ' ');
            getline(ss, surname, ' ');

            students.emplace_back(name, surname);

        }
        file.close();
    }




    vector<Student> studentsInVector;
    deque<Student> studentsInDeque;
    list<Student> studentsInList;
    forward_list<Student> studentsInForwardList;

    cout << "VECTOR" << endl;

    for(int i = 0; i < 5; i++ ){
        students[i].addToTheEndOfTheVector(studentsInVector);
    }

    cout << "=====================================================================" << endl;

    for(int i = 5; i < 10; i++ ){
        students[i].addToTheBeginningOfTheVector(studentsInVector);
    }

    cout << "=====================================================================" << endl;

    for(int i = 10; i < 15; i++ ){
        students[i].addInTheMiddleOfTheVector(studentsInVector);
    }

    cout << "=====================================================================" << endl;

    auto start = high_resolution_clock::now();
    studentsInVector.at(5).getName();
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji odwołania przez at(): " << duration.count() << "ns" << endl;

    cout << "=====================================================================" << endl;

    start = high_resolution_clock::now();
    studentsInVector[5].getName();
    stop = high_resolution_clock::now();
    duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji odwołania przez []: " << duration.count() << "ns" << endl;


    cout << "=====================================================================" << endl;
    cout << "DEQUE" << endl;

    for(int i = 15; i < 20; i++ ){
        students[i].addToTheEndOfTheDeque(studentsInDeque);
    }

    cout << "=====================================================================" << endl;

    for(int i = 20; i < 25; i++ ){
        students[i].addToTheBeginningOfTheDeque(studentsInDeque);
    }

    cout << "=====================================================================" << endl;

    for(int i = 25; i < 30; i++ ){
        students[i].addInTheMiddleOfTheDeque(studentsInDeque);
    }

    cout << "=====================================================================" << endl;

    start = high_resolution_clock::now();
    studentsInDeque.at(5).getName();
    stop = high_resolution_clock::now();
    duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji odwołania przez at(): " << duration.count() << "ns" << endl;

    cout << "=====================================================================" << endl;

    start = high_resolution_clock::now();
    studentsInDeque[5].getName();
    stop = high_resolution_clock::now();
    duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji odwołania przez []: " << duration.count() << "ns" << endl;


    cout << "=====================================================================" << endl;
    cout << "LIST" << endl;

    for(int i = 30; i < 35; i++ ){
        students[i].addToTheEndOfTheList(studentsInList);
    }

    cout << "=====================================================================" << endl;

    for(int i = 35; i < 40; i++ ){
        students[i].addToTheBeginningOfTheList(studentsInList);
    }

    cout << "=====================================================================" << endl;

    for(int i = 40; i < 45; i++ ){
        students[i].addInTheMiddleOfTheList(studentsInList);
    }

    cout << "=====================================================================" << endl;

    cout << "W liście nie da się użyć ani [] ani at()" << endl;

    cout << "=====================================================================" << endl;
    cout << "FORWARD LIST" << endl;

    for(int i = 15; i < 20; i++ ){
        students[i].addToTheEndOfTheForwardList(studentsInForwardList);
    }

    cout << "=====================================================================" << endl;

    for(int i = 20; i < 25; i++ ){
        students[i].addToTheBeginningOfTheForwardList(studentsInForwardList);
    }

    cout << "=====================================================================" << endl;

    for(int i = 25; i < 30; i++ ){
        students[i].addInTheMiddleOfTheForwardList(studentsInForwardList);
    }

    cout << "=====================================================================" << endl;

    cout << "W liście nie da się użyć ani [] ani at()" << endl;

    cout << "=====================================================================" << endl;

    cout << "ZAD 2" << endl;

    set<int> s;
    s.insert(1);
    s.insert(2);
    s.insert(3);
    s.insert(1);

    multiset<int> ms;
    ms.insert(1);
    ms.insert(2);
    ms.insert(3);
    ms.insert(1);

    set<int>::iterator it, it1, it2;
    for (it = s.begin(); it != s.end(); it++)
        cout << *it << ' ';
    cout << endl;

    multiset<int>::iterator it3, it4, it5;
    for (it = ms.begin(); it != ms.end(); it++)
        cout << *it << ' ';
    cout << '\n';

    //Różnice są takie, że set pozbywa się duplikatów

    map<int, Student> mp;
    unordered_map<int, Student> unMap;

    for(int i = 0; i < 10; i++){
        mp.insert(make_pair(i, students[i]));
        unMap.insert(make_pair(i, students[i]));
    }

    cout << "Map:" << endl;


    for (const auto& pair : mp) {
        cout << "Key: " << pair.first << ", Value: " << pair.second.name + " " + pair.second.surname << endl;

    }

    cout << "Unordered map:" << endl;

    for (const auto& pair : unMap) {
        cout << "Key: " << pair.first << ", Value: " << pair.second.name + " " + pair.second.surname << endl;

    }

    //Kolejność jest różna






    cout << "ZAD 3" << endl;

    stack<string> karton;
    karton.push("prezent 1");
    karton.push("prezent 2");
    karton.push("prezent 3");
    cout << karton.top() << endl;
    karton.pop();
    cout << karton.top() << endl;
    karton.push("prezent 4");
    cout << karton.top() << endl;
    karton.pop();
    cout << karton.top() << endl;


}