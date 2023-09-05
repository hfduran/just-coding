#include <unordered_map>
#include <vector>
using namespace std;

class Node {
  public:
    int val;
    Node *next;
    Node *random;

    Node(int _val) {
        val = _val;
        next = nullptr;
        random = nullptr;
    }
};

class Solution {
  private:
    unordered_map<Node *, vector<Node *>> pending_randoms;

  public:
    Node *copyRandomList(Node *head) {
        if (head == nullptr)
            return nullptr;
        Node *curr = head;
        while (curr != nullptr) {
            if (pending_randoms.find(curr) != pending_randoms.end()) {
                auto vec = pending_randoms[curr];
                for (auto node : vec) {
                    node->random = curr;
                }
            }
        }
    }
};
