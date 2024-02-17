// dllmain.cpp : 定义 DLL 应用程序的入口点。
#include "pch.h"
#include<math.h>

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}
int calculateFactorial(int n)
{
    if (n < 0)
    {
        return -1;
    }
    else if (n == 0 || n == 1)
    {
        return 1;
    }
    else
    {
        return calculateFactorial(n - 1) * n;
    }
}
int calculateSub(int a, int b)
{
    return a - b;
}
