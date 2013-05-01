#include <stdio.h>

int Func1(int A, int B);

int main( int argc, char *argv[]) // or int main() if no command line arguements
{
		int A = 0;
		int B = 0;
		int Q = 0;
		printf("Please Input 2 values"); //User inputs 2 values
		fscanf(stdin,"%d %d",&A,&B); 
		
		if(A < 0 || B < 0)
		{
			printf("ERROR: No negative numbers please :)");
		}
		else
		{
		Q = Func1(A,B);
		}
		
		printf("Value returned is %d \n",Q);


}

