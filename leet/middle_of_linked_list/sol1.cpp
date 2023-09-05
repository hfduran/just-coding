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
    ListNode *middleNode(ListNode *head)
    {
        ListNode *middle = head;
        while (head->next != nullptr)
        {
            head = head->next;
            middle = middle->next;
            if (head->next == nullptr)
                break;
            head = head->next;
        }
        return middle;
    }
};