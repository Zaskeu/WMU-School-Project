#include <stdio.h> // includes in this source
				   // the prototype for printf
				   
				   
int main( int argc, char *argv[]) // or int main() if no command line arguements
{  
    int CFlag = 0;	
	int VFlag = 0;	
	int X = 1;
	int Y = 2;
	int Z = 3;	
	
	printf("Value returned is %d \n", Greatest(X,Y,Z));	
	
	printf("Value returned is %x \n",  BiggestUnsigned(CFlag));	
	
	printf("Value returned is %x \n", BiggestUnsignedV(VFlag));	

	
}

