#include "DataWorker.h"

bool isInteger(const string& s)
{
    for (char const &ch : s) {
        if (isdigit(ch) == 0)
            return false;
    }
    return true;
 }


template <typename T1, typename T2, typename T3>
DataWorker<T1, T2, T3>* DataWorker<T1, T2, T3>::instance = nullptr;


int main() {
    const string filename = "/Users/radek/CLionProjects/4c668c11-gr03-repo/Laboratorium/lab5/data_file_example.txt";
    
    int rowSize;
    bool isSecondAnInt, isThirdAnInt;
    ifstream file(filename);
    
    if (!file.is_open()) {
        cout << "Sorry, we could't open your file" << endl;
        return 1;
    }
    
    vector<vector<string>> columns;
    
    string line;
    
    
    
    while (getline(file, line)) {
        vector<string> row;
        
        if (line.empty())
            continue;
        
        istringstream iss(line);
        string word;
        while (iss >> word) {
            row.push_back(word);
        }
        
        columns.push_back(row);
    }
    
    file.close();
    
    if (!columns.empty() && columns[0].size() >= 3) {
        
        rowSize = (int)columns[0].size();
        isSecondAnInt = isInteger(columns[0][1]);
        isThirdAnInt = isInteger(columns[0][2]);
        
        
        if(isSecondAnInt && isThirdAnInt){
            DataWorker<int, int, int>* dataWorker = DataWorker<int, int, int>::getInstance();
            dataWorker->readData(filename);
            dataWorker->columnsOperations(filename);
        }
        else if(isSecondAnInt && !isThirdAnInt){
            DataWorker<int, int, string>* dataWorker = DataWorker<int, int, string>::getInstance();
            dataWorker->readData(filename);
            dataWorker->columnsOperations(filename);
        }
        else if(!isSecondAnInt && isThirdAnInt){
            DataWorker<int, string, int>* dataWorker = DataWorker<int, string, int>::getInstance();
            dataWorker->readData(filename);
            dataWorker->columnsOperations(filename);
        }
        else{
            DataWorker<int, string, string>* dataWorker = DataWorker<int, string, string>::getInstance();
            dataWorker->readData(filename);
            dataWorker->columnsOperations(filename);
        }
        
        
        
    }else {
        cout << "Wrong file format." << endl;
        exit(0);
    }
    return 0;
}


