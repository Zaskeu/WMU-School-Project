#include <stdio.h>

 int MyStrCmp(char *, char *);
 
 int main( int argc, char *argv[])
 {
		char *string1 = "";
		char *string2 = "d";
		
        //printf("Please Input 2 strings"); //User inputs 2 values
		//fscanf(stdin,"%s %s", string1, string2);					
		
		printf("The Answer is: %d \n", MyStrCmp(string1, string2));			
		
 
 }
 