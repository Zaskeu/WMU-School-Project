#include <stdio.h>

void PrintIDS(char *,...);

int main( int argc, char *argv[]) // or int main() if no command line arguements
{	
	PrintIDS("%x",0xFaceCafe); 
	PrintIDS("%c",'c');
	PrintIDS("%s","String");
	PrintIDS("%u",16);
	PrintIDS("%d",-14);
	PrintIDS("%d",15);
}
