#include <iostream>
#include <unordered_map>
#include <vector>
using namespace std;

template <typename KeyType, typename ValueType>
void printUnorderedMap(const std::unordered_map<KeyType, ValueType> &map) {
    for (const auto &pair : map) {
        std::cout << "Key: " << pair.first << " Value: " << pair.second
                  << std::endl;
    }
}

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
    unordered_map<Node *, Node *> links;

  public:
    Node *copyRandomList(Node *head) {
        if (head == nullptr)
            return nullptr;
        links[nullptr] = nullptr;
        Node *curr = head;
        Node *copy = new Node(head->val);
        Node *created = copy;
        while (curr != nullptr) {
            created->val = curr->val;
            links[curr] = created;

            if (links.find(curr->random) != links.end())
                created->random = links[curr->random];
            else {
                // add curr->random to pending_randoms
                if (pending_randoms.find(curr->random) !=
                    pending_randoms.end()) {
                    pending_randoms[curr->random].push_back(created);
                } else {
                    pending_randoms[curr->random] = {created};
                }
            }

            if (pending_randoms.find(curr) != pending_randoms.end()) {
                vector<Node *> vec = pending_randoms[curr];
                for (Node *node : vec)
                    node->random = links[curr];
            }
            curr = curr->next;
            if (curr != nullptr) {
                created->next = new Node(0);
                created = created->next;
            }
        }
        return copy;
    }
};

void printLinkedList(Node *head) {
    Node *current = head;
    cout << "[";
    while (current != nullptr) {
        cout << " [" << current->val;

        if (current->random != nullptr) {
            cout << ", " << current->random->val;
        } else {
            cout << ", null";
        }

        cout << "],";

        current = current->next;
    }
    cout << "]" << endl;
}

int main() {
    Solution sol;
    Node *node0 = new Node(1);
    Node *node1 = new Node(2);
    Node *node2 = new Node(3);
    Node *node3 = new Node(4);

    node0->random = node2;
    node1->random = node2;
    node2->random = nullptr;
    node3->random = node1;

    node0->next = node1;
    node1->next = node2;
    node2->next = node3;

    printLinkedList(node0);

    printLinkedList(sol.copyRandomList(node0));
}
