To run, navigate to the root of this directory, and then:
```sh
cd CustomerCommLib/
dotnet restore
dotnet build

# actually navigate to the tests dir
cd ../CustomerComm.Tests
dotnet restore
dotnet test
```

The last `dotnet test` command will show you the results of the unit tests.