//
// Created by Radek Grzywacz on 20/11/2023.
//

#ifndef INC_4C668C11_GR03_REPO_STUDENT_H
#define INC_4C668C11_GR03_REPO_STUDENT_H

#include <iostream>
#include <string>
#include <vector>
#include <deque>
#include <list>
#include <forward_list>
#include <chrono>
#include <iterator>

using namespace std;
using namespace std::chrono;

class Student {
public:
    string name;
    string surname;

//public:
    string getName();
    string getSurname();
    string getBoth();

    Student(string n, string sn);

    void addToTheEndOfTheVector(vector<Student> &studentsInVector);
    void addToTheBeginningOfTheVector(vector<Student> &studentsInVector);
    void addInTheMiddleOfTheVector(vector<Student> &studentsInVector);
    void addToTheBeginningOfTheDeque(deque<Student> &studentsInDeque);
    void addToTheEndOfTheDeque(deque<Student> &studentsInDeque);
    void addInTheMiddleOfTheDeque(deque<Student> &studentsInDeque);
    void addToTheBeginningOfTheList(list<Student> &studentsInList);
    void addToTheEndOfTheList(list<Student> &studentsInList);
    void addInTheMiddleOfTheList(list<Student> &studentsInList);
    void addToTheEndOfTheForwardList(forward_list<Student> &studentsInForwardList);
    void addToTheBeginningOfTheForwardList(forward_list<Student> &studentsInForwardList);
    void addInTheMiddleOfTheForwardList(forward_list<Student> &studentsInForwardList);



};


#endif //INC_4C668C11_GR03_REPO_STUDENT_H
