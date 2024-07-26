#include <iostream>
#include <queue>
#include <vector>

using namespace std;

class Solution {
  public:
    vector<int> productExceptSelf(vector<int> &nums) {
        int n = nums.size();
        vector<int> result(n);
        result[0] = 1;
        int suff = 1;

        for (int i = 1; i < n; i++) {
            result[i] = result[i - 1] * nums[i - 1];
        }

        for (int i = n - 2; i >= 0; i--) {
            suff = nums[i + 1] * suff;
            result[i] = result[i] * suff;
        }

        return result;
    }
};
