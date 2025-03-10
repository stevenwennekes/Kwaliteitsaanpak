"""Markdown syntax."""

BEGIN_PATTERN = r"^<!-- begin: ([^ ]+)\s?([^ ]*) -->"
BOLD_START = BOLD_END = "**"
BOLD_ALTERNATIVE_START = BOLD_ALTERNATIVE_END = "__"
BULLET_LIST_PATTERN = r"^[\*\+\-] "
CELL_ALIGNMENT_MARKER = ":"
END_PATTERN = r"^<!-- end: ([^ ]+) -->"
HEADING_PATTERN = r"^(#+) (.*)"
IMAGE_PATTERN = r'^!\[([^\]]+)\]\(([^ ]+) "([^\)]+)"\)'
INSTRUCTION_START = "{"
INSTRUCTION_END = "}"
ITALIC_START = ITALIC_END = "_"
ITALIC_ALTERNATIVE_START = ITALIC_ALTERNATIVE_END = "*"
LINK_PATTERN = r"^\[([^\]]+)\]\(([^\)]+)\)"
MEASURE_START = "@{"
MEASURE_END = "}@"
NUMBERED_LIST_PATTERN = r"^[0-9A-Za-z]+\. "
STRIKETROUGH_START = STRIKETROUGH_END = "~~"
TABLE_MARKER = "|"
VARIABLE_USE_PATTERN = r"^\$([^\$]+)\$"
