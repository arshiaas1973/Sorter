# Sorter
## This project can count same items and list them in a text file
<br/>
<br/>

# Usage
  
   
    sorter [source] [output] [seprator character]
	sorter [options]
    
    Options:
	
	-c <file>, --input <file>, --source <file>	Specify source file to be analysed.
	-o <file>, --output <file>			Specify output file
	-s <character>, --seprator <character>		Specify seperator of every item.
<br/>
<br/>


# Build/Install
## This is installation method that works in every os.


    git clone https://github.com/arshiaas1973/Sorter.git
    cd Sorter
    dotnet build -c release

> You can use `dotnet build` instead if the build is getting really large and take alot of time.

### If you are on windows run this:

    cp -r "bin\release\net7.0\Sorter.exe" .

### else

    cp -r "bin/release/net7.0/Sorter" .

# Examples
## There are examples in `example/` directory. you can run them like this.

### Windows:
    
    "Sorter.exe" -c example\fruits.txt -o example\outputfruits.txt

### Other OS:

    ./Sorter -c example/fruits.txt -o example/outputfruits.txt

# Publish
## If you want to build app in a way that contains less files run this command.

### Windows 64-bit:

    dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained false

### Windows 32-bit:

     dotnet publish -r win-x86 -p:PublishSingleFile=true --self-contained false

### Windows ARM64:

     dotnet publish -r win-arm64 -p:PublishSingleFile=true --self-contained false

### Linux x64:

     dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained false

### Linux ARM:

     dotnet publish -r linux-arm -p:PublishSingleFile=true --self-contained false

### Linux ARM:

     dotnet publish -r linux-arm64 -p:PublishSingleFile=true --self-contained false

### Mac OS `(Minimum OS version is macOS 10.12 Sierra)`:

    dotnet publish -r osx-x64 -p:PublishSingleFile=true --self-contained false



