
#ifndef PCH_H
#define PCH_H

#include "framework.h"

extern "C" int _declspec(dllexport) calculateFactorial(int n);
extern "C" int _declspec(dllexport) calculateSub(int a, int b);

#endif //PCH_H
