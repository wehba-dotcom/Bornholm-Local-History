First-To connect to the SSMS database with sql server:
 1- change every db string connections in every service to your onwer database server name and database name, 
      it must machtes string connection on docker compose file. 
second-To run the solution in a command window, do the following:
    1-Build the solution in release mode.
    2- Open a Terminal Developer PowerShell on  Visual Studio 2022 
    3-Write commanad " docker compose up --build"
third-To process communication with RabbitMQ server, you must change the connections properties with your owners, you can find on RabbitMQ instance :
string ConnectionString = "host=?;virtualHost=?;username=?;password=?";
   
