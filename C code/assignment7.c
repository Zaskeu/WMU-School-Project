#include <stdio.h> // includes in this source
				   // the prototype for printf
				   

unsigned char GetNthByte(int Source, int ByteCount);
int PutNthByte(int Destination, unsigned char Byte, int ByteCount);				   
int main( int argc, char *argv[]) // or int main() if no command line arguements
{    
    unsigned char result = GetNthByte(0xFACECAFE,2);
	printf("The value used is 0xFACECAFE it equals: %x\n",result);	
	
	int iresult = PutNthByte(0xFACECAFE,0X00,2);
	printf("The value used is 0xFACECAFE it equals: %x\n", iresult);	
	
}
