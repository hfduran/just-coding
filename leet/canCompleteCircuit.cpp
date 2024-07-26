#include <iostream>
#include <vector>

using namespace std;

class Solution {
public:
	int canCompleteCircuit(vector<int>& gas, vector<int>& cost) {
		int n = gas.size();
		vector<int> diff(n);
		int total = 0;

		for(int i = 0; i < n; i++) {
			int diff_i = gas[i] - cost[i];
			diff[i] = diff_i;
			total += diff_i;
		}

		if(total < 0) {
			return -1;
		}

		int balance = 0;
		int init = 0;
		for(int i = 0; i < n; i++) {
			balance += diff[i];
			if(balance < 0) {
				balance = 0;
				init = i + 1;
			}
		}
		return init;
	}
};
