#include <vector>

using namespace std;

class Solution {
  public:
    void rotate(vector<int> &nums, int k) {
        k = k % nums.size();
        vector<int> split1 = vector<int>(nums.begin(), nums.end() - k);
        vector<int> split2 = vector<int>(nums.end() - k, nums.end());
        split2.insert(split2.end(), split1.begin(), split1.end());
        nums = split2;
    }
};

int main() {
    Solution sol;
    vector<int> nums = {1, 2, 3, 4, 5, 6, 7};
    sol.rotate(nums, 3);
}
