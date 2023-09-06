#include <iostream>
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

void printLinkedList(Node *head) {
    Node *current = head;
    std::cout << "[";
    while (current != nullptr) {
        std::cout << " [" << current->val;

        if (current->random != nullptr) {
            std::cout << ", " << current->random->val;
        } else {
            std::cout << ", nullptr";
        }

        std::cout << "],";

        current = current->next;
    }
    std::cout << "]";
}

int main() {
    // Create a sample linked list
    Node *node1 = new Node(1);
    Node *node2 = new Node(2);
    Node *node3 = new Node(3);

    Node *test = node1;

    node1->next = node2;
    node2->next = node3;

    // Assign random pointers
    node1->random = node3;
    node2->random = node1;
    node3->random = node2;

    // Print the linked list
    printLinkedList(test);

    // Don't forget to free memory allocated for nodes
    delete node1;
    delete node2;
    delete node3;

    return 0;
}
