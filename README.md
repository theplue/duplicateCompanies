# Duplicate Names

This is just a quick console application that prints out names that could be duplicates read from a provided file
companies.txt

## Initial Solution

My first thought was to remove special characters and spaces to simplify comparing of company names, as many seemed to
have punctuation differences. Todo this I created an object that will hold the original name, and a simplified name
without special characters and all lower case. Then I use GroupBy to group the companies on matching strings, I pull out
the original names, and make them into a new object that returns a key (matched strings), the List of Company names that are similar
and a Count of how many companies could be similar. I then filter out companies that have only 1 match, and return the 
remaining companies which then print out how many different companies have matches (int) and the company names that are similar.

## Next Steps

In the next steps I think it would be valuable to remove common words such as 'The', '.com', '.org', 'and', 'of', 'llc',
etc. as a few examples. I think this would be the next best step for finding additional duplicates. Furthur more I would also want to create 
a bunch of tests for known duplicates, to validate current findings. I would look at the performance, as I did not factor in memory 
usage or speed of my solution.
