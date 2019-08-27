pushd d
cd src
dotnet publish -c release -r win10-x64 /p:PublishSingleFile=true --self-contained true

popd