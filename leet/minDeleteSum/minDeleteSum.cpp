#include <iostream>
using namespace std;

class Solution
{
public:
  int minimumDeleteSum(string s1, string s2)
  {
    return computeCost(s1, s2, s1.length(), s2.length());
  }

private:
  int computeCost(string &s1, string &s2, int i, int j)
  {
    if (i < 0)
    {
      int s2_rest_sum = 0;
      for (int k = j; k >= 0; k--)
      {
        s2_rest_sum += (int)s2[k];
      }
      return s2_rest_sum;
    }
    if (j < 0)
    {
      int s1_rest_sum = 0;
      for (int k = i; k >= 0; k--)
      {
        s1_rest_sum += (int)s1[k];
      }
      return s1_rest_sum;
    }
    if (s1[i] == s2[j])
    {
      return computeCost(s1, s2, i - 1, j - 1);
    }
    return min(min(
                   (int)s1[i] + computeCost(s1, s2, i - 1, j),
                   (int)s2[j] + computeCost(s1, s2, i, j - 1)),
               (int)s1[i] + (int)s2[j] + computeCost(s1, s2, i - 1, j - 1));
  }
};

int main() {
  Solution solution;
  cout << solution.minimumDeleteSum("sea", "eat");
  cout<<"\n";
  return 0;
}