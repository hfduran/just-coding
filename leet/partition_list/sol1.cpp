#include <iostream>
using namespace std;

struct ListNode
{
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
};

class Solution
{
public:
    ListNode *partition(ListNode *head, int x)
    {
        if (head == nullptr)
            return nullptr;

        ListNode smalls_head(0), bigs_head(0);
        ListNode *small_next = &smalls_head;
        ListNode *big_next = &bigs_head;

        while (head)
        {
            if (head->val < x)
            {
                ListNode new_node(head->val);
                small_next = &new_node;
                small_next = small_next->next;
            }
            else
            {
                ListNode new_node(head->val);
                big_next = &new_node;
                big_next = big_next->next;
            }
            head = head->next;
        }
        big_next = nullptr;
        small_next = &bigs_head;
        return &smalls_head;
    }
};
int main()
{
    Solution sol;
    return 0;
}