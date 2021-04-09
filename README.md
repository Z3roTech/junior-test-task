## Junior test task program
This is my testing task to junior job, but I turned it in sandbox program where I use new things for me.  
   
### Build
For build you must create database:   
**Default:** using MSSQL Server, database "Slata"
For simple add use: Add-Migration, Update-Database in Package Manager Console (Visual Studio);   
**Important** Change database connection settings in _Data/AppContext_ before migration and updating database.

### Additional project plugins
* Material Design Themes v4.0.0
* Microsoft.EntityFrameworkCore v5.0.5
    * Microsoft.EntityFrameworkCore.SqlServer
    * Microsoft.EntityFrameworkCore.Tools
