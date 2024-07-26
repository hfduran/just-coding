#include <iostream>
#include <vector>

using namespace std;

class Solution {
  public:
    // focusing on memory optimization: no "diff" vector!
    int canCompleteCircuit(vector<int> &gas, vector<int> &cost) {
        int init = 0;
        int balance = 0;
        int total = 0;
        for (int i = 0; i < gas.size(); i++) {
            balance += gas[i] - cost[i];
            if (balance < 0) {
                total += balance;
                balance = 0;
                init = i + 1;
            }
        }
        total += balance;
        if (total < 0) {
            return -1;
        }
        return init;
    }
};

int main() {
  cout << "testeii";
  return 0;
}
