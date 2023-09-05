#include <iostream>
#include <cstring>
#include <vector>
using namespace std;

class Solution
{
public:
    vector<string> fizzBuzz(int n)
    {
        vector<string> response;
        for (int i = 1; i <= n; i++)
            response.push_back(say_string(i));
        return response;
    }

private:
    string say_string(int x)
    {
        if (x % 3 == 0 || x % 5 == 0)
        {
            string s;
            if (x % 3 == 0)
                s.append("Fizz");
            if (x % 5 == 0)
                s.append("Buzz");
            return s;
        }
        else
            return to_string(x);
    }
};