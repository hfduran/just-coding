#include <iostream>
#include <queue>
#include <vector>
using namespace std;

class Solution {
public:
  bool canFinish(int numCourses, vector<vector<int>> &prerequisites) {
    vector<int> indegrees(numCourses);
    vector<vector<int>> adjascents(numCourses);

    for (vector<int> prerequisite : prerequisites) {
      adjascents[prerequisite[1]].push_back(prerequisite[0]);
      indegrees[prerequisite[0]]++;
    }

    queue<int> q;
    for (int i = 0; i < numCourses; i++)
      if (indegrees[i] == 0)
        q.push(i);

    int nodesVisited = 0;
    while (!q.empty()) {
      for (auto &adj : adjascents[q.front()]) {
        indegrees[adj]--;
        if (indegrees[adj] == 0)
          q.push(adj);
      }
      q.pop();
      nodesVisited++;
    }

    return nodesVisited == numCourses;
  }
};

int main() {
  Solution sol;
  std::vector<std::vector<int>> matrix = {{0, 1}};
  cout << sol.canFinish(2, matrix);
  return 0;
}