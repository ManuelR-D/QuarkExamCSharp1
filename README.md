# QuarkExamCSharp1
Simple Model View Presenter application purely in C# with SQL database.
![Model UML](https://github.com/ManuelR-D/QuarkExamanCSharp1/blob/master/UML/UML.jpg?raw=true)

# Dependencies
You should install System.Data.SqlClient via NuGet to get this running.

# Instructions
1. Clone this repository.
2. Start a Microsoft SQL Server.
3. Get your connection string.
4. Replace your connection string in the constant Program.CONNECTION_STRING at the root level of the project.
5. Compile the solution and run it. The ./Start/Starter class will try to create all the needed tables and set their initial values.
