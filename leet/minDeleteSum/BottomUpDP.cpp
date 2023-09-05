#include <iostream>
#include <cstring>
#include <tuple>
#include <map>
#include <unordered_map>
using namespace std;

class Solution
{
public:
  int minimumDeleteSum(string s1, string s2)
  {
    int **computeCost = new int *[s1.length()];
    for (int i = 0; i < s1.length(); i++)
      computeCost[i] = new int[s2.length()];
  }
};

int main()
{
  Solution solution;
  cout << solution.minimumDeleteSum("eat", "sea");
  cout << "\n";
  return 0;
}