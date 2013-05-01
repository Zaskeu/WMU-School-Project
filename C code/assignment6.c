#include <stdio.h> // includes in this source
				   // the prototype for printf
				   
				   
int main( int argc, char *argv[]) // or int main() if no command line arguements
{    
	printf("The value used is 0x11111111 it equals: %d\n", countones(0x11111111));	
	
	printf("The value used is 3 \n",  countones(3));	
}