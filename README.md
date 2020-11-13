# Note

THIS PROJECT IS DEPRECATED and no longer maintained. A newer version of the project that uses the Angular CLI and the latest version of Angular can be found here: 

https://github.com/DanWahlin/AngularCLI-ASPNET-Core-CustomersService

This project has been updated to use the latest version of Angular and RxJS but does not use the Angular CLI (it uses System.js to load modules). Key changes from
the Pluralsight course include:

* HttpClientModule now used instead of HttpModule (since it's deprecated after Angular 4.3+)
* HttpClient now used instead of Http (since it's deprecated after Angular 4.3+) 
* RxJS chained operators such as map and catch have been changed to the new pipe() style of coding in the latest version of RxJS.

# Angular, ASP.NET Core Customers Service Application

This project demonstrates how Angular and ASP.NET Core can be used together.


## Software Requirements To Run Locally

* Visual Studio 2017 Community 15.3.3 (or higher) for Windows. VERY IMPORTANT to have 15.3.3 or higher so make sure you've installed the latest updates!
* Any editor on Mac although VS Code (https://code.visualstudio.com/?WT.mc_id=m365-0000-dwahlin) is recommended.
* ASP.NET Core SDK 2.0 or higher - http://dot.net 
* Node.js 8.11 or higher

### Running the Application Locally on Windows

1. Open the .sln file in Visual Studio

1. Install Gulp: `npm install gulp -g`

1. Run `npm install` to install app dependencies (make sure to run this in the folder where the package.json file lives)

1. Run the following Gulp task to copy required Angular modules into the `wwwroot` folder: 

    `gulp copy:libs`

1. Build and run the application (F5)

1. Browse to http://localhost:5000

### Running the Application Locally on Mac

1. Open the project folder in VS Code

1. Install Gulp: `npm install gulp -g`

1. Run `npm install` to install app dependencies (make sure to run this in the folder where the package.json file lives)

1. Run the following Gulp task to copy required Angular modules into the `wwwroot` folder: 

    `gulp copy:libs`

1. Run `npm run tsc:w` to compile TypeScript to JavaScript locally (leave the window running). This is only needed when in "dev" mode.

1. Open another command window and run the following:

    * Run `dotnet restore`

    * Run `dotnet build`

    * Run `dotnet run`

1. Browse to http://localhost:8000