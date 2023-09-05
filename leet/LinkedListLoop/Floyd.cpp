
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
  public:
    bool hasCycle(ListNode *head) {
        ListNode *fast = head;
        ListNode *slow = head;

        while (fast != nullptr && fast->next != nullptr) {
            fast = fast->next->next;
            slow = slow->next;

            if (fast == slow)
                return true;
        }
        return false;
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
