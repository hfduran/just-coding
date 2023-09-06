python
import gdb.printing

class UnorderedMapPrinter:
    def __init__(self, val):
        self.val = val

    def to_string(self):
        contents = []
        for item in self.val["table_"]:
            while item:
                key = item["value_"]["first"]
                value = item["value_"]["second"]
                contents.append("(%s, %s)" % (key, value))
                item = item["next_"]
        return "{" + ", ".join(contents) + "}"

def build_pretty_printer():
    pp = gdb.printing.RegexpCollectionPrettyPrinter("unordered_map")
    pp.add_printer('unordered_map', '^std::unordered_map<.*>$', UnorderedMapPrinter)
    return pp

gdb.printing.register_pretty_printer(gdb.current_objfile(), build_pretty_printer())
end

