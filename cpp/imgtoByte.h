#include <fstream>
#include <vector>
#include <iterator>
#include <string>

#ifdef __cplusplus
extern "C" {
#endif
#ifdef _WIN32
#  ifdef MODULE_API_EXPORTS
#    define MODULE_API __declspec(dllexport)
#  else
#    define MODULE_API __declspec(dllimport)
#  endif
#else
#  define MODULE_API
#endif


typedef void(*callback)(int, int *);

MODULE_API int add_nums (int a, int b);

MODULE_API void getByteArray(callback ,const char * filename);

#ifdef __cplusplus
}
#endif

