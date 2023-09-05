#include <iostream>
#include <unordered_map>
#include <vector>
using namespace std;

struct ListNode {
    int val;
    ListNode *next;
    ListNode(int x) : val(x), next(NULL) {}
};

class Solution {
  private:
    unordered_map<ListNode *, bool> pointers_map;

    bool repeated_pointer(ListNode *new_pointer) {
        if (pointers_map.find(new_pointer) == pointers_map.end())
            return false;
        return true;
    }

  public:
    bool hasCycle(ListNode *head) {
        if (head == nullptr)
            return false;

        ListNode *curr = head;
        do {
            if (curr->next == nullptr)
                return false;
            pointers_map[curr] = true;
            curr = curr->next;
        } while (!repeated_pointer(curr));
        return true;
    }
};

int main() {
    Solution sol;
    ListNode *node1 = new ListNode(1);
    ListNode *node2 = new ListNode(2);

    node1->next = node2;
    cout << sol.hasCycle(node1);
    return 0;
}
