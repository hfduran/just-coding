#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

class Solution {
  public:
    int candy(vector<int> &ratings) {
        int n = ratings.size();
        int candies = 0;
        int count = 0;
        int peak = 0;
        int state = 0;
        // for (int i = 0; i < n - 1; i++) {
        int i = 0;
        while (i < n - 1) {
            switch (state) {
            case 0:
                if (ratings[i] > ratings[i + 1]) {
                    state = 1;
                } else if (ratings[i] < ratings[i + 1]) {
                    state = 2;
                } else {
                    state = 3;
                }
                break;
            case 1:
                while (ratings[i] > ratings[i + 1]) {
                }
                break;
            }
        }
    }
};

int main() {
    Solution sol;
    vector<int> input = {29, 51, 87, 87, 72, 12};
    auto result = sol.candy(input);
    cout << result;
    return 0;
}
