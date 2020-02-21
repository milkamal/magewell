
#include "imgtoByte.h"
#include<iostream>
callback _chashCallback; 

void getByteArray(callback delegateA, const char * filename){
        std::vector<char> buffer;
		std::cout<<"inside 1";
		// _chashCallback = delegateA;
        std::cout<<filename;



        std::fstream file;
        FILE *fp=NULL;
        //char buff[30000];
        int *buff = new int[40000];
        fp = fopen("sky.jpg","r+");
        if(fp == NULL)
        {
            std::cout<< "Not able to open the file ";
            return ;
        }
        else
        {
          fread(buff,40000,0,fp);
	
		// calling c# delegate method
		    delegateA(40000, buff);
            //buffer.clear();
            fclose(fp);
            return ;

        }


}


int add_nums(int a, int b){
    std::cout<<"3vbcfb";
        return a+b;
}

