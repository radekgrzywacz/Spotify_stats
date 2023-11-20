//
// Created by Radek Grzywacz on 20/11/2023.
//

#include "Student.h"

Student::Student(string n, string sn) {
    this->name = n;
    this->surname = sn;
}

string Student::getName() {
    return name;
}

string Student::getSurname() {
    return surname;
}

string Student::getBoth() {
    return name + " " +  surname;
}

void Student::addToTheEndOfTheVector(vector<Student> &studentsInVector){

    auto start = high_resolution_clock::now();
    studentsInVector.push_back(*this);
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na koniec wektora: " << duration.count() << "ns" << endl;

}

void Student::addToTheBeginningOfTheVector(vector<Student> &studentsInVector) {
    auto start = high_resolution_clock::now();
    studentsInVector.insert(studentsInVector.begin(), *this);
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na początek wektora: " << duration.count() << "ns" << endl;
}

void Student::addInTheMiddleOfTheVector(vector<Student> &studentsInVector) {
    auto start = high_resolution_clock::now();
    studentsInVector.insert(studentsInVector.begin() + 6, *this);
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na 6 pozycje wektora: " << duration.count() << "ns" << endl;
}

void Student::addToTheEndOfTheDeque(deque<Student> &studentsInDeque) {
    auto start = high_resolution_clock::now();
    studentsInDeque.push_back(*this);
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na koniec deque: " << duration.count() << "ns" << endl;
}

void Student::addToTheBeginningOfTheDeque(deque<Student> &studentsInDeque) {
    auto start = high_resolution_clock::now();
    studentsInDeque.push_front(*this);
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na początek deque: " << duration.count() << "ns" << endl;
}

void Student::addInTheMiddleOfTheDeque(deque<Student> &studentsInDeque) {
    auto start = high_resolution_clock::now();
    studentsInDeque.insert(studentsInDeque.begin() + 6,*this);
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na 6 pozycje deque: " << duration.count() << "ns" << endl;
}

void Student::addToTheEndOfTheList(list<Student> &studentsInList) {
    auto start = high_resolution_clock::now();
    studentsInList.push_back(*this);
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na koniec listy: " << duration.count() << "ns" << endl;
}

void Student::addToTheBeginningOfTheList(list<Student> &studentsInList) {
    auto start = high_resolution_clock::now();
    studentsInList.push_front(*this);
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na początek listy: " << duration.count() << "ns" << endl;
}

void Student::addInTheMiddleOfTheList(list<Student> &studentsInList) {
    auto start = high_resolution_clock::now();
    list<Student>::iterator it = studentsInList.begin();
    advance(it, 6);
    studentsInList.insert(it, *this);
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na 6 pozycje listy: " << duration.count() << "ns" << endl;
}

void Student::addToTheEndOfTheForwardList(forward_list<Student> &studentsInForwardList) {
    auto start = high_resolution_clock::now();
    auto it = studentsInForwardList.before_begin();
    auto end = studentsInForwardList.end();
    while (next(it) != end) {
        ++it;
    }
    studentsInForwardList.insert_after(it, *this);
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na koniec forward_list: " << duration.count() << "ns" << endl;
}

void Student::addToTheBeginningOfTheForwardList(forward_list<Student> &studentsInForwardList) {
    auto start = high_resolution_clock::now();
    studentsInForwardList.push_front(*this);
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na początek forward_list: " << duration.count() << "ns" << endl;
}

void Student::addInTheMiddleOfTheForwardList(forward_list<Student> &studentsInForwardList) {
    auto start = high_resolution_clock::now();
    auto it = studentsInForwardList.begin();
    for(int i = 0; i < 5; i++){
        it++;
    }
    if (it != studentsInForwardList.end()) {
        studentsInForwardList.insert_after(it, *this);
    }
    auto stop = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>(stop - start);
    cout << "Czas wykonania operacji dodawania na 6 miejsce forward_list: " << duration.count() << "ns" << endl;
}

