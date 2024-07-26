#include <algorithm>
#include <vector>

using namespace std;

class Solution {
  public:
    int majorityElement(vector<int> &nums) {
        int n = nums[0];
        int count = 1;
        for (int i = 1; i < nums.size(); i++) {
            if (n == nums[i])
                count++;
            else
                count--;
            if (count == 0) {
                n = nums[i];
                count = 1;
            }
        }
        return n;
    }
};
