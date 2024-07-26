#include <iostream>
#include <vector>

using std::vector;

#define MAX_REPETITION 2

class Solution {
  public:
    int removeDuplicates(vector<int> &nums) {
        int base = 0;
        int check = 1;
        int counter = 0;
        int k = 1;

        while (check < nums.size()) {
            if (nums[check] == nums[base]) {
                if (counter < MAX_REPETITION - 1) {
                    counter++;
                    base++;
                    k++;
                    nums[base] = nums[check];
                }
            } else {
                base++;
                k++;
                nums[base] = nums[check];
                counter = 0;
            }
            check++;
        }
        return k;
    }
};

int main() {
    Solution sol;
    vector<int> nums = {1};
    int k = sol.removeDuplicates(nums);
    std::cout << "End";
}
