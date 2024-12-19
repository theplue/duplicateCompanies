# Duplicate Names

This is just a quick console application that prints out names that could be duplicates read from a provided file
companies.txt

## Initial Solution

My first thought was to remove special characters and spaces to simplify comparing of company names, as many seemed to
have punctuation differences. Todo this I created an object that will hold the original name, and a simplified name
without special characters and all lower case.

## Next Steps

In the next steps I think it would be valuable to remove common words such as 'The', '.com', '.org', 'and', 'of', 'llc',
etc. as a few examples.