#include <vector>
#include <iostream>

using namespace std;

class Solution
{
public:
    int maxProfit(vector<int> &prices)
    {
        int buy = 0;
        int profit = 0;
        for (int i = 0; i < prices.size(); i++)
        {
            if (prices[i] < prices[buy])
                buy = i;
            if (prices[i] - prices[buy] > profit)
                profit = prices[i] - prices[buy];
        }
        return profit;
    }

private:
};

int main()
{
    Solution sol;
    vector<int> prices = {7, 1, 5, 3, 6, 4};
    cout << sol.maxProfit(prices) << "\n";
}
