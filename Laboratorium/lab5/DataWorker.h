//
//  DataWorker.h
//  lab5
//
//  Created by Radek Grzywacz on 12/12/2023.
//


#include <stdio.h>
#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <string>

using namespace std;

template <typename T1, typename T2, typename T3>
class DataWorker {
private:
    static DataWorker<T1, T2, T3>* instance;
    ifstream file;
    vector<T1> col1;
    vector<T2> col2;
    vector<T3> col3;
    DataWorker() {}

public:
    static DataWorker<T1, T2, T3>* getInstance() {
        if (!instance) {
            instance = new DataWorker<T1, T2, T3>();
        }
        return instance;
    }
    
    ~DataWorker() {
           if (file.is_open()) {
               file.close();
           }
           if (instance) {
               delete instance;
           }
       }
    

    void readData(const string& filename) {
        file.open(filename);
            if (file.is_open()) {
                T1 value1;
                T2 value2;
                T3 value3;
                while (file >> value1 >> value2 >> value3) {
                    this->col1.push_back(value1);
                    this->col2.push_back(value2);
                    this->col3.push_back(value3);
                }
            }
    }
    void displayData(){
        for (int i=0; i<this->col1.size(); i++) {
            cout << this->col1[i] << " " << this->col2[i] << " "<< this->col3[i] << endl;
        }
    }
    void columnsOperations(const string& filename){
        ofstream file3("output.txt");
     
        for (T1 elem : this->col1) {
            if(elem == 0){
                cout << "Division error";
                exit(0);
            }
        }
        for (int i=0; i<this->col1.size(); i++) {
            file3 <<this->col1[i] << " " << this->col3[i] << " "<< this->col2[i] << " " <<30.0/this->col1[i] << endl;
        }
        
        
    }
};
