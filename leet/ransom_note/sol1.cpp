#include <iostream>
#include <cstring>
#include <unordered_map>
using namespace std;

class Solution
{
public:
    bool canConstruct(string ransomNote, string magazine)
    {
        unordered_map<char, int> map;
        for (char c : magazine)
        {
            if (map.find(c) != map.end())
                map[c]++;
            else
                map[c] = 1;
        }
        for (char c : ransomNote)
        {
            if (map.find(c) == map.end())
                return false;
            if (map[c] == 0)
                return false;
            map[c]--;
        }
        return true;
    }
};