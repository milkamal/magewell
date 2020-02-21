cmake ..
make
mv libimg_converterv2.so ../../Test/
dotnet build ../../Test/Test.csproj
dotnet ../../Test/bin/Debug/netcoreapp3.1/Test.dll