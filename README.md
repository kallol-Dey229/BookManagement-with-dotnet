Normal scafold command : dotnet ef dbcontext scaffold "Name=DbConn" Microsoft.EntityFrameworkCore.SqlServer --project DAL --startup-project AppLayer --context-dir EF --output-dir EF/Tables

Command after change anything in database : dotnet ef dbcontext scaffold "Name=DbConn" Microsoft.EntityFrameworkCore.SqlServer --project DAL --startup-project AppLayer --context-dir EF --output-dir EF/Tables --force
