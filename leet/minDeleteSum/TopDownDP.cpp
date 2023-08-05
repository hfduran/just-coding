#include <iostream>
#include <cstring>
#include <tuple>
#include <map>
#include <unordered_map>
using namespace std;

class Solution
{
public:
  Solution()
  {
    memset(dp, -1, sizeof(dp));
  }
  int minimumDeleteSum(string s1, string s2)
  {
    this->s1 = s1;
    this->s2 = s2;
    return computeCost(s1.length() - 1, s2.length() - 1);
  }

private:
  static const int DP_LENGTH = 1000;
  int dp[DP_LENGTH][DP_LENGTH];
  string s1;
  string s2;

  int computeCost(int i, int j)
  {
    if (i < 0 && j < 0)
      return 0;

    const int value = dp[i + 1][j + 1];
    if (value != -1)
      return value;

    if (i < 0)
    {
      const int sum = (int)s2[j] + computeCost(i, j - 1);
      dp[i + 1][j + 1] = sum;
      return sum;
    }
    if (j < 0)
    {
      const int sum = (int)s1[i] + computeCost(i - 1, j);
      dp[i + 1][j + 1] = sum;
      return sum;
    }
    if (s1[i] == s2[j])
    {
      const int sum = computeCost(i - 1, j - 1);
      dp[i + 1][j + 1] = sum;
      return sum;
    }
    const int sum = min((int)s1[i] + computeCost(i - 1, j),
                        (int)s2[j] + computeCost(i, j - 1));
    dp[i + 1][j + 1] = sum;
    return sum;
  }
};

int main()
{
  Solution solution;
  cout << solution.minimumDeleteSum("eat", "sea");
  cout << "\n";
  return 0;
}